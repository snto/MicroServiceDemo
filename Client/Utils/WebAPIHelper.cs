using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Utils
{
    public class WebAPIHelper
    {
        public static string InvokeAPI(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage();
                message.Method = HttpMethod.Get;
                message.RequestUri = new Uri(url);
                var result = httpClient.SendAsync(message).Result;
                string context = result.Content.ReadAsStringAsync().Result;
                return context;
            }
        }
    }
}
