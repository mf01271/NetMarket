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

        [TestMethod]
        public void ObtenerCategoriaoExisteTest()
        {
            CategoriaDTO categoriadto = new CategoriaDTO();
            categoriadto.idCategoria= 1;
            CategoriaProducto categoria = categoriaService.Obtenercategoria(categoriadto);
            Assert.IsNotNull(categoria);
        }

        [TestMethod]
        public void ObtenerCategoriaNoExisteTest()
        {
            CategoriaDTO categoriadto = new CategoriaDTO();
            categoriadto.idCategoria = 8;
            CategoriaProducto categoria = categoriaService.Obtenercategoria(categoriadto);
            Assert.IsNull(categoria);
        }
    }
}
