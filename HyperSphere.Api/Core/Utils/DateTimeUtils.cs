using System;

namespace HyperSphere.Api.Core.Utils
{
    /// <summary>
    /// Extension for la gestione delle date
    /// </summary>
    public static class DateTimeUtils
    {
        public static DateTime NextDay(this DateTime from, DayOfWeek dayOfWeek)
        {
            var start = (int)from.DayOfWeek;
            var target = (int)dayOfWeek;
            if (target <= start)
                target += 7;
            return from.AddDays(target - start);
        }
    }
}
