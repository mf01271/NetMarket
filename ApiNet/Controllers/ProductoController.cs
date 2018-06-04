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
    public class ProductoController : ApiController
    {
        private readonly ProductoService productoServicio = new ProductoService();
        private readonly ProductoEmpresaService productoempresaServicio = new ProductoEmpresaService();
        private readonly ProductoSucursalService productosucursalServicio = new ProductoSucursalService();
        private readonly CategoriaProductoService categoriaServicio = new CategoriaProductoService();
        private readonly EmpresaService empresaServicio = new EmpresaService();
        private readonly SucursalService sucursalServicio = new SucursalService();
        private readonly ImagenService imagenServicio = new ImagenService();

        [Route("api/producto/verproductos")]
        [HttpPost]
        public IHttpActionResult verproductos([FromBody] ProductoDTO p)
        {
            try
            {
                List<ProductoDTO> productos = new List<ProductoDTO>();
                var listpro = productoServicio.Obtenerproductos(p);
                foreach (var pr in listpro)
                {
                    CategoriaDTO c = new CategoriaDTO()
                    {
                        idCategoria = pr.idCategoria
                    };
                    ImagenDTO i = new ImagenDTO()
                    {
                        idProducto = pr.idProducto,
                        principal = true
                    };
                    productos.Add(new ProductoDTO
                    {
                        idProducto = pr.idProducto,
                        nombre = pr.nombreProducto,
                        descripcionCorta = pr.descripcionCortaProducto,
                        descripcionLarga = pr.descripcionLargaProducto,
                        idCategoria = pr.idCategoria,
                        nombrecategoria = categoriaServicio.Obtenercategoria(c).nombreCategoria,
                        rutaimagen = imagenServicio.Obtenerimagen(i)

                    });
                }

                return Ok(RespuestaApi<List<ProductoDTO>>.createRespuestaSuccess(productos, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/producto/guardarproducto")]
        [HttpPost]
        public IHttpActionResult guardarproducto([FromBody] ProductoDTO p)
        {
            try
            {
                long pk = productoServicio.Guardarproducto(p);

                return Ok(RespuestaApi<long>.createRespuestaSuccess(pk, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/producto/verproducto")]
        [HttpPost]
        public IHttpActionResult verproducto([FromBody] ProductoDTO p)
        {
            try
            {
                Producto pro = new Producto();
                ProductoDTO producto = new ProductoDTO();
                pro = productoServicio.Obtenerproducto(p);

                List<EmpresaDTO> lempresas = new List<EmpresaDTO>();
                List<SucursalDTO> lsucursales = new List<SucursalDTO>();

                ProductoEmpresaDTO pe = new ProductoEmpresaDTO();
                pe.idProducto = pro.idProducto;
                var prems = productoempresaServicio.obtenerProductosEmpresaByProductoID(pe);
                foreach (var pre in prems)
                {
                    EmpresaDTO objempresa = new EmpresaDTO();
                    objempresa.idEmpresa = Convert.ToInt64(pre.idEmpresa);
                    lempresas.Add(new EmpresaDTO()
                    {
                        idEmpresa = Convert.ToInt64(pre.idEmpresa),
                        nombrempresa = empresaServicio.ObtenerEmpresa(objempresa).nombreEmpresa,
                        idproductoempresa = pre.idProductoEmpresa
                    });
                }
                foreach(var e in lempresas)
                {
                    ProductoSucursalDTO ps = new ProductoSucursalDTO();
                    ps.idProductoEmpresa = e.idproductoempresa;
                    var prsus = productosucursalServicio.obtenerProductosSucursalByProductoEmpresaID(ps);
                    foreach (var prs in prsus)
                    {
                        SucursalDTO objsucursal = new SucursalDTO();
                        objsucursal.idSucursal = Convert.ToInt64(prs.idSucursal);
                        lsucursales.Add(new SucursalDTO()
                        {
                            idSucursal = Convert.ToInt64(prs.idSucursal),
                            nombre = sucursalServicio.ObtenerSucursal(objsucursal).nombreSucursal,
                            idProductoSucursal = prs.idProductoSucursal,
                            idProductoEmpresa=prs.idProductoEmpresa,
                            precioProductoSucursal=prs.precio
                        });
                    }
                }
                

                CategoriaDTO c = new CategoriaDTO()
                {
                    idCategoria = pro.idCategoria
                };
                ImagenDTO i = new ImagenDTO()
                {
                    idProducto = pro.idProducto,
                    principal = true
                };
                producto.nombre = pro.nombreProducto;
                producto.descripcionCorta = pro.descripcionCortaProducto;
                producto.descripcionLarga = pro.descripcionLargaProducto;
                producto.idCategoria = pro.idCategoria;
                producto.nombrecategoria = categoriaServicio.Obtenercategoria(c).nombreCategoria;
                producto.rutaimagen = imagenServicio.Obtenerimagen(i);
                producto.empresas = lempresas;
                producto.sucursales = lsucursales;

                return Ok(RespuestaApi<ProductoDTO>.createRespuestaSuccess(producto, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/producto/eliminarproducto")]
        [HttpPost]
        public IHttpActionResult eliminarproducto([FromBody] ProductoDTO p)
        {
            try
            {
                productoServicio.Eliminarproducto(p);

                return Ok(RespuestaApi<string>.createRespuestaSuccess("Producto eliminado correctamente", "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }
    }
}
