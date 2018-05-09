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
    
    public partial class ProductoEmpresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductoEmpresa()
        {
            this.Destacados = new HashSet<Destacados>();
            this.Imagen = new HashSet<Imagen>();
            this.ProductoSucursal = new HashSet<ProductoSucursal>();
        }
    
        public long idProductoEmpresa { get; set; }
        public long idProducto { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<long> idEmpresa { get; set; }
        public bool eliminado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Destacados> Destacados { get; set; }
        public virtual Empresa Empresa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imagen> Imagen { get; set; }
        public virtual Producto Producto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductoSucursal> ProductoSucursal { get; set; }
    }
}