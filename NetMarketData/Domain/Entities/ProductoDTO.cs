﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Domain.Entities
{
    public class ProductoDTO
    {
        public long idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public long idCategoria { get; set; }
        public string nombrecategoria { get; set; }
        public string rutaimagen { get; set; }
    }
}
