using Hospital.Dominio.Enumerador;
using Hospital.Infraestructura.Query.Contrato;
using Hospital.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HospitalController : ControllerBase
    {
        private IHospitalModelQuery _hospitalModelQuery;
        public HospitalController(IHospitalModelQuery hospitalModelQuery)
        {
            _hospitalModelQuery = hospitalModelQuery;
        }


        #region Parametricas
        [HttpGet("[action]")]
        public RespuestaTipoDocumentosResponse ObtenerTipoDocumento()
        {
            RespuestaTipoDocumentosResponse respuesta = new RespuestaTipoDocumentosResponse();
            respuesta.Estado = EnumeradorHospital.EstadoProceso.Inicio.GetHashCode();
            respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Inicio.GetHashCode());
            try
            {
                respuesta.LsTipoDocumento = _hospitalModelQuery.ObtenerTipoDocumentos();
                if (respuesta.LsTipoDocumento.Count() > 0)
                {
                    respuesta.Estado = EnumeradorHospital.EstadoProceso.Ok.GetHashCode();
                    respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Ok.GetHashCode());
                }
                else
                {
                    respuesta.Estado = EnumeradorHospital.EstadoProceso.Validacion.GetHashCode();
                    respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Validacion.GetHashCode());
                    respuesta.Descripcion = "No se encontraron datos";
                }
            }
            catch (Exception ex)
            {
                respuesta.Estado = EnumeradorHospital.EstadoProceso.Excepcion.GetHashCode();
                respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Excepcion.GetHashCode());
                respuesta.Descripcion = ex.ToString();
            }
            return respuesta;
        }
        #endregion Parametricas


    }
}
