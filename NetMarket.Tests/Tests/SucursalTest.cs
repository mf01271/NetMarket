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
        SucursalDTO sucursaldto = new SucursalDTO();

        [TestMethod]
        public void ObtenerSucursalExisteTest()
        {            
            sucursaldto.idSucursal = 1;
            Sucursal sucursal = sucursalService.ObtenerSucursal(sucursaldto);
            Assert.IsNotNull(sucursal);
        }

        [TestMethod]
        public void ObtenerSucursalNoExisteTest()
        {
            sucursaldto.idSucursal = 8;
            Sucursal sucursal = sucursalService.ObtenerSucursal(sucursaldto);
            Assert.IsNull(sucursal);
        }

        [TestMethod]
        public void EliminarSucursalTest()
        {
            Sucursal sucursal = new Sucursal();
            sucursaldto.idSucursal = 2;
            sucursalService.EliminarSucursal(sucursaldto);
            sucursal = sucursalService.ObtenerSucursal(sucursaldto);
            Assert.IsNull(sucursal);
        }
    }
}
