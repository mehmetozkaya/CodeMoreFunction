using System;

namespace CodeMoreFunction.Core
{
    public class CardExpired : BankCard
    {
        public CardExpired(Month validBefore) : base(validBefore)
        {
        }

        public override Money On(Timestamp time) =>
            this;

        public override SpecificMoney Of(Currency currency) =>
            new Empty(currency);

        public override Tuple<Amount, Money> Take(Currency currency, decimal amount) =>
            Tuple.Create(Amount.Zero(currency), (Money)this);
    }
}