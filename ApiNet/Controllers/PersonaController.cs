using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Web.Http;
using NetMarketData.Domain.Entities;
using NetMarketData.Infrastructure.Data.DataModels;
using ApiNet.Models;
using NetMarketData.Domain.Services;

namespace ApiNet.Controllers
{
    public class PersonaController : ApiController
    {
        private readonly PersonaService personaServicio = new PersonaService();

        [Route("api/Persona/personas")]
        [HttpPost]
        public IHttpActionResult personas()
        {
            try
            {
                List<PersonaDTO> personas = new List<PersonaDTO>();
                var listp = personaServicio.ObtenerPersonas();
                foreach (var p in listp)
                {
                    personas.Add(new PersonaDTO
                    {
                        id_persona = p.idPersona,
                        nombre_persona = p.nombrePersona,
                        fechaNac_persona = p.fechaNacimiento,
                        contraseña_persona = p.contraseña,
                        correo_persona =p.correo,
                        id_tipo_persona = p.idTipoPersona,
                        telefono_fijo_persona = p.telefonoFijo,
                        telefono_movil_persona = p.telefonoMovilPersona,
                        ci_persona = p.CiPersona,
                        eliminado_persona = p.eliminado
                    });
                }

                return Ok(RespuestaApi<List<PersonaDTO>>.createRespuestaSuccess(personas, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }

        }

    }
}
