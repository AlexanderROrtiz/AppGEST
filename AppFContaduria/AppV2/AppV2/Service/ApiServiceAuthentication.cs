using Amazon.Runtime.Internal;
using AppV2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppV2.Service
{
    public class ApiServiceAuthentication
    {

        private static readonly HttpClient client = new HttpClient();
        public async Task<string> Login(UserAuthentication oUser)
        {
            try
            {
                //  URL completa concatenando 
                string apiUrl = AppSettings.ApiServiceMongo + "signin";
                // Serializa los datos del usuario a JSON
                string jsonUserData = Newtonsoft.Json.JsonConvert.SerializeObject(oUser);

                // Configura la solicitud HTTP POST

                var content = new StringContent(jsonUserData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                else
                {
                    // Intenta obtener información más detallada sobre el error si está disponible en la respuesta.
                    string errorContent = await response.Content.ReadAsStringAsync();
                    string errorMessage;

                    try
                    {
                        // Intenta deserializar la respuesta JSON para obtener un mensaje de error específico.
                        var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorContent);
                        errorMessage = errorResponse?.Message ?? "Error de autenticación";
                    }
                    catch (JsonException)
                    {
                        // Si la deserialización falla, utiliza un mensaje predeterminado.
                        errorMessage = "Error de autenticación";
                    }

                    return errorMessage;
                }
            }
            catch (HttpRequestException)
            {
                return "Error de red. Verifica tu conexión a internet.";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }
    }

}
