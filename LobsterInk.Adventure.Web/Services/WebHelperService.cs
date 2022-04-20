using Newtonsoft.Json;
using System.Net;

namespace LobsterInk.Adventure.Web.Services
{
    public class WebHelperService
    {
        public T Get<T>(string url)
        {
            using (WebClient client = new WebClient())
            {
                var result = client.DownloadString(url);

                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        public T Post<T>(string url, string data)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var result = client.UploadString(url, data);

                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        public string Post(string url, string data)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var result = client.UploadString(url, data);

                return result;
            }
        }
    }
}
