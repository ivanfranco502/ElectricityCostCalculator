using ElectricityCostCalculator.Domain.AggregatesModel.CountryCostAggregate;
using Xunit;

namespace ElectricityCostCalculator.UnitTest.Domain
{
    public class WindTest
    {
        [Fact]
        public void GivenAnAmountLargerThanTheLimit_ShouldWindAmountSetToLimit()
        {
            var limit = 100000;

            var instance = new Wind(500000);

            Assert.Equal(limit, instance.Amount);
        }

        [Fact]
        public void GivenAnAmountSmallerThanTheLimit_ShouldWindAmountSetProperly()
        {
            var amount = 75000;

            var instance = new Wind(amount);

            Assert.Equal(amount, instance.Amount);
        }

        [Fact]
        public void GetTotalCost_GivenAValidAmount_ShouldReturnExpectedCost()
        {
            var amount = 70000;
            var expectedCost = 4277000.0m;

            var instance = new Wind(amount);

            var result = instance.GetTotalCost();

            Assert.Equal(expectedCost, result);
        }
    }
}