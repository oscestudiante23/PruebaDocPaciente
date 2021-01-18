using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalHospital.Presentacion.Models.Comun.Enumeradores
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
