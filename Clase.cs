using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using System.Net.Http;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Security.Policy;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Net;
using MercadoPago.Resource.User;
using System.Xml.Linq;
using static PryMercadoPagoQr.Clase;
using System.Text.Json;

namespace PryMercadoPagoQr
{
    public class Clase
    {
        private const string baseUrl = "https://api.mercadopago.com/instore/qr/seller/collectors/1772005205/pos/SUC002CAJA001/orders?access_token=TEST-7037479340314345-041615-34c3f862f610d2b370e1b8f704d85249-1772005205"; // URL de la solicitud GET
        bool pagoCompletado = false; // Variable para controlar si el pago ha sido completado
        private int dotCount = 0;
        private string external_id_form = string.Empty;
        

        public class StoreInfo
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public string external_id { get; set; }
        }

        

        public class Result
        {
            public int user_id { get; set; }
            public string name { get; set; }
            public bool fixed_amount { get; set; }
            public int category { get; set; }
            public string store_id { get; set; }
            public string external_id { get; set; }
            public int id { get; set; }
            public Qr qr { get; set; }
            public DateTime date_created { get; set; }
            public DateTime date_last_update { get; set; }
            public string external_store_id { get; set; }
        }

        public class Qr
        {
            public string image { get; set; }
            public string template_document { get; set; }
            public string template_image { get; set; }
        }

        public class ComboBoxItemData
        {
            public string name { get; set; }
            public string external_store_id { get; set; }
            public string external_id{ get; set; }
            public int user_id { get; set; }

            public ComboBoxItemData(string Name, string externalStoreId, string externalId, int userId)
            {
                name = Name;
                external_store_id = externalStoreId;
                external_id = externalId;
                user_id = userId;
            }

            public override string ToString()
            {
                return name;
            }
        }




        public static void ImagenQr(string imagenUrl, PictureBox pb)
        {
            // Descargar la imagen
            using (WebClient webClient = new WebClient())
            {
                byte[] imageData = webClient.DownloadData(imagenUrl);
                using (var ms = new System.IO.MemoryStream(imageData))
                {
                    // Crear una imagen desde los datos descargados
                    Image image = Image.FromStream(ms);

                    // Mostrar la imagen en el PictureBox
                    pb.Image = image;
                }
            }
        }


        public static async Task<List<Result>> ObtenerInfoCajas(string accessToken)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                HttpResponseMessage response = await client.GetAsync($"https://api.mercadopago.com/pos");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    JObject jsonResponse = JObject.Parse(responseBody);
                    JArray resultsArray = (JArray)jsonResponse["results"];

                    List<Result> cajaInfoList = new List<Result>();
                    
                    foreach (var item in resultsArray)
                    {
                        Result result = new Result
                        {
                            user_id = (int)item["user_id"],
                            name = (string)item["name"],
                            fixed_amount = (bool)item["fixed_amount"],
                            category = (int)item["category"],
                            store_id = (string)item["store_id"],
                            external_id = (string)item["external_id"],
                            id = (int)item["id"],
                            date_created = (DateTime)item["date_created"],
                            date_last_update = (DateTime)item["date_last_updated"],
                            external_store_id = (string)item["external_store_id"],
                            qr = new Qr
                            {
                                image = (string)item["qr"]["image"],
                                template_document = (string)item["qr"]["template_document"],
                                template_image = (string)item["qr"]["template_image"]
                            }

                        };
                        

                        
                        cajaInfoList.Add(result);
                    }

                    return cajaInfoList;
                }
                else
                {
                    MessageBox.Show($"Failed to get store data. Status code: {response.StatusCode}");
                    return null;
                }
            }
        }




        public static async Task<StoreInfo> ObtenerSucursal(string accessToken, string idMercado)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                HttpResponseMessage response = await client.GetAsync($"https://api.mercadopago.com/stores/" + idMercado);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    StoreInfo storeInfo = JsonConvert.DeserializeObject<StoreInfo>(responseBody);

                    return storeInfo;
                }
                else
                {
                    MessageBox.Show($"Failed to get store data. Status code: {response.StatusCode}");
                    return null;
                }
            }
        }


        //    public static async Task EnviarCobro(int userId, string externalStoreId, string externalId, string token, decimal Monto, bool Enviado)
        //    {
        //        // URL de la solicitud
        //        var url = "https://api.mercadopago.com/instore/qr/seller/collectors/" + userId + "/stores/" + externalStoreId +
        //            "/pos/" + externalId + "/orders?access_token=" + token;

        //        // Body de la solicitud
        //                        string safas = @"
        //            {
        //              ""description"": ""Item de prueba"",
        //              ""external_reference"": ""1"",
        //              ""items"": [
        //                {
        //                  ""sku_number"": ""1"",
        //                  ""category"": ""1"",
        //                  ""title"": ""Item de prueba"",
        //                  ""description"": ""Este es un Item de prueba"",
        //                  ""unit_price"": " + Monto + @",
        //                  ""quantity"": 1,
        //                  ""unit_measure"": ""unit"",
        //                  ""total_amount"": " + Monto + @"
        //                }
        //              ],
        //              ""title"": ""Item de prueba"",
        //              ""total_amount"": " + Monto + @"
        //            }";




        //        // Body de la solicitud
        //        var bodyData = new
        //        {
        //            description = "Item de prueba",
        //            external_reference = "1",
        //            items = new[]
        //            {
        //    new
        //    {
        //        sku_number = "1",
        //        category = "1",
        //        title = "Item de prueba",
        //        description = "Este es un Item de prueba",
        //        unit_price = Monto,
        //        quantity = 1,
        //        unit_measure = "unit",
        //        total_amount = Monto
        //    }
        //},
        //            title = "Item de prueba",
        //            total_amount = Monto
        //        };

        //        var body = JsonSerializer.Serialize(bodyData);
        //        // Crear cliente HttpClient
        //        using (var client = new HttpClient())
        //        {

        //            // Configurar encabezados
        //            var request = new HttpRequestMessage(HttpMethod.Put, url);
        //            request.Headers.Add("Authorization", "Bearer " + token);
        //            request.Headers.Add("Accept", "application/json");
        //            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

        //            // Enviar solicitud
        //            var response = await client.SendAsync(request);

        //            // Verificar el código de estado
        //            if (response.IsSuccessStatusCode)
        //            {
        //                Enviado = true;

        //            }
        //            else
        //            {
        //                MessageBox.Show(response.Content.ToString());
        //                Enviado = false;
        //            }






        //        }
        //    }



        public static async Task<bool> EnviarCobro(int userId, string externalStoreId, string externalId, string token, decimal Monto)
        {
            bool Enviado = false;
            // URL de la solicitud
            var url = "https://api.mercadopago.com/instore/qr/seller/collectors/" + userId + "/stores/" + externalId +
                "/pos/" + externalStoreId + "/orders?access_token=" + token;

            // Body de la solicitud
            var bodyData = new
            {
                description = "Item de prueba",
                external_reference = "1",
                items = new[]
                {
            new
            {
                sku_number = "1",
                category = "1",
                title = "Item de prueba",
                description = "Este es un Item de prueba",
                unit_price = Monto,
                quantity = 1,
                unit_measure = "unit",
                total_amount = Monto
            }
        },
                title = "Item de prueba",
                total_amount = Monto
            };

            var body = System.Text.Json.JsonSerializer.Serialize(bodyData, new JsonSerializerOptions
            {
                IgnoreNullValues = true
            });

            // Crear cliente HttpClient
            using (var client = new HttpClient())
            {
                // Configurar encabezados
                var request = new HttpRequestMessage(HttpMethod.Put, url);
                request.Headers.Add("Authorization", "Bearer " + token);
                request.Headers.Add("Accept", "application/json");
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");

                // Enviar solicitud
                var response = await client.SendAsync(request);

                // Verificar el código de estado
                if (response.IsSuccessStatusCode)
                {
                    Enviado = true;
                }
                else
                {
                    MessageBox.Show(await response.Content.ReadAsStringAsync());
                    Enviado = false;
                }
            }
            return Enviado;
        }




        public async Task VerificarEstadoPagoAsync(int estado)
        {
            
            bool EstadoPago = false;
            // Realizar solicitudes GET periódicas
            while (!EstadoPago)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        var response = await client.GetAsync(baseUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            //// Pago sigue en proceso
                            
                            EstadoPago = false;
                        }
                        else
                        {
                            // Pago completado
                            EstadoPago = true;
                            

                            break; // Salir del bucle
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar errores
                    MessageBox.Show($"Error al verificar el estado del pago: {ex.Message}");
                }

                // Esperar un tiempo antes de la siguiente verificación
                
            }

            
            

        }


        public static async Task CancelarCobro(string token, int userId, string externalStoreId, bool CobroCancelado)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                string url = $"https://api.mercadopago.com/instore/qr/seller/collectors/{userId}/pos/{externalStoreId}/orders";
                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    CobroCancelado = true;
                }
                else
                {
                    // Manejar el caso en que la cancelación no fue exitosa
                    MessageBox.Show("ERROR AL CANCELAR EL PAGO");
                }
            }
        }






    }
}
