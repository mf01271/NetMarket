using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetMarketData.Domain.Services;
using NetMarketData.Domain.Entities;
using NetMarketData.Infrastructure.Data.DataModels;

namespace NetMarket.Tests
{
    
    [TestClass]
    public class EmpresaTest
    {
        EmpresaService empresaService = new EmpresaService();
        EmpresaDTO empresadto = new EmpresaDTO();

        [TestMethod]
        public void ObtenerEmpresaExisteTest()
        {
            empresadto.idEmpresa = 1;
            Empresa empresa = empresaService.ObtenerEmpresa(empresadto);
            Assert.IsNotNull(empresa);
        }
        [TestMethod]
        public void ObtenerEmpresanNoExisteTest()
        {
            empresadto.idEmpresa = 8;
            Empresa empresa = empresaService.ObtenerEmpresa(empresadto);
            Assert.IsNull(empresa);
        }

        [TestMethod]
        public void EliminarEmpresaTest()
        {
            Empresa empresa = new Empresa();
            empresadto.idEmpresa = 2;
            empresaService.EliminarEmpresa(empresadto);
            empresa = empresaService.ObtenerEmpresa(empresadto);
            Assert.IsNull(empresa);
        }

    }
}
