using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetMarketData.Domain.Services;

namespace NetMarket.Tests
{
    [TestClass]
    public class ProductoTest
    {
        ProductoService productoService = new ProductoService();

        [TestMethod]
        public void ObtenerProductoExisteTest()
        {
            productoService.Obtenerproducto(1);
            Assert.IsNotNull(producto);
        }
        [TestMethod]
        public void ObtenerProductoNoExisteTest()
        {
            productoService.Obtenerproducto(1);
            Assert.IsNull(producto);
        }
        [TestMethod]
        public void GuardarProductoTest()
        {
            pkProducto = 0;
            pkProducto = productoService.Guardarproducto(pkProducto, "nombre", "descripcion"...);
            var producto = productoService.Obtenerproducto(pkProducto);
            Assert.AreEqual(producto.nombreProducto, "Test Modificado");
        }
    }
}
