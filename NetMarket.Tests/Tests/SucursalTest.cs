using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetMarketData.Domain.Entities;
using NetMarketData.Infrastructure.Data.DataModels;
using NetMarketData.Domain.Services;

namespace NetMarket.Tests.Tests
{
    
    [TestClass]
    public class SucursalTest
    {
        SucursalService sucursalService = new SucursalService();

        [TestMethod]
        public void ObtenerSucursalExisteTest()
        {
            SucursalDTO sucursaldto = new SucursalDTO();
            sucursaldto.idSucursal = 1;
            Sucursal sucursal = sucursalService.ObtenerSucursal(sucursaldto);
            Assert.IsNotNull(sucursal);
        }

        [TestMethod]
        public void ObtenerSucursalNoExisteTest()
        {
            SucursalDTO sucursaldto = new SucursalDTO();
            sucursaldto.idSucursal = 8;
            Sucursal sucursal = sucursalService.ObtenerSucursal(sucursaldto);
            Assert.IsNull(sucursal);
        }
    }
}
