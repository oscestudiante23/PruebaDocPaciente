using Hospital.Models.Comun.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models.Response
{
    public class RespuestaTipoDocumentosResponse : ResultadoProceso
    {
        public List<TipoDocumentoResponse> LsTipoDocumento { get; set; }
    }
}
