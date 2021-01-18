using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models.Request
{
    public class Paciente_DoctorRequest
    {
        public long Id { get; set; }
        public long PacienteId { get; set; }
        public long DoctorId { get; set; }
    }
}
