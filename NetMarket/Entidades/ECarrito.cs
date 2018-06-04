using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetMarket.Entidades
{
    public class ECarrito
    {
        public string mensaje { get; set; }
        public List<EProducto> productos { get; set; }
    }
}