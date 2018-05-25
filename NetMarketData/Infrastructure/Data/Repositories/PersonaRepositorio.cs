using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMarketData.Infrastructure.Data.DataModels;
using Data.Infrastructure.Data.Repositories;
using NetMarketData.Domain.Entities;

namespace NetMarketData.Infrastructure.Data.Repositories
{
    class PersonaRepositorio : EFRepositorio<Persona>
    {
        public long guardarPersona(PersonaDTO pe)
        {
            Persona p = new Persona()
            {
                nombrePersona = pe.nombre_persona,
                apellidos = pe.apellidos_persona,
                fechaNacimiento = pe.fechaNac_persona,
                contraseña = pe.contraseña_persona,
                correo = pe.correo_persona,
                idTipoPersona = pe.id_tipo_persona,
                telefonoMovilPersona = pe.telefono_movil_persona,
                telefonoFijo = pe.telefono_fijo_persona,
                CiPersona = pe.ci_persona,
                eliminado = false
            };
            Add(p);
            SaveChanges();
            return p.idPersona;
        }

        public void ModificarPersona(PersonaDTO pe)
        { 
            Persona p = this.Get(pe.id_persona);
            p.nombrePersona = pe.nombre_persona;
            p.apellidos = pe.apellidos_persona;
            p.fechaNacimiento = pe.fechaNac_persona;
            p.contraseña = pe.contraseña_persona;
            p.correo = pe.correo_persona;
            p.telefonoMovilPersona = pe.telefono_movil_persona;
            p.telefonoFijo = pe.telefono_fijo_persona;
            p.CiPersona = pe.ci_persona;
            p.eliminado = pe.eliminado_persona;
            Update(p);
            SaveChanges();
        }

        public void EliminarPersona(PersonaDTO pe)
        {
            Persona p = Get(pe.id_persona);
            Remove(p);
            SaveChanges();
        }

        public Persona obtenerPersona(PersonaDTO pe)
        {
            var e = Get(pe.id_persona);
            if (e != null)
            {
                if (e.eliminado != true)
                {
                    return e;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public List<Persona> obtenerPersonas()
        {
            return GetAll().ToList();
        }
        public PersonaDTO Login (PersonaDTO pe)
        {
            try
            {
                Persona per = BuildQuery().Where(x => x.correo == pe.correo_persona && x.contraseña == pe.contraseña_persona ).First();
                if (per == null)
                {
                    return null;
                }
                else
                {
                    PersonaDTO perso = new PersonaDTO();
                    perso.id_persona = per.idPersona;
                    perso.nombre_persona = per.nombrePersona;
                    perso.apellidos_persona = per.apellidos;
                    perso.correo_persona = per.correo;
                    perso.fechaNac_persona = per.fechaNacimiento;
                    return perso;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        } 
    }
}
