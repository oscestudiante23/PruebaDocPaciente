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
    public class HospitalController : ControllerBase
    {
        private IConfiguration _conf;
        private string _UrlBase = string.Empty;
        public HospitalController(IConfiguration conf)
        {
            _conf = conf;
            _UrlBase = _conf.GetSection("ConfiguracionServiciosAPI:ServicioHospital").Value;
        }

        #region Acciones
        [HttpGet("[action]")]
        public RespuestaTipoDocumentosResponse ObtenerTipoDocumentoMediador()
        {
            RespuestaTipoDocumentosResponse resp = new RespuestaTipoDocumentosResponse();
            try
            {
                HttpResponseMessage serviceResponse = HttpClientTool.ConsumirServicioRest(_UrlBase + "Hospital/ObtenerTipoDocumento/", HttpMethod.Get, string.Empty, string.Empty);
                if (serviceResponse.IsSuccessStatusCode)
                {
                    resp = JsonConvert.DeserializeObject<RespuestaTipoDocumentosResponse>(serviceResponse.Content.ReadAsStringAsync().Result);
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
