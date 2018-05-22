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
    public class PersonaTest
    {
        PersonaService personaService = new PersonaService();

        [TestMethod]
        public void ObtenerPersonaExisteTest()
        {
            PersonaDTO personadto = new PersonaDTO();
            personadto.id_persona = 2;
            Persona persona = personaService.ObtenerPersona(personadto);
            Assert.IsNotNull(persona);
        }
        [TestMethod]
        public void ObtenerPersonaNoExisteTest()
        {
            PersonaDTO personadto = new PersonaDTO();
            personadto.id_persona = 8;
            Persona persona = personaService.ObtenerPersona(personadto);
            Assert.IsNull(persona);
        }
    }
}
