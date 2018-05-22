using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetMarketData.Domain.Services;
using NetMarketData.Domain.Entities;
using NetMarketData.Infrastructure.Data.DataModels;

namespace NetMarket.Tests
{
    [TestClass]
    public class ProductoTest
    {
        ProductoService productoService = new ProductoService();

        [TestMethod]
        public void ObtenerProductoExisteTest()
        {
            ProductoDTO productodto = new ProductoDTO();
            productodto.idProducto = 1;
            Producto producto = productoService.Obtenerproducto(productodto);
            Assert.IsNotNull(producto);
        }
        [TestMethod]
        public void ObtenerProductoNoExisteTest()
        {
            ProductoDTO productodto = new ProductoDTO();
            productodto.idProducto = 8;
            Producto producto = productoService.Obtenerproducto(productodto);
            Assert.IsNull(producto);
        }
    }
}
