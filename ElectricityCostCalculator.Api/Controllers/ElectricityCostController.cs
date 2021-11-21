using ElectricityCostCalculator.Api.Models.Queries;
using ElectricityCostCalculator.Domain.AggregatesModel.CountryCostAggregate;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectricityCostCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricityCostController : ControllerBase
    {
        // GET api/<ElectricityCost>/
        [HttpGet("")]
        public decimal Get([FromQuery] ElectricityCostQuery countryCostForecast)
        {
            var countryCost = new CountryCost(countryCostForecast.TotalElectricity, countryCostForecast.WindSupply,
                countryCostForecast.NaturalGasCost);

            var expectedCost = countryCost.GetForecastCost();

            return expectedCost;
        }
    }
}
