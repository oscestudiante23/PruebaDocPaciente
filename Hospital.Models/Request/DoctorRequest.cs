using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models.Request
{
    public class DoctorRequest
    {
        public long Id { get; set; }
        public int TipoDocumentoId { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreCompleto { get; set; }
        public string Especialidad { get; set; }
        public string NumeroCredencial { get; set; }
        public string NombreHospital { get; set; }
        public List<long> LsPacientes { get; set; }

    }
}
