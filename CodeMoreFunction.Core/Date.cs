using System;

namespace CodeMoreFunction.Core
{
    public sealed class Date : IEquatable<Date>, IComparable<DateTime>, IComparable<Date>, IComparable<Month>, IComparable<Timestamp>
    {
        private DateTime Value { get; }

        public Date(int year, int month, int day)
        {
            this.Value = new DateTime(year, month, day);
        }

        public bool Equals(Date other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value.Equals(other.Value);
        }

        public int CompareTo(DateTime other) =>
            this.Value.CompareTo(other);
    }
}