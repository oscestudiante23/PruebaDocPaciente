using Hospital.Models.Comun.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models.Response
{
    public class RespuestaDoctoresResponse : ResultadoProceso
    {
        public List<DoctorResponse> LsDoctores { get; set; }
    }
}
