//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleCompra
    {
        public int IdDetalleCompra { get; set; }
        public int FKIdProducto { get; set; }
        public int FKIdProveedor { get; set; }
        public int IdCompra { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal IVA { get; set; }
        public decimal SubTotal { get; set; }
    
        public virtual Compra Compra { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
