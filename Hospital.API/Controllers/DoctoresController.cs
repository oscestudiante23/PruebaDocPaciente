using Hospital.Dominio.Enumerador;
using Hospital.Infraestructura.Query.Contrato;
using Hospital.Models.Comun.Response;
using Hospital.Models.Request;
using Hospital.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        private IHospitalModelQuery _hospitalModelQuery;
        public DoctoresController(IHospitalModelQuery hospitalModelQuery)
        {
            _hospitalModelQuery = hospitalModelQuery;
        }

        #region Acciones
        [HttpGet("[action]")]
        public RespuestaDoctoresResponse ObtenerDoctores()
        {
            RespuestaDoctoresResponse respuesta = new RespuestaDoctoresResponse();
            respuesta.Estado = EnumeradorHospital.EstadoProceso.Inicio.GetHashCode();
            respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Inicio.GetHashCode());
            try
            {
                respuesta.LsDoctores = _hospitalModelQuery.ObtenerDoctores();
                if (respuesta.LsDoctores.Count() > 0)
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

        [HttpGet("[action]/{id}")]
        public RespuestaDoctorResponse ObtenerDoctorPorId(long id)
        {
            RespuestaDoctorResponse respuesta = new RespuestaDoctorResponse();
            respuesta.Estado = EnumeradorHospital.EstadoProceso.Inicio.GetHashCode();
            respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Inicio.GetHashCode());
            try
            {
                respuesta.Doctor = _hospitalModelQuery.ObtenerDoctorPorId(id);
                if (respuesta.Doctor != null)
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

        [HttpPost("[action]")]
        public RespuestaEntidadLongResponse CrearDoctor([FromBody] DoctorRequest entidad)
        {
            RespuestaEntidadLongResponse respuesta = new RespuestaEntidadLongResponse();
            respuesta.Estado = EnumeradorHospital.EstadoProceso.Inicio.GetHashCode();
            respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Inicio.GetHashCode());
            try
            {
                respuesta.Id = _hospitalModelQuery.CrearDoctor(entidad);
                if (respuesta.Id > 0)
                {
                    respuesta.Estado = EnumeradorHospital.EstadoProceso.Ok.GetHashCode();
                    respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Ok.GetHashCode());
                }
                else
                {
                    respuesta.Estado = EnumeradorHospital.EstadoProceso.Validacion.GetHashCode();
                    respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Validacion.GetHashCode());
                    respuesta.Descripcion = "No se logro crear el registro";
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
        #endregion Acciones

    }
}
