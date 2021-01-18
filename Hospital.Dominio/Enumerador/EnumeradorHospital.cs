using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Dominio.Enumerador
{
    public class EnumeradorHospital
    {
        public enum EstadoProceso
        {
            Ok = 1,
            Validacion = 2,
            Excepcion = 3,
            Inicio = 4
        }
    }
}
