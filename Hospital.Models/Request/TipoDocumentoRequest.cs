using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models.Request
{
    public class TipoDocumentoRequest
    {
        public int Id { get; set; }
        public string NombreCorto { get; set; }
        public string Nombre { get; set; }
    }
}
