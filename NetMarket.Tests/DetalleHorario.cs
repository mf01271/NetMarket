//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetMarket.Tests
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleHorario
    {
        public long idTurno { get; set; }
        public long idDia { get; set; }
        public bool estado { get; set; }
    
        public virtual Dia Dia { get; set; }
        public virtual Turno Turno { get; set; }
    }
}
