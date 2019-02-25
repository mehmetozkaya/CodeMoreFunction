using System;

namespace CodeMoreFunction.Core
{
    public abstract class SpecificMoney : Money
    {
        public Currency Currency { get; }

        protected SpecificMoney(Currency currency)
        {
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        public override SpecificMoney Of(Currency currency)
        {
            if (currency.Equals(this.Currency))
                return this;
            return new Empty(currency);
        }

        public abstract Tuple<Amount, Money> Take(decimal amount);

    }
}