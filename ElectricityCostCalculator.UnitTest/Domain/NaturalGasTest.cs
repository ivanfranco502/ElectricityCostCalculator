using ElectricityCostCalculator.Domain.AggregatesModel.CountryCostAggregate;
using Xunit;

namespace ElectricityCostCalculator.UnitTest.Domain
{
    public class NaturalGasTest
    {
        [Fact]
        public void GetTotalCost_GivenAValidRawMaterialPrice_ShouldReturnExpectedCost()
        {
            var rawPrice = 67.2m;
            var expectedCost = 2822400.0m;

            var instance = new NaturalGas(35000, rawPrice);

            var result = instance.GetTotalCost();

            Assert.Equal(expectedCost, result);
        }
    }
}
