using Hospital.Models.Comun.Response;
using Hospital.Models.Request;
using Hospital.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PortalHospital.Presentacion.Models.Comun.Enumeradores;
using PortalHospital.Presentacion.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PortalHospital.Presentacion.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {

        private IConfiguration _conf;
        private string _UrlBase = string.Empty;
        public PacienteController(IConfiguration conf)
        {
            _conf = conf;
            _UrlBase = _conf.GetSection("ConfiguracionServiciosAPI:ServicioPaciente").Value;
        }

        #region Acciones
        [HttpGet("[action]")]
        public RespuestaPacientesResponse ObtenerPacientesMediador()
        {
            RespuestaPacientesResponse resp = new RespuestaPacientesResponse();
            try
            {
                HttpResponseMessage serviceResponse = HttpClientTool.ConsumirServicioRest(_UrlBase + "Pacientes/ObtenerPacientes/", HttpMethod.Get, string.Empty, string.Empty);
                if (serviceResponse.IsSuccessStatusCode)
                {
                    resp = JsonConvert.DeserializeObject<RespuestaPacientesResponse>(serviceResponse.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    resp.Estado = EnumeradorHospital.EstadoProceso.Validacion.GetHashCode();
                    resp.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Validacion.GetHashCode());
                    resp.Descripcion = "No autorizado " + serviceResponse.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                resp.Estado = EnumeradorHospital.EstadoProceso.Excepcion.GetHashCode();
                resp.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Excepcion.GetHashCode());
                resp.Descripcion = ex.Message;
            }
            return resp;
        }

        [HttpGet("[action]/{id}")]
        public RespuestaPacienteResponse ObtenerPacientePorIdMediador(long id)
        {
            RespuestaPacienteResponse resp = new RespuestaPacienteResponse();
            try
            {
                HttpResponseMessage serviceResponse = HttpClientTool.ConsumirServicioRest(_UrlBase + "Pacientes/ObtenerPacientePorId/" + id.ToString(), HttpMethod.Get, string.Empty, string.Empty);
                if (serviceResponse.IsSuccessStatusCode)
                {
                    resp = JsonConvert.DeserializeObject<RespuestaPacienteResponse>(serviceResponse.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    resp.Estado = EnumeradorHospital.EstadoProceso.Validacion.GetHashCode();
                    resp.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Validacion.GetHashCode());
                    resp.Descripcion = "No autorizado " + serviceResponse.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                resp.Estado = EnumeradorHospital.EstadoProceso.Excepcion.GetHashCode();
                resp.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Excepcion.GetHashCode());
                resp.Descripcion = ex.Message;

            }
            return resp;
        }

        [HttpPost("[action]")]
        public RespuestaEntidadLongResponse CrearPacienteMediador([FromBody] PacienteRequest entidad)
        {
            RespuestaEntidadLongResponse resp = new RespuestaEntidadLongResponse();
            try
            {
                HttpResponseMessage serviceResponse = HttpClientTool.ConsumirServicioRest(_UrlBase + "Pacientes/CrearPaciente/", HttpMethod.Post, entidad, string.Empty);
                if (serviceResponse.IsSuccessStatusCode)
                {
                    resp = JsonConvert.DeserializeObject<RespuestaEntidadLongResponse>(serviceResponse.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    resp.Estado = EnumeradorHospital.EstadoProceso.Validacion.GetHashCode();
                    resp.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Validacion.GetHashCode());
                    resp.Descripcion = "No autorizado " + serviceResponse.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                resp.Estado = EnumeradorHospital.EstadoProceso.Excepcion.GetHashCode();
                resp.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Excepcion.GetHashCode());
                resp.Descripcion = ex.Message;

            }
            return resp;
        }
        [HttpPut("[action]")]
        public RespuestaEntidadLongResponse ActualizarPacienteMediador([FromBody] PacienteRequest entidad)
        {
            RespuestaEntidadLongResponse resp = new RespuestaEntidadLongResponse();
            try
            {
                HttpResponseMessage serviceResponse = HttpClientTool.ConsumirServicioRest(_UrlBase + "Pacientes/ActualizarPaciente/", HttpMethod.Put, entidad, string.Empty);
                if (serviceResponse.IsSuccessStatusCode)
                {
                    resp = JsonConvert.DeserializeObject<RespuestaEntidadLongResponse>(serviceResponse.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    resp.Estado = EnumeradorHospital.EstadoProceso.Validacion.GetHashCode();
                    resp.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Validacion.GetHashCode());
                    resp.Descripcion = "No autorizado " + serviceResponse.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                resp.Estado = EnumeradorHospital.EstadoProceso.Excepcion.GetHashCode();
                resp.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Excepcion.GetHashCode());
                resp.Descripcion = ex.Message;

            }
            return resp;
        }

        [HttpDelete("[action]/{id}")]
        public RespuestaEntidadLongResponse BorrarPacientePorIdMediador(long id)
        {
            RespuestaEntidadLongResponse resp = new RespuestaEntidadLongResponse();
            try
            {
                HttpResponseMessage serviceResponse = HttpClientTool.ConsumirServicioRest(_UrlBase + "Pacientes/BorrarPacientePorId/" + id.ToString(), HttpMethod.Delete, string.Empty, string.Empty);
                if (serviceResponse.IsSuccessStatusCode)
                {
                    resp = JsonConvert.DeserializeObject<RespuestaEntidadLongResponse>(serviceResponse.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    resp.Estado = EnumeradorHospital.EstadoProceso.Validacion.GetHashCode();
                    resp.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Validacion.GetHashCode());
                    resp.Descripcion = "No autorizado " + serviceResponse.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                resp.Estado = EnumeradorHospital.EstadoProceso.Excepcion.GetHashCode();
                resp.NombreEstado = Enum.GetName(typeof(EnumeradorHospital.EstadoProceso), EnumeradorHospital.EstadoProceso.Excepcion.GetHashCode());
                resp.Descripcion = ex.Message;

            }
            return resp;
        }
        #endregion Acciones
    }
}
