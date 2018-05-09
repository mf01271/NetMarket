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
    
    public partial class ProductoSucursal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductoSucursal()
        {
            this.DetalleOferta = new HashSet<DetalleOferta>();
            this.DetallePedido = new HashSet<DetallePedido>();
            this.Imagen = new HashSet<Imagen>();
        }
    
        public long idProductoSucursal { get; set; }
        public long idProductoEmpresa { get; set; }
        public long idSucursal { get; set; }
        public decimal precio { get; set; }
        public Nullable<int> Stock { get; set; }
        public bool eliminado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleOferta> DetalleOferta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imagen> Imagen { get; set; }
        public virtual ProductoEmpresa ProductoEmpresa { get; set; }
        public virtual Sucursal Sucursal { get; set; }
    }
}
