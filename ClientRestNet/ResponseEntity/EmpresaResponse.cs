using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRestNet.ResponseEntity
{
    public class EmpresaResponse
    {
        public long idEmpresa { get; set; }
        public string nombreEmpresa { get; set; }
        public string nit { get; set; }
        public string razonSocial { get; set; }
        public string direccion { get; set; }
        public bool eliminado { get; set; } 
    }
}
