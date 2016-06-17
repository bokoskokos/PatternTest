using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyPegasus.DataAccess.DeutscheBahnApi
{
    public class DeutscheBahnApiClient : IDeutscheBahnApiClient
    {
        public async Task<T> GetAsync<T>(string uri)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.95 Safari/537.11");

                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var contentString = await response.Content.ReadAsStringAsync();
                    var content = JsonConvert.DeserializeObject<T>(contentString);
                    return content;
                }

                return default(T);
            }
        }
    }
}
