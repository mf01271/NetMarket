using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetMarketData.Domain.Services;
using NetMarketData.Domain.Entities;
using NetMarketData.Infrastructure.Data.DataModels;

namespace NetMarket.Tests.Tests
{
    [TestClass]
    public class ProductoSucursalTest
    {

        ProductoSucursalService productoSucursalService = new ProductoSucursalService();
        ProductoSucursalDTO productoSucursaldto = new ProductoSucursalDTO();
        ProductoSucursal productoSucursal = new ProductoSucursal();

        [TestMethod]
        public void ObtenerProductoSucursalExisteTest()
        {
            productoSucursaldto.idProductoSucursal = 1;
            ProductoSucursal productoSucursal = productoSucursalService.Obtenerproducto(productoSucursaldto);
            Assert.IsNotNull(productoSucursal);
        }

        [TestMethod]
        public void ObtenerProductoSucursalNoExisteTest()
        {
            productoSucursaldto.idProductoEmpresa = 8;
            ProductoSucursal productoSucursal = productoSucursalService.Obtenerproducto(productoSucursaldto);
            Assert.IsNull(productoSucursal);
        }

        [TestMethod]
        public void EliminarProductoSucursalTest()
        {
            productoSucursaldto.idProductoSucursal = 2;
            productoSucursalService.Eliminarproducto(productoSucursaldto);
            productoSucursal = productoSucursalService.Obtenerproducto(productoSucursaldto);
            Assert.IsNull(productoSucursal);
        }
        [TestMethod]
        public void MostrarProductoSucursalTest()
        {
            List<ProductoSucursal> lproductoSuc = productoSucursalService.Obtenerproductos(productoSucursaldto);
            Assert.IsNotNull(lproductoSuc);
        }
    }
}
