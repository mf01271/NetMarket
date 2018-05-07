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

        public long GuardarPersona(string nombre_persona, string apellidos_persona, DateTime fechaNac_persona, string contraseña_persona,
            string correo_persona, int id_tipo_persona, string telefono_movil_persona, string telefono_fijo, string ci_persona, bool eliminado, long pk = 0)
        {
            if (pk == 0)
                pk = PersonaRepositorio.guardarPersona(nombre_persona, apellidos_persona, fechaNac_persona, contraseña_persona,
                correo_persona, id_tipo_persona, telefono_movil_persona, telefono_fijo, ci_persona);
            else
                PersonaRepositorio.ModificarPersona(pk, nombre_persona, apellidos_persona, fechaNac_persona, contraseña_persona,
                correo_persona, telefono_movil_persona, telefono_fijo, ci_persona, eliminado);
            return pk;
        }

        public void EliminarPersona(long pk)
        {
            PersonaRepositorio.EliminarPersona(pk);
        }

        public Persona ObtenerPersona(long pk)
        {
            return PersonaRepositorio.obtenerPersona(pk);
        }

        public List<Persona> ObtenerPersonas()
        {
            return PersonaRepositorio.obtenerPersonas();
        }

    }
}
