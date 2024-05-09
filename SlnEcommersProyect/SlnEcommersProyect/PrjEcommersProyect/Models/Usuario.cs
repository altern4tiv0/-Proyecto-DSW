using System;
using System.Collections.Generic;

namespace PrjEcommersProyect.Models
{
    public partial class Usuario
    {

        public int NroReg { get; set; }
        public string LoginUsu { get; set; } = null!;
        public string ClaveUsu { get; set; } = null!;
    }
}
