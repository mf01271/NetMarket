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
    public class TipoPersonaTest
    {

        TipoPersonaService tipoPersonaService = new TipoPersonaService();
        TipoPersonaDTO tipoPersonadto = new TipoPersonaDTO();
        TipoPersona tipoPersona = new TipoPersona();

        //[TestMethod]
        //public void ObtenerTipoPersonaExisteTest()
        //{
        //    tipoPersonadto.idTipo = 1;
        //    tipoPersona = tipoPersonaService.ObtenerTipo(tipoPersonadto);
        //    Assert.IsNotNull(tipoPersonadto);
        //}

        //[TestMethod]
        //public void ObtenerProductoSucursalNoExisteTest()
        //{
        //    tipoPersonadto.idTipo = 1;
        //    tipoPersona = tipoPersonaService.ObtenerTipo(tipoPersonadto);
        //    Assert.IsNull(tipoPersonadto);
        //}

        //[TestMethod]
        //public void EliminarProductoSucursalTest()
        //{
        //    tipoPersonadto.idTipo = 2;
        //    tipoPersonaService.EliminarTipo(tipoPersonadto);
        //    tipoPersonaService = tipoPersonaService.ObtenerTipo(tipoPersonadto);
        //    Assert.IsNull(tipoPersonadto);
        //}
        [TestMethod]
        public void MostrarTipoPersonaTest()
        {
            List<TipoPersona> ltipPer = tipoPersonaService.ObtenerTipos();
            Assert.IsNotNull(ltipPer);
        }
    }
}
