using Hospital.Models.Comun.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models.Response
{
    public class RespuestaDoctorResponse : ResultadoProceso
    {
        public DoctorResponse Doctor { get; set; }
    }
}
