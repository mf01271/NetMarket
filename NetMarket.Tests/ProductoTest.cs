using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetMarketData.Domain.Services;
using NetMarketData.Domain.Entities;

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
            productoService.Obtenerproducto(productodto);
            Assert.IsNotNull(productodto);
        }
        [TestMethod]
        public void ObtenerProductoNoExisteTest()
        {
            ProductoDTO productodto = new ProductoDTO();
            productodto.idProducto = 8;
            productoService.Obtenerproducto(productodto);
            Assert.IsNull(productodto);
        }
        //[TestMethod]
        //public void GuardarProductoTest()
        //{
        //    ProductoDTO productodto = new ProductoDTO();
        //    productodto.idProducto = 1;
        //    productoService.Obtenerproducto(productodto);
        //    productodto.idProducto = 0;
        //    productodto.idProducto = productoService.Guardarproducto(productodto);
        //    var producto = productoService.Obtenerproducto(productodto.idProducto);
        //    Assert.AreEqual(producto.nombreProducto, "Test Modificado");
        //}
    }
}
