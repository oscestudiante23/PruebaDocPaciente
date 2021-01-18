using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models.Response
{
    public class PacienteResponse
    {
        public long Id { get; set; }
        public int TipoDocumentoId { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroSeguridadSocial { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public List<DoctorResponse> LsDoctores { get; set; }
    }
}
