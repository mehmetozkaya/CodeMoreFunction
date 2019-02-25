using System;

namespace CodeMoreFunction.Core
{
    public class Empty : SpecificMoney
    {
        public Empty(Currency currency) : base(currency)
        {
        }

        public override Money On(Timestamp time) =>
            this;

        public override System.Tuple<Amount, Money> Take(decimal amount) =>
            Tuple.Create(Amount.Zero(base.Currency), (Money)this);
    }
}