﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NetMarketDBEntities1 : DbContext
    {
        public NetMarketDBEntities1()
            : base("name=NetMarketDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CategoriaProducto> CategoriaProducto { get; set; }
        public virtual DbSet<Destacados> Destacados { get; set; }
        public virtual DbSet<DetalleHorario> DetalleHorario { get; set; }
        public virtual DbSet<DetalleOferta> DetalleOferta { get; set; }
        public virtual DbSet<DetallePedido> DetallePedido { get; set; }
        public virtual DbSet<Dia> Dia { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Encargado> Encargado { get; set; }
        public virtual DbSet<Imagen> Imagen { get; set; }
        public virtual DbSet<oferta> oferta { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<ProductoEmpresa> ProductoEmpresa { get; set; }
        public virtual DbSet<ProductoSucursal> ProductoSucursal { get; set; }
        public virtual DbSet<SeguimientoSolicitudPedido> SeguimientoSolicitudPedido { get; set; }
        public virtual DbSet<SolicitudPedido> SolicitudPedido { get; set; }
        public virtual DbSet<SolicitudPedidoEstado> SolicitudPedidoEstado { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<TipodeEnvio> TipodeEnvio { get; set; }
        public virtual DbSet<TipodePago> TipodePago { get; set; }
        public virtual DbSet<TipoPersona> TipoPersona { get; set; }
        public virtual DbSet<Turno> Turno { get; set; }
    }
}
