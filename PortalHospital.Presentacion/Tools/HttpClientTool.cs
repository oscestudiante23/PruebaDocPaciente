using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PortalHospital.Presentacion.Tools
{
    public class HttpClientTool
    {
        public HttpClientTool()
        {
        }
        public static HttpResponseMessage ConsumirServicioRest<T>(string serviceUrl, HttpMethod Metodo, T content, string token)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string uri = serviceUrl;

            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(5);
                var request = new HttpRequestMessage(Metodo, uri);
                if (!string.IsNullOrEmpty(content.ToString()))
                {
                    HttpContent httpContent = CreateHttpContent(content);
                    request.Content = httpContent;
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                }

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage asyncRes = client.SendAsync(request).Result;

                return asyncRes;
            }
        }
        private static HttpContent CreateHttpContent<T>(T content)
        {
            string json = JsonConvert.SerializeObject(content);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
