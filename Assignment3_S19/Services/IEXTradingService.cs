using Assignment3_S19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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
            var request = new HttpRequestMessage(HttpMethod.Get,
                "ref-data/symbols");

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
    }
}
