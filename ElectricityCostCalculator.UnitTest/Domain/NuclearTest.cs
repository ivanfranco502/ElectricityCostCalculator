using ElectricityCostCalculator.Domain.AggregatesModel.CountryCostAggregate;
using Xunit;

namespace ElectricityCostCalculator.UnitTest.Domain
{
    public class NuclearTest
    {
        [Fact]
        public void GivenAnAmountLargerThanTheLimit_ShouldNuclearAmountSetToLimit()
        {
            var limit = 30000;

            var instance = new Nuclear(500000);

            Assert.Equal(limit, instance.Amount);
        }

        [Fact]
        public void GivenAnAmountSmallerThanTheLimit_ShouldNuclearAmountSetProperly()
        {
            var amount = 25000;

            var instance = new Nuclear(amount);

            Assert.Equal(amount, instance.Amount);
        }

        [Fact]
        public void GetTotalCost_GivenAValidAmount_ShouldReturnExpectedCost()
        {
            var amount = 30000;
            var expectedCost = 1683000.0m;

            var instance = new Nuclear(amount);

            var result = instance.GetTotalCost();

            Assert.Equal(expectedCost, result);
        }
    }
}
