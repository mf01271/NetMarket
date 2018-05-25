using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetMarketData.Domain.Entities;
using NetMarketData.Domain.Services;
using NetMarketData.Infrastructure.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarket.Tests
{
    [TestClass]
    public class CategoriaTest
    {
        CategoriaProductoService categoriaService = new CategoriaProductoService();
        CategoriaDTO categoriadto = new CategoriaDTO();
        CategoriaProducto cat = new CategoriaProducto();

        [TestMethod]
        public void ObtenerCategoriaoExisteTest()
        {
            categoriadto.idCategoria= 1;
            CategoriaProducto categoria = categoriaService.Obtenercategoria(categoriadto);
            Assert.IsNotNull(categoria);
        }

        [TestMethod]
        public void ObtenerCategoriaNoExisteTest()
        {
            categoriadto.idCategoria = 8;
            CategoriaProducto categoria = categoriaService.Obtenercategoria(categoriadto);
            Assert.IsNull(categoria);
        }
        [TestMethod]
        public void EliminarCategoriaTest()
        {            
            categoriadto.idCategoria = 2;
            categoriaService.Eliminarcategoria(categoriadto);
            cat = categoriaService.Obtenercategoria(categoriadto);
            Assert.IsNull(cat);
        }

        [TestMethod]
        public void MostrarCategoriasTest()
        {
            List<CategoriaProducto> lca = categoriaService.Obtenercategorias();
            Assert.IsNotNull(lca);
        }

    }
}
