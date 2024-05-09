﻿
namespace PrjEcommersProyect.Models
{
    public class Carrito
    {
        public string Codigo { get; set; } = "";
        public string Nombre { get; set; } = "";
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Importe
        {
            get
            {
                return Precio * Cantidad;
            }
        }

        
    }
}
