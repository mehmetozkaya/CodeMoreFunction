using System;

namespace CodeMoreFunction.Core
{
    public class Timestamp : IComparable<DateTime>, IComparable<Timestamp>, IComparable<Date>, IComparable<Month>
    {
        private DateTime UtcTime { get; }

        public Timestamp(DateTime utcTime)
        {
            if (utcTime.Kind != DateTimeKind.Utc)
                throw new ArgumentException("UTC time expected.");
            UtcTime = utcTime;
        }

        public static Timestamp Now =>
            new Timestamp(DateTime.UtcNow);

        public int CompareTo(DateTime other) =>
            this.UtcTime.CompareTo(other);

        public int CompareTo(Timestamp other) =>
            this.UtcTime.CompareTo(other.UtcTime);

        public int CompareTo(Date other) =>
            -other.CompareTo(this.UtcTime);

        public int CompareTo(Month other) =>
            -other.CompareTo(this.UtcTime);
    }
}