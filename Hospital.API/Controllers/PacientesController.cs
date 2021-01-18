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
    public class PacientesController : ControllerBase
    {
        private IHospitalModelQuery _hospitalModelQuery;
        public PacientesController(IHospitalModelQuery hospitalModelQuery)
        {
            _hospitalModelQuery = hospitalModelQuery;
        }

        #region Acciones
        [HttpGet("[action]")]
        public RespuestaPacientesResponse ObtenerPacientes()
        {
            RespuestaPacientesResponse respuesta = new RespuestaPacientesResponse();
            respuesta.Estado = EnumeradorHospital.EstadoProceso.Inicio.GetHashCode();
            respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Inicio.GetHashCode());
            try
            {
                respuesta.LsPacientes = _hospitalModelQuery.ObtenerPacientes();
                if (respuesta.LsPacientes.Count() > 0)
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
        public RespuestaPacienteResponse ObtenerPacientePorId(long id)
        {
            RespuestaPacienteResponse respuesta = new RespuestaPacienteResponse();
            respuesta.Estado = EnumeradorHospital.EstadoProceso.Inicio.GetHashCode();
            respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Inicio.GetHashCode());
            try
            {
                respuesta.Paciente = _hospitalModelQuery.ObtenerPacientePorId(id);
                if (respuesta.Paciente != null)
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
        public RespuestaEntidadLongResponse CrearPaciente([FromBody] PacienteRequest entidad)
        {
            RespuestaEntidadLongResponse respuesta = new RespuestaEntidadLongResponse();
            respuesta.Estado = EnumeradorHospital.EstadoProceso.Inicio.GetHashCode();
            respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Inicio.GetHashCode());
            try
            {
                respuesta.Id = _hospitalModelQuery.CrearPaciente(entidad);
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

        [HttpPut("[action]")]
        public RespuestaEntidadLongResponse ActualizarPaciente([FromBody] PacienteRequest entidad)
        {
            RespuestaEntidadLongResponse respuesta = new RespuestaEntidadLongResponse();
            respuesta.Estado = EnumeradorHospital.EstadoProceso.Inicio.GetHashCode();
            respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Inicio.GetHashCode());
            try
            {
                respuesta.Id = _hospitalModelQuery.ActualizarPaciente(entidad);
                if (respuesta.Id > 0)
                {
                    respuesta.Estado = EnumeradorHospital.EstadoProceso.Ok.GetHashCode();
                    respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Ok.GetHashCode());
                }
                else
                {
                    respuesta.Estado = EnumeradorHospital.EstadoProceso.Validacion.GetHashCode();
                    respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Validacion.GetHashCode());
                    respuesta.Descripcion = "No se logro actualizar el registro";
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

        [HttpDelete("[action]/{id}")]
        public RespuestaEntidadLongResponse BorrarPacientePorId(long id)
        {
            RespuestaEntidadLongResponse respuesta = new RespuestaEntidadLongResponse();
            respuesta.Estado = EnumeradorHospital.EstadoProceso.Inicio.GetHashCode();
            respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Inicio.GetHashCode());
            try
            {
                respuesta.Id = _hospitalModelQuery.BorrarPacientePorId(id);
                if (respuesta.Id > 0)
                {
                    respuesta.Estado = EnumeradorHospital.EstadoProceso.Ok.GetHashCode();
                    respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Ok.GetHashCode());
                }
                else
                {
                    respuesta.Estado = EnumeradorHospital.EstadoProceso.Validacion.GetHashCode();
                    respuesta.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Validacion.GetHashCode());
                    respuesta.Descripcion = "No se logro borrar el registro";
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
