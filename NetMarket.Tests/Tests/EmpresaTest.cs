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

        [TestMethod]
        public void ObtenerEmpresaExisteTest()
        {
            EmpresaDTO empresadto = new EmpresaDTO();
            empresadto.idEmpresa = 1;
            Empresa empresa = empresaService.ObtenerEmpresa(empresadto);
            Assert.IsNotNull(empresa);
        }
        [TestMethod]
        public void ObtenerEmpresanNoExisteTest()
        {
            EmpresaDTO empresadto = new EmpresaDTO();
            empresadto.idEmpresa = 8;
            Empresa empresa = empresaService.ObtenerEmpresa(empresadto);
            Assert.IsNull(empresa);
        }

    }
}
