using CodeMoreFunction.Core;
using Xunit;

namespace CodeMoreFunction.Test.AbstractTests
{
    public abstract class ValidMoneyTests : MoneyTests
    {
        [Fact]
        public void On_SufficientAmount_AllowsTake()
        {
            Money sut = this.CreateMoney(this.TestCurrency, 100);

            decimal amount = 1;
            decimal taken = sut.On(this.TimeWithinValidity).Of(this.TestCurrency).Take(amount).Item1.Value;

            Assert.Equal(amount, taken);
        }
    }
}
