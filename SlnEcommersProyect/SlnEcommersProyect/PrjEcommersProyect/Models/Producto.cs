using System;
using System.Collections.Generic;

namespace PrjEcommersProyect.Models
{
    public partial class Producto
    {
        public string IdProducto { get; set; } = "";
        public string NombreProducto { get; set; } = "";
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Marca { get; set; } = "";
        public int IdCategoria { get; set; }

        public virtual Categoria? IdCategoriaNavigation { get; set; }
    }
}
