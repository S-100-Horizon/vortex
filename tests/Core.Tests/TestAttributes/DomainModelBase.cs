using System.Runtime.CompilerServices;

namespace S100Framework.DomainModel.S100
{
    public readonly struct Time
    {
        private readonly long _ticks;

        private const long MinTimeTicks = 0;

        private const long MaxTimeTicks = 863_999_999_999 + 1;

        public const long MinutesPerHour = TicksPerHour / TicksPerMinute;                           //              60

        /// <summary>
        /// Represents the smallest possible value of Time.
        /// </summary>
        public static Time MinValue => new Time((ulong)MinTimeTicks);

        /// <summary>
        /// Represents the largest possible value of Time.
        /// </summary>
        public static Time MaxValue => new Time((ulong)MaxTimeTicks);

        /// <summary>
        /// Initializes a new instance of the Time structure to the specified hour and the minute.
        /// </summary>
        /// <param name="hour">The hours (0 through 23).</param>
        /// <param name="minute">The minutes (0 through 59).</param>
        public Time(int hour, int minute) : this(Time.TimeToTicks(hour, minute)) { }

        /// <summary>
        /// Initializes a new instance of the Time structure using a specified number of ticks.
        /// </summary>
        /// <param name="ticks">A time of day expressed in the number of 100-nanosecond units since 00:00:00.0000000.</param>
        public Time(long ticks) {
            if ((ulong)ticks > MaxTimeTicks) {
                throw new ArgumentOutOfRangeException(nameof(ticks), "Ticks must be between 0 and and Time.MaxValue.Ticks.");
            }

            _ticks = ticks;
        }

        public int Hours => _ticks == MaxTimeTicks ? 24 : (int)(_ticks / TicksPerHour % HoursPerDay);

        public int Minutes => (int)(_ticks / TicksPerMinute % MinutesPerHour);

        internal Time(ulong ticks) => _ticks = (long)ticks;

        internal const int MicrosecondsPerMillisecond = 1000;
        private const long TicksPerMicrosecond = 10;
        private const long TicksPerMillisecond = TicksPerMicrosecond * MicrosecondsPerMillisecond;

        private const int HoursPerDay = 24;
        private const long TicksPerSecond = TicksPerMillisecond * 1000;
        private const long TicksPerMinute = TicksPerSecond * 60;
        private const long TicksPerHour = TicksPerMinute * 60;
        private const long TicksPerDay = TicksPerHour * HoursPerDay;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong TimeToTicks(int hour, int minute) {
            if ((uint)hour > 24 || (uint)minute >= 60) {
                throw new System.ArgumentOutOfRangeException(null, "Hour and Minute parameters describe an un-representable TimeOfDay.");
            }

            int totalSeconds = hour * 3600 + minute * 60;
            return (uint)totalSeconds * (ulong)TicksPerSecond;
        }

        internal DateTime ToDateTime() => new DateTime(_ticks);

        internal TimeSpan ToTimeSpan() => new TimeSpan(_ticks);

        public override string ToString() => $"{Hours:00}:{Minutes:00}";

        public static Time Parse(string s) {
            var values = s.Split(':');
            if (values.Length >= 2 && int.TryParse(values[0], out int hours) && int.TryParse(values[1], out int minutes))
                return new Time(int.Parse(values[0]), int.Parse(values[1]));
            throw new Exception("Expected time in 'hh:mm' format.");
        }
    }
}
