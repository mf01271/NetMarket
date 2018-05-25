using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetMarketData.Domain.Services;
using NetMarketData.Domain.Entities;
using NetMarketData.Infrastructure.Data.DataModels;
using System.Collections.Generic;

namespace NetMarket.Tests
{
    [TestClass]
    public class ProductoTest
    {
        ProductoService productoService = new ProductoService();
        ProductoDTO productodto = new ProductoDTO();
        Producto producto = new Producto();

        [TestMethod]
        public void ObtenerProductoExisteTest()
        {           
            productodto.idProducto = 1;
            Producto producto = productoService.Obtenerproducto(productodto);
            Assert.IsNotNull(producto);
        }
        [TestMethod]
        public void ObtenerProductoNoExisteTest()
        {
            productodto.idProducto = 8;
            Producto producto = productoService.Obtenerproducto(productodto);
            Assert.IsNull(producto);
        }
        [TestMethod]
        public void EliminarProductoTest()
        {
            Producto producto = new Producto();
            productodto.idProducto = 2;
            productoService.Eliminarproducto(productodto);
            producto = productoService.Obtenerproducto(productodto);
            Assert.IsNull(producto);
        }
        [TestMethod]
        public void MostrarProductoTest()
        {
            List<Producto> lprod = productoService.Obtenerproductos(productodto);
            Assert.IsNotNull(lprod);
        }
    }
}
