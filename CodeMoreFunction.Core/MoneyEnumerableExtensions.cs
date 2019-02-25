using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeMoreFunction.Core
{
    public static class MoneyEnumerableExtensions
    {
        public static IEnumerable<Money> On(this IEnumerable<Money> moneys,
                                            Timestamp time) =>
            moneys.Select(money => money.On(time));

        public static IEnumerable<SpecificMoney> Of(this IEnumerable<Money> moneys,
                                                    Currency currency) =>
            moneys.Select(money => money.Of(currency));

        public static IEnumerable<Tuple<Amount, Money>> Take(
            this IEnumerable<SpecificMoney> moneys, decimal amount)
        {
            decimal rest = amount;
            foreach (SpecificMoney money in moneys)
            {
                Tuple<Amount, Money> current = money.Take(rest);
                yield return current;
                rest -= current.Item1.Value;
            }
        }
    }
}
