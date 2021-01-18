using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models.Comun.Response
{
    public class ResultadoProceso
    {
        public int Estado { get; set; }
        public string NombreEstado { get; set; }
        public string Descripcion { get; set; }
    }
}
