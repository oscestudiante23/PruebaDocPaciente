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
    public class DoctorController : ControllerBase
    {
        private IConfiguration _conf;
        private string _UrlBase = string.Empty;
        public DoctorController(IConfiguration conf)
        {
            _conf = conf;
            _UrlBase = _conf.GetSection("ConfiguracionServiciosAPI:ServicioDoctor").Value;
        }

        [HttpGet("[action]")]
        public RespuestaDoctoresResponse ObtenerDoctoresMediador()
        {
            RespuestaDoctoresResponse resp = new RespuestaDoctoresResponse();
            try
            {
                HttpResponseMessage serviceResponse = HttpClientTool.ConsumirServicioRest(_UrlBase + "Doctores/ObtenerDoctores/", HttpMethod.Get, string.Empty, string.Empty);
                if (serviceResponse.IsSuccessStatusCode)
                {
                    resp = JsonConvert.DeserializeObject<RespuestaDoctoresResponse>(serviceResponse.Content.ReadAsStringAsync().Result);
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
        public RespuestaDoctorResponse ObtenerDoctorPorIdMediador(long id)
        {
            RespuestaDoctorResponse resp = new RespuestaDoctorResponse();
            try
            {
                HttpResponseMessage serviceResponse = HttpClientTool.ConsumirServicioRest(_UrlBase + "Doctores/ObtenerDoctorPorId/" + id.ToString(), HttpMethod.Get, string.Empty, string.Empty);
                if (serviceResponse.IsSuccessStatusCode)
                {
                    resp = JsonConvert.DeserializeObject<RespuestaDoctorResponse>(serviceResponse.Content.ReadAsStringAsync().Result);
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
        public RespuestaEntidadLongResponse CrearDoctorMediador([FromBody] DoctorRequest entidad)
        {
            RespuestaEntidadLongResponse resp = new RespuestaEntidadLongResponse();
            try
            {
                HttpResponseMessage serviceResponse = HttpClientTool.ConsumirServicioRest(_UrlBase + "Doctores/CrearDoctor/", HttpMethod.Post, entidad, string.Empty);
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

    }
}
