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
    
    public partial class SolicitudPedidoEstado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SolicitudPedidoEstado()
        {
            this.SeguimientoSolicitudPedido = new HashSet<SeguimientoSolicitudPedido>();
            this.SolicitudPedido = new HashSet<SolicitudPedido>();
        }
    
        public long idSolicitudPedidoEstado { get; set; }
        public string nombreSolicitudPedidoEstado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeguimientoSolicitudPedido> SeguimientoSolicitudPedido { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolicitudPedido> SolicitudPedido { get; set; }
    }
}
