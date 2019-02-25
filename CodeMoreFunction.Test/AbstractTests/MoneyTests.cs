using CodeMoreFunction.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeMoreFunction.Test.AbstractTests
{
    public abstract class MoneyTests
    {
        protected abstract Timestamp TimeWithinValidity { get; }
        protected abstract Money CreateMoney(Currency currency, decimal amount);
        protected Currency TestCurrency => Currency.USD;
        protected Currency DifferentTestCurrency => Currency.EUR;
    }
}
