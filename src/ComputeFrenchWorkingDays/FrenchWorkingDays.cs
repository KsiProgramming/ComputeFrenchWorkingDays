namespace ComputeFrenchWorkingDays
{
    public static class FrenchWorkingDays
    {
        private static readonly DateOnly[] FixedHolidayDates = new DateOnly[]
        {
            new DateOnly(2000, 1, 01),
            new DateOnly(2000, 5, 01),
            new DateOnly(2000, 5, 08),
            new DateOnly(2000, 7, 14),
            new DateOnly(2000, 8, 15),
            new DateOnly(2000, 11, 1),
            new DateOnly(2000, 11, 11),
            new DateOnly(2000, 12, 25),
        };

        public static DateTime AddFrenchWorkingDays(this DateTime dateTime, int workingDays)
        {
            var dateOnly = DateOnly.FromDateTime(dateTime);
            dateOnly = AddFrenchWorkingDays(dateOnly, workingDays);

            var newDateTime = dateOnly.ToDateTime(TimeOnly.FromDateTime(dateTime));

            return newDateTime;
        }

        public static DateOnly AddFrenchWorkingDays(this DateOnly dateOnly, int workingDays)
        {
            if (workingDays == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(workingDays), $"Working days must be a nonzero number.");
            }

            if (dateOnly.Year < 1583)
            {
                throw new ArgumentOutOfRangeException(nameof(dateOnly), $"Year must be greater than or equal to 1583.");
            }

            var workingDaysOffSet = FindNextWorkingDateOffset(dateOnly, workingDays, Math.Sign(workingDays), new Dictionary<int, DateOnly[]>());

            return dateOnly.AddDays(workingDaysOffSet);
        }

        private static int FindNextWorkingDateOffset(DateOnly date, int days, int step, Dictionary<int, DateOnly[]> yearsHolidays)
        {
            if (days == 0)
            {
                return 0;
            }

            date = date.AddDays(step);

            if (!yearsHolidays.ContainsKey(date.Year))
            {
                var holidays = GetYearHolidays(date.Year);
                yearsHolidays.Add(date.Year, holidays);
            }

            days = IsWorkingDay(date, yearsHolidays[date.Year]) ? days - step : days;

            return FindNextWorkingDateOffset(date, days, step, yearsHolidays) + step;
        }

        private static bool IsWorkingDay(DateOnly date, DateOnly[] yearHolidays)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }

            if (yearHolidays.Contains(date))
            {
                return false;
            }

            return true;
        }

        private static (DateOnly EasternMondayDate, DateOnly AscentDate, DateOnly PentecostDate) ComputeVariableHolidayDates(int year)
        {
            // OUDIN's Algorithm
            // http://frederic.leon77.free.fr/formations/2012_13/100outils/jour2/oudin.pdf
            var g = year % 19;
            var c = year / 100;
            var c_4 = c / 4;
            var e = ((8 * c) + 13) / 25;
            var h = ((19 * g) + c - c_4 - e + 15) % 30;
            var k = h / 28;
            var p = 29 / (h + 1);
            var q = (21 - g) / 28;
            var i = (((k * p * q) - 1) * k) + h;
            var b = year + (year / 4);
            var j1 = b + i + 2 + c_4 - c;
            var j2 = j1 % 7;
            var easternDay = 28 + i - j2;
            var easternMonth = 3;
            if (easternDay >= 31)
            {
                easternDay %= 31;
                easternMonth = 4;
            }

            var easternMonday = easternDay + 1;
            var easternMondayDate = new DateOnly(year, easternMonth, easternMonday);

            return (easternMondayDate, easternMondayDate.AddDays(38), easternMondayDate.AddDays(49));
        }

        private static DateOnly[] GetYearHolidays(int year)
        {
            var fixedHolidays = FixedHolidayDates.Select(d => new DateOnly(year, d.Month, d.Day));
            var variableHolidays = ComputeVariableHolidayDates(year);

            return fixedHolidays.Concat(new DateOnly[]
            {
                variableHolidays.EasternMondayDate,
                variableHolidays.AscentDate,
                variableHolidays.PentecostDate,
            })
            .OrderBy(d => d.Month)
            .ToArray();
        }
    }
}
