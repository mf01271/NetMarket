using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRestNet.RequestEntity
{
    public class PersonaRequest
    {
        public int id_persona { get; set; }
        public string nombre_persona { get; set; }
        public string apellidos_persona { get; set; }
        public DateTime? fechaNac_persona { get; set; }
        public string contraseña_persona { get; set; }
        public string correo_persona { get; set; }
        public long id_tipo_persona { get; set; }
        public string telefono_movil_persona { get; set; }
        public string telefono_fijo { get; set; }
        public string ci_persona { get; set; }
        public bool eliminado_persona { get; set; }

    }
}
