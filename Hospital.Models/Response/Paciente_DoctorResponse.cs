using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models.Response
{
    public class Paciente_DoctorResponse
    {
        public long Id { get; set; }
        public long PacienteId { get; set; }
        public long DoctorId { get; set; }
    }
}
