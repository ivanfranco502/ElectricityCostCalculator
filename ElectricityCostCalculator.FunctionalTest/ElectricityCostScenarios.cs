using System;
using System.Net.Http;
using System.Threading.Tasks;
using ElectricityCostCalculator.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace ElectricityCostCalculator.FunctionalTest
{
    public class ElectricityCostScenarios : IDisposable
    {
        private readonly HttpClient _client;

        public ElectricityCostScenarios()
        {
            var _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Get_GivenAValidRequest_ShouldReturnOkStatusCodeAndValueAsExpected()
        {
            var total = 135000m;
            var wind = 70000m;
            var gas = 67.2m;
            using (var response = await _client.GetAsync($"api/ElectricityCost?TotalElectricity={total}&WindSupply={wind}&NaturalGasCost={gas}"))
            {

                Assert.True(response.IsSuccessStatusCode);

                Assert.Equal("65.05", await response.Content.ReadAsStringAsync());
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
