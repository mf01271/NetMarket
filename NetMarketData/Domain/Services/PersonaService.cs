using NetMarketData.Domain.Entities;
using NetMarketData.Infrastructure.Data.DataModels;
using NetMarketData.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Domain.Services
{
    public class PersonaService
    {
        private readonly PersonaRepositorio PersonaRepositorio;

        public PersonaService()
        {
            this.PersonaRepositorio = new PersonaRepositorio();
        }

        public long GuardarPersona(PersonaDTO pe)
        {
            if (pe.id_persona == 0)
                pe.id_persona  = PersonaRepositorio.guardarPersona(pe);
            else
                PersonaRepositorio.ModificarPersona(pe);
            return pe.id_persona;
        }

        public void EliminarPersona(PersonaDTO pe)
        {
            PersonaRepositorio.EliminarPersona(pe);
        }

        public Persona ObtenerPersona(PersonaDTO pe)
        {
            return PersonaRepositorio.obtenerPersona(pe);
        }

        public List<Persona> ObtenerPersonas()
        {
            return PersonaRepositorio.obtenerPersonas();
        }

        public PersonaDTO Login(PersonaDTO pe)
        {
            try
            {
                return PersonaRepositorio.Login(pe);
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }
    }
}
