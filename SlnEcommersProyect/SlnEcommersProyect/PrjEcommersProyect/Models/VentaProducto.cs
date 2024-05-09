using System;
using System.Collections.Generic;

namespace PrjEcommersProyect.Models
{
    public partial class VentaProducto
    {
        public int IdVentaProductos { get; set; }
        public string? NombreProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
    }
}
