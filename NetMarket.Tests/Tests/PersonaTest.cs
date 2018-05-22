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
        PersonaDTO personadto = new PersonaDTO();
        Persona persona = new Persona();

        [TestMethod]
        public void ObtenerPersonaExisteTest()
        {
            personadto.id_persona = 6;
            persona = personaService.ObtenerPersona(personadto);
            Assert.IsNotNull(persona);
        }
        [TestMethod]
        public void ObtenerPersonaNoExisteTest()
        {
            personadto.id_persona = 8;
            persona = personaService.ObtenerPersona(personadto);
            Assert.IsNull(persona);
        }

        [TestMethod]
        public void EliminarPersonaTest()
        {
            personadto.id_persona = 7;
            personaService.EliminarPersona(personadto);
            persona = personaService.ObtenerPersona(personadto);
            Assert.IsNull(persona);
        }
    }
}
