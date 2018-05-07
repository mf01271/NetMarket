using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Domain.Entities
{
    public class PersonaDTO
    {
        public long id_persona { get; set; }
        public string nombre_persona { get; set; }
        public string apellidos_persona { get; set; }
        public DateTime? fechaNac_persona { get; set; }
        public string contraseña_persona { get; set; }
        public string correo_persona { get; set; }
        public int id_tipo_persona { get; set; }
        public string tipo_persona { get; set; }
        public string telefono_movil_persona { get; set; }
        public string telefono_fijo_persona { get; set; }
        public string ci_persona { get; set; }
        public bool eliminado_persona { get; set; }

    }
}
