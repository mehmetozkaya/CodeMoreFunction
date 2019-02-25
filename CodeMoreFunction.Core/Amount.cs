using System;

namespace CodeMoreFunction.Core
{
    public class Amount : SpecificMoney
    {
        public decimal Value { get; }

        public Amount(Currency currency, decimal amount) : base(currency)
        {
            if (amount < 0)
                throw new ArgumentException("Negative amount.");
            this.Value = amount;
        }

        public override Money On(Timestamp time) => this;

        public override Tuple<Amount, Money> Take(decimal amount)
        {
            decimal taken = Math.Min(this.Value, amount);
            decimal remaining = this.Value - taken;

            return Tuple.Create(
                new Amount(base.Currency, taken),
                (Money)new Amount(base.Currency, remaining));
        }

        public static Amount Zero(Currency currency) =>
           new Amount(currency, 0);
    }
}