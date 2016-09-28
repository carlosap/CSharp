using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public static class DbServices
    {
 
        public static async Task<string> Get(string apiName)
        {

            var results = string.Empty;
            try
            {
                var url = string.Empty;
                switch (apiName.ToLower())
                {
                    case "users":
                        url = Startup.AppSettings.DbServices.Users;
                        break;
                    case "temperature":
                        url = Startup.AppSettings.DbServices.Temperature;
                        break;
                    case "humidity":
                        url = Startup.AppSettings.DbServices.Humidity;
                        break;
                    case "ppb":
                    case "ppm":
                        url = Startup.AppSettings.DbServices.Voc;
                        break;
                    default:
                        return string.Empty;
                }

                if (!string.IsNullOrEmpty(url))
                {
                    using (var client = new HttpClient())
                    {
                        var response = await client.GetAsync(url);
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = response.Content;
                            results = await responseContent.ReadAsStringAsync();
                        }
                    }
                }
            }
            catch (Exception)
            {
                results = string.Empty;
            }
            return results;
        }
    }
}
