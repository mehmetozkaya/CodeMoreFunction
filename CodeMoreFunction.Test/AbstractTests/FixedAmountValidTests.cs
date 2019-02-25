using CodeMoreFunction.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CodeMoreFunction.Test.AbstractTests
{
    public abstract class FixedAmountValidTests : ValidMoneyTests
    {
        [Fact]
        public void On_PartOfAmountAvailable_TakeOnRestReturnsZeroAmount()
        {
            decimal available = 1;
            Money sut = this.CreateMoney(this.TestCurrency, available);

            decimal toTake = 2;
            Money rest = sut.On(this.TimeWithinValidity).Of(this.TestCurrency).Take(toTake).Item2;

            decimal remaining = rest.On(this.TimeWithinValidity).Of(this.TestCurrency).Take(toTake).Item1.Value;
            Assert.Equal(0, remaining);
        }

        [Fact]
        public void On_PartOfAmountAvailable_TakesThatMuch()
        {
            decimal available = 1;
            Money sut = this.CreateMoney(this.TestCurrency, available);

            decimal toTake = 2;
            decimal taken = sut.On(this.TimeWithinValidity).Of(this.TestCurrency).Take(toTake).Item1.Value;

            Assert.Equal(available, taken);
        }

        [Fact]
        public void On_FullAmountAvailable_TakeOnRestReturnsRemainingAmount()
        {
            decimal available = 100;
            Money sut = this.CreateMoney(base.TestCurrency, available);

            decimal toTake = 17;
            Money rest = sut.On(this.TimeWithinValidity).Of(base.TestCurrency).Take(toTake).Item2;

            decimal remaining = rest.On(this.TimeWithinValidity).Of(base.TestCurrency).Take(available).Item1.Value;
            decimal expectedRemaining = 83;

            Assert.Equal(expectedRemaining, remaining);
        }

        [Fact]
        public void IEnumerableTake_SufficientAmountInSeveralMoneys_TakesTotalRequestedAmount()
        {
            decimal amountPerMoney = 10;
            IEnumerable<Money> sut =
                Enumerable.Range(1, 10).Select(_ => this.CreateMoney(base.TestCurrency, amountPerMoney));

            decimal takeAmount = 73;
            decimal taken = sut
                .On(this.TimeWithinValidity)
                .Of(base.TestCurrency)
                .Take(takeAmount)
                .Sum(tuple => tuple.Item1.Value);

            Assert.Equal(takeAmount, taken);
        }

        [Fact]
        public void IEnumerableTake_SufficientAmountInSeveralMoneys_RemainingMoneysContainRemainingMoney()
        {
            decimal amountPerMoney = 10;
            IEnumerable<Money> sut =
                Enumerable.Range(1, 10).Select(_ => this.CreateMoney(base.TestCurrency, amountPerMoney));

            decimal takeAmount = 73;
            IEnumerable<Money> remains = sut
                .On(this.TimeWithinValidity)
                .Of(base.TestCurrency)
                .Take(takeAmount)
                .Select(tuple => tuple.Item2)
                .ToList();

            decimal maxAmount = 1000;
            decimal remainingAmount = remains
                .On(this.TimeWithinValidity)
                .Of(base.TestCurrency)
                .Take(maxAmount)
                .Sum(tuple => tuple.Item1.Value);

            decimal expectedRemaining = 27;

            Assert.Equal(expectedRemaining, remainingAmount);
        }
    }
}
