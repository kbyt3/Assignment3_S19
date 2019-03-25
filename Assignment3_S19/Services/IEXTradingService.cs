using Assignment3_S19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ApiResponse = System.Collections.Generic.Dictionary<string, Assignment3_S19.Models.IEXApiResponse>;

namespace Assignment3_S19.Services
{
    public class IEXTradingService
    {
        private readonly IHttpClientFactory _clientFactory;

        public IEXTradingService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "ref-data/symbols");

            var client = _clientFactory.CreateClient("IEXTrading");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content
                    .ReadAsAsync<IEnumerable<Company>>();
            }
            else
            {
                return Array.Empty<Company>();
            }
        }

        public async Task<ApiResponse> GetStockData(string[] symbols, string[] data, string range = "1m", int last = 5)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, MakeRequestUrl(symbols, data, range, last));

            var client = _clientFactory.CreateClient("IEXTrading");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ApiResponse>(jsonData, new DefaultJsonSerializer());
            }
            else
            {
                return null;
            }
        }

        private string MakeRequestUrl(string[] symbols, string[] data, string range, int last)
        {
            return String.Format(@"stock/market/batch?symbols={0}&types={1}&range={2}&last={3}", String.Join(',', symbols), String.Join(',', data), range, last);
        }
    }
}
