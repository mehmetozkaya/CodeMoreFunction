using System;

namespace CodeMoreFunction.Core
{
    public sealed class Currency : IEquatable<Currency>
    {
        public string Symbol { get; }

        private Currency(string symbol)
        {
            this.Symbol = symbol ?? throw new ArgumentNullException(nameof(symbol));
        }

        public static Currency USD => new Currency("USD");
        public static Currency EUR => new Currency("EUR");
        public static Currency JPY => new Currency("JPY");

        public bool Equals(Currency other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Symbol, other.Symbol);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Currency)obj);
        }

        public override int GetHashCode()
        {
            return (Symbol != null ? Symbol.GetHashCode() : 0);
        }

        public static bool operator ==(Currency a, Currency b) =>
            (object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null)) ||
            (!object.ReferenceEquals(a, null) && a.Equals(b));

        public static bool operator !=(Currency a, Currency b) => !(a == b);
    }
}