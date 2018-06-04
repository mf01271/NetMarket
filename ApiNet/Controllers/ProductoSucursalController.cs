using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Web.Http;
using NetMarketData.Domain.Entities;
using NetMarketData.Infrastructure.Data.DataModels;
using ApiNet.Models;
using NetMarketData.Domain.Services;


namespace ApiNet.Controllers
{
    public class ProductoSucursalController : ApiController
    {
        private readonly ProductoEmpresaService productoempresaservico = new ProductoEmpresaService();
        private readonly ProductoService productoServicio = new ProductoService();
        private readonly CategoriaProductoService categoriaServicio = new CategoriaProductoService();
        private readonly EmpresaService empresaSevicio = new EmpresaService();
        private readonly ProductoSucursalService productosucursalService = new ProductoSucursalService();
        private readonly SucursalService sucursalService = new SucursalService();
        private readonly ImagenService imagenService = new ImagenService();

        [Route("api/productosucursal/verproductos")]
        [HttpPost]
        public IHttpActionResult verproductos([FromBody] ProductoSucursalDTO p)
        {
            try
            {
                List<ProductoSucursalDTO> productos = new List<ProductoSucursalDTO>();
                var listpro = productosucursalService.Obtenerproductos(p);
                foreach (var pr in listpro)
                {
                    ProductoEmpresaDTO ppe = new ProductoEmpresaDTO()
                    {
                        idProductoEmpresa=pr.idProductoEmpresa
                    };
                    long idp = productoempresaservico.Obtenerproducto(ppe).idProducto;
                    ProductoDTO pp = new ProductoDTO()
                    {
                        idProducto = idp
                    };
                    long idc = productoServicio.Obtenerproducto(pp).idCategoria;
                    CategoriaDTO c = new CategoriaDTO()
                    {
                        idCategoria = idc
                    };
                    SucursalDTO s = new SucursalDTO()
                    {
                        idSucursal = pr.idSucursal
                    };
                    long ide = sucursalService.ObtenerSucursal(s).idEmpresa;
                    EmpresaDTO e = new EmpresaDTO()
                    {
                        idEmpresa = ide
                    };
                    ImagenDTO i3 = new ImagenDTO()
                    {
                        idProductoSucursal = pr.idProductoSucursal,
                        principal = true
                    };
                    ImagenDTO i2 = new ImagenDTO()
                    {
                        idProductoEmpresa = pr.idProductoEmpresa,
                        principal = true
                    };
                    ImagenDTO i1 = new ImagenDTO()
                    {
                        idProducto = idp,
                        principal = true
                    };
                    string imag1 = "";
                    string imag2 = "";
                    string imag3 = "";
                    if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i1)))
                    {
                        if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i2)))
                        {
                            if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i3)))
                            {
                            }
                            else
                            {
                                imag1 = imagenService.Obtenerimagen(i3);
                            }
                        }
                        else
                        {
                            imag1 = imagenService.Obtenerimagen(i2);
                            if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i3)))
                            {
                            }
                            else
                            {
                                imag2 = imagenService.Obtenerimagen(i3);
                            }
                        }
                    }
                    else
                    {
                        imag1 = imagenService.Obtenerimagen(i1);
                        if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i2)))
                        {
                            if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i3)))
                            {
                            }
                            else
                            {
                                imag2 = imagenService.Obtenerimagen(i3);
                            }
                        }
                        else
                        {
                            imag2 = imagenService.Obtenerimagen(i2);
                            if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i3)))
                            {
                            }
                            else
                            {
                                imag3 = imagenService.Obtenerimagen(i3);
                            }
                        }
                    }
                    productos.Add(new ProductoSucursalDTO
                    {
                        idProductoSucursal = pr.idProductoSucursal,
                        idProductoEmpresa = pr.idProductoEmpresa,
                        idProducto = pp.idProducto,
                        precio = Convert.ToDecimal(pr.precio),
                        nombre = productoServicio.Obtenerproducto(pp).nombreProducto,
                        idEmpresa = Convert.ToInt64(ide),
                        nombreEmpresa = empresaSevicio.ObtenerEmpresa(e).nombreEmpresa,
                        idCategoria = categoriaServicio.Obtenercategoria(
                            new CategoriaDTO()
                            {
                                idCategoria = productoServicio.Obtenerproducto(pp).idCategoria
                            }
                            ).idCategoria,
                        nombreCategoria = categoriaServicio.Obtenercategoria(
                            new CategoriaDTO()
                            {
                                idCategoria = productoServicio.Obtenerproducto(pp).idCategoria
                            }
                            ).nombreCategoria,
                        idSucursal = s.idSucursal,
                        nombreSucursal = sucursalService.ObtenerSucursal(s).nombreSucursal,
                        descripcionCorta= productoServicio.Obtenerproducto(pp).descripcionCortaProducto,
                        descripcionLarga= productoServicio.Obtenerproducto(pp).descripcionLargaProducto,
                        rutaimagen1 = imag1,
                        rutaimagen2 = imag2,
                        rutaimagen3 = imag3,
                        
                    });
                }

                return Ok(RespuestaApi<List<ProductoSucursalDTO>>.createRespuestaSuccess(productos, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/productosucursal/verproductosbysucursal")]
        [HttpPost]
        public IHttpActionResult verproductosbysucursal([FromBody] ProductoSucursalDTO p)
        {
            try
            {
                List<ProductoSucursalDTO> productos = new List<ProductoSucursalDTO>();
                var listpro = productosucursalService.ObtenerproductosbySucursal(p);
                foreach (var pr in listpro)
                {
                    ProductoEmpresaDTO ppe = new ProductoEmpresaDTO()
                    {
                        idProductoEmpresa = pr.idProductoEmpresa
                    };
                    long idp = productoempresaservico.Obtenerproducto(ppe).idProducto;
                    ProductoDTO pp = new ProductoDTO()
                    {
                        idProducto = idp
                    };
                    long idc = productoServicio.Obtenerproducto(pp).idCategoria;
                    CategoriaDTO c = new CategoriaDTO()
                    {
                        idCategoria = idc
                    };
                    SucursalDTO s = new SucursalDTO()
                    {
                        idSucursal = pr.idSucursal
                    };
                    long ide = sucursalService.ObtenerSucursal(s).idEmpresa;
                    EmpresaDTO e = new EmpresaDTO()
                    {
                        idEmpresa = ide
                    };
                    ImagenDTO i3 = new ImagenDTO()
                    {
                        idProductoSucursal = pr.idProductoSucursal,
                        principal = true
                    };
                    ImagenDTO i2 = new ImagenDTO()
                    {
                        idProductoEmpresa = pr.idProductoEmpresa,
                        principal = true
                    };
                    ImagenDTO i1 = new ImagenDTO()
                    {
                        idProducto = idp,
                        principal = true
                    };
                    string imag1 = "";
                    string imag2 = "";
                    string imag3 = "";
                    if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i1)))
                    {
                        if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i2)))
                        {
                            if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i3)))
                            {
                            }
                            else
                            {
                                imag1 = imagenService.Obtenerimagen(i3);
                            }
                        }
                        else
                        {
                            imag1 = imagenService.Obtenerimagen(i2);
                            if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i3)))
                            {
                            }
                            else
                            {
                                imag2 = imagenService.Obtenerimagen(i3);
                            }
                        }
                    }
                    else
                    {
                        imag1 = imagenService.Obtenerimagen(i1);
                        if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i2)))
                        {
                            if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i3)))
                            {
                            }
                            else
                            {
                                imag2 = imagenService.Obtenerimagen(i3);
                            }
                        }
                        else
                        {
                            imag2 = imagenService.Obtenerimagen(i2);
                            if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i3)))
                            {
                            }
                            else
                            {
                                imag3 = imagenService.Obtenerimagen(i3);
                            }
                        }
                    }
                    productos.Add(new ProductoSucursalDTO
                    {
                        idProductoSucursal = pr.idProductoSucursal,
                        idProductoEmpresa = pr.idProductoEmpresa,
                        idProducto = pp.idProducto,
                        precio = Convert.ToDecimal(pr.precio),
                        nombre = productoServicio.Obtenerproducto(pp).nombreProducto,
                        idEmpresa = Convert.ToInt64(ide),
                        nombreEmpresa = empresaSevicio.ObtenerEmpresa(e).nombreEmpresa,
                        idCategoria = categoriaServicio.Obtenercategoria(
                            new CategoriaDTO()
                            {
                                idCategoria = productoServicio.Obtenerproducto(pp).idCategoria
                            }
                            ).idCategoria,
                        nombreCategoria = categoriaServicio.Obtenercategoria(
                            new CategoriaDTO()
                            {
                                idCategoria = productoServicio.Obtenerproducto(pp).idCategoria
                            }
                            ).nombreCategoria,
                        idSucursal = s.idSucursal,
                        nombreSucursal = sucursalService.ObtenerSucursal(s).nombreSucursal,
                        descripcionCorta = productoServicio.Obtenerproducto(pp).descripcionCortaProducto,
                        descripcionLarga = productoServicio.Obtenerproducto(pp).descripcionLargaProducto,
                        rutaimagen1 = imag1,
                        rutaimagen2 = imag2,
                        rutaimagen3 = imag3
                    });
                }

                return Ok(RespuestaApi<List<ProductoSucursalDTO>>.createRespuestaSuccess(productos, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/productosucursal/guardarproducto")]
        [HttpPost]
        public IHttpActionResult guardarproducto([FromBody] ProductoSucursalDTO p)
        {
            try
            {
                if (string.IsNullOrEmpty(p.precio.ToString()))
                {
                    ProductoEmpresaDTO pe = new ProductoEmpresaDTO();
                    pe.idProductoEmpresa = p.idProductoEmpresa;
                    p.precio = Convert.ToDecimal(productoempresaservico.Obtenerproducto(pe).Precio);
                }
                long pk = productosucursalService.Guardarproducto(p);

                return Ok(RespuestaApi<long>.createRespuestaSuccess(pk, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/productosucursal/verproducto")]
        [HttpPost]
        public IHttpActionResult verproducto([FromBody] ProductoSucursalDTO p)
        {
            try
            {
                ProductoSucursal pro = new ProductoSucursal();
                ProductoSucursalDTO producto = new ProductoSucursalDTO();
                pro = productosucursalService.Obtenerproducto(p);
                ProductoEmpresaDTO ppe = new ProductoEmpresaDTO()
                {
                    idProductoEmpresa = pro.idProductoEmpresa
                };
                long idp = productoempresaservico.Obtenerproducto(ppe).idProducto;
                ProductoDTO pp = new ProductoDTO()
                {
                    idProducto = idp
                };
                long idc = productoServicio.Obtenerproducto(pp).idCategoria;
                CategoriaDTO c = new CategoriaDTO()
                {
                    idCategoria = idc
                };
                SucursalDTO s = new SucursalDTO()
                {
                    idSucursal = pro.idSucursal
                };
                long ide = sucursalService.ObtenerSucursal(s).idEmpresa;
                EmpresaDTO e = new EmpresaDTO()
                {
                    idEmpresa = ide
                };
                ImagenDTO i3 = new ImagenDTO()
                {
                    idProductoSucursal = pro.idProductoSucursal,
                    principal = true
                };
                ImagenDTO i2 = new ImagenDTO()
                {
                    idProductoEmpresa = pro.idProductoEmpresa,
                    principal = true
                };
                ImagenDTO i1 = new ImagenDTO()
                {
                    idProducto = idp,
                    principal = true
                };
                string imag1 = "";
                string imag2 = "";
                string imag3 = "";
                if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i1)))
                {
                    if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i2)))
                    {
                        if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i3)))
                        {
                        }
                        else
                        {
                            imag1 = imagenService.Obtenerimagen(i3);
                        }
                    }
                    else
                    {
                        imag1 = imagenService.Obtenerimagen(i2);
                        if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i3)))
                        {
                        }
                        else
                        {
                            imag2 = imagenService.Obtenerimagen(i3);
                        }
                    }
                }
                else
                {
                    imag1 = imagenService.Obtenerimagen(i1);
                    if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i2)))
                    {
                        if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i3)))
                        {
                        }
                        else
                        {
                            imag2 = imagenService.Obtenerimagen(i3);
                        }
                    }
                    else
                    {
                        imag2 = imagenService.Obtenerimagen(i2);
                        if (string.IsNullOrEmpty(imagenService.Obtenerimagen(i3)))
                        {
                        }
                        else
                        {
                            imag3 = imagenService.Obtenerimagen(i3);
                        }
                    }
                }
                producto.idProductoSucursal = pro.idProductoSucursal;
                producto.idProductoEmpresa = pro.idProductoEmpresa;
                producto.idProducto = pp.idProducto;
                producto.precio = Convert.ToDecimal(pro.precio);
                producto.nombre = productoServicio.Obtenerproducto(pp).nombreProducto;
                producto.idEmpresa = Convert.ToInt64(ide);
                producto.nombreEmpresa = empresaSevicio.ObtenerEmpresa(e).nombreEmpresa;
                producto.idCategoria = categoriaServicio.Obtenercategoria(
                    new CategoriaDTO()
                    {
                        idCategoria = productoServicio.Obtenerproducto(pp).idCategoria
                    }
                    ).idCategoria;
                producto.nombreCategoria = categoriaServicio.Obtenercategoria(
                    new CategoriaDTO()
                    {
                        idCategoria = productoServicio.Obtenerproducto(pp).idCategoria
                    }
                    ).nombreCategoria;
                producto.idSucursal = s.idSucursal;
                producto.nombreSucursal = sucursalService.ObtenerSucursal(s).nombreSucursal;
                producto.descripcionCorta = productoServicio.Obtenerproducto(pp).descripcionCortaProducto;
                producto.descripcionLarga = productoServicio.Obtenerproducto(pp).descripcionLargaProducto;
                producto.rutaimagen1 = imag1;
                producto.rutaimagen2 = imag2;
                producto.rutaimagen3 = imag3;




                return Ok(RespuestaApi<ProductoSucursalDTO>.createRespuestaSuccess(producto, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/productosucursal/eliminarproducto")]
        [HttpPost]
        public IHttpActionResult eliminarproducto([FromBody] ProductoSucursalDTO p)
        {
            try
            {
                productosucursalService.Eliminarproducto(p);

                return Ok(RespuestaApi<string>.createRespuestaSuccess("Producto eliminado correctamente de la Sucursal", "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }
    }
}
