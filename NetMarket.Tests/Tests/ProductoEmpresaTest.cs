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
    public class ProductoEmpresaTest
    {
        ProductoEmpresaService productoEmpresaService = new ProductoEmpresaService();
        ProductoEmpresaDTO productoEmpresadto = new ProductoEmpresaDTO();
        ProductoEmpresa productoEmpresa = new ProductoEmpresa();

        [TestMethod]
        public void ObtenerProductoEmpresaExisteTest()
        {
            productoEmpresadto.idProductoEmpresa = 1;
            ProductoEmpresa productoEmpresa = productoEmpresaService.Obtenerproducto(productoEmpresadto);
            Assert.IsNotNull(productoEmpresa);
        }

        [TestMethod]
        public void ObtenerProductoEmpresaNoExisteTest()
        {
            productoEmpresadto.idProductoEmpresa = 10;
            ProductoEmpresa productoEmpresa = productoEmpresaService.Obtenerproducto(productoEmpresadto);
            Assert.IsNull(productoEmpresa);
        }

        [TestMethod]
        public void EliminarProductoEmpresaTest()
        {
            productoEmpresadto.idProductoEmpresa = 2;
            productoEmpresaService.Eliminarproducto(productoEmpresadto);
            productoEmpresa = productoEmpresaService.Obtenerproducto(productoEmpresadto);
            Assert.IsNull(productoEmpresa);
        }
        [TestMethod]
        public void MostrarProductoEmpresaTest()
        {
            List<ProductoEmpresa> lperEmpr = productoEmpresaService.Obtenerproductos(productoEmpresadto);
            Assert.IsNotNull(lperEmpr);
        }
    }
}
