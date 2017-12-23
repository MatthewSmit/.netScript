using System;
using System.Globalization;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class DateIntrinsics
    {
        private const int HOURS_PER_DAY = 24;
        private const int MINUTES_PER_HOUR = 60;
        private const int SECONDS_PER_MINUTE = 60;
        private const int MILLISECONDS_PER_SECOND = 1000;
        private const int MILLISECONDS_PER_MINUTE = MILLISECONDS_PER_SECOND * SECONDS_PER_MINUTE;
        private const int MILLISECONDS_PER_HOUR = MILLISECONDS_PER_MINUTE * MINUTES_PER_HOUR;
        private const int MILLISECONDS_PER_DAY = MILLISECONDS_PER_HOUR * HOURS_PER_DAY;

        public static (ScriptFunctionObject date, ScriptObject datePrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm, [NotNull] ScriptObject objectPrototype, [NotNull] ScriptObject functionPrototype)
        {
            var date = Intrinsics.CreateBuiltinFunction(realm, Date, functionPrototype, 7, "Date", ConstructorKind.Base);
            Intrinsics.DefineFunction(date, "now", 0, realm, Now);
            Intrinsics.DefineFunction(date, "parse", 1, realm, Parse);
            Intrinsics.DefineFunction(date, "UTC", 7, realm, UTC);

            var datePrototype = agent.ObjectCreate(objectPrototype);
            Intrinsics.DefineDataProperty(datePrototype, "constructor", date);
            Intrinsics.DefineFunction(datePrototype, "getDate", 0, realm, GetDate);
            Intrinsics.DefineFunction(datePrototype, "getDay", 0, realm, GetDay);
            Intrinsics.DefineFunction(datePrototype, "getFullYear", 0, realm, GetFullYear);
            Intrinsics.DefineFunction(datePrototype, "getHours", 0, realm, GetHours);
            Intrinsics.DefineFunction(datePrototype, "getMilliseconds", 0, realm, GetMilliseconds);
            Intrinsics.DefineFunction(datePrototype, "getMinutes", 0, realm, GetMinutes);
            Intrinsics.DefineFunction(datePrototype, "getMonth", 0, realm, GetMonth);
            Intrinsics.DefineFunction(datePrototype, "getSeconds", 0, realm, GetSeconds);
            Intrinsics.DefineFunction(datePrototype, "getTime", 0, realm, GetTime);
            Intrinsics.DefineFunction(datePrototype, "getTimezoneOffset", 0, realm, GetTimezoneOffset);
            Intrinsics.DefineFunction(datePrototype, "getUTCDate", 0, realm, GetUTCDate);
            Intrinsics.DefineFunction(datePrototype, "getUTCDay", 0, realm, GetUTCDay);
            Intrinsics.DefineFunction(datePrototype, "getUTCFullYear", 0, realm, GetUTCFullYear);
            Intrinsics.DefineFunction(datePrototype, "getUTCHours", 0, realm, GetUTCHours);
            Intrinsics.DefineFunction(datePrototype, "getUTCMilliseconds", 0, realm, GetUTCMilliseconds);
            Intrinsics.DefineFunction(datePrototype, "getUTCMinutes", 0, realm, GetUTCMinutes);
            Intrinsics.DefineFunction(datePrototype, "getUTCMonth", 0, realm, GetUTCMonth);
            Intrinsics.DefineFunction(datePrototype, "getUTCSeconds", 0, realm, GetUTCSeconds);
            Intrinsics.DefineFunction(datePrototype, "setDate", 1, realm, SetDate);
            Intrinsics.DefineFunction(datePrototype, "setFullYear", 3, realm, SetFullYear);
            Intrinsics.DefineFunction(datePrototype, "setHours", 4, realm, SetHours);
            Intrinsics.DefineFunction(datePrototype, "setMilliseconds", 1, realm, SetMilliseconds);
            Intrinsics.DefineFunction(datePrototype, "setMinutes", 3, realm, SetMinutes);
            Intrinsics.DefineFunction(datePrototype, "setMonth", 2, realm, SetMonth);
            Intrinsics.DefineFunction(datePrototype, "setSeconds", 2, realm, SetSeconds);
            Intrinsics.DefineFunction(datePrototype, "setTime", 1, realm, SetTime);
            Intrinsics.DefineFunction(datePrototype, "setUTCDate", 1, realm, SetUTCDate);
            Intrinsics.DefineFunction(datePrototype, "setUTCFullYear", 3, realm, SetUTCFullYear);
            Intrinsics.DefineFunction(datePrototype, "setUTCHours", 4, realm, SetUTCHours);
            Intrinsics.DefineFunction(datePrototype, "setUTCMilliseconds", 1, realm, SetUTCMilliseconds);
            Intrinsics.DefineFunction(datePrototype, "setUTCMinutes", 3, realm, SetUTCMinutes);
            Intrinsics.DefineFunction(datePrototype, "setUTCMonth", 2, realm, SetUTCMonth);
            Intrinsics.DefineFunction(datePrototype, "setUTCSeconds", 2, realm, SetUTCSeconds);
            Intrinsics.DefineFunction(datePrototype, "toDateString", 0, realm, ToDateString);
            Intrinsics.DefineFunction(datePrototype, "toISOString", 0, realm, ToISOString);
            Intrinsics.DefineFunction(datePrototype, "toJSON", 1, realm, ToJSON);
            Intrinsics.DefineFunction(datePrototype, "toLocaleDateString", 0, realm, ToLocaleDateString);
            Intrinsics.DefineFunction(datePrototype, "toLocaleString", 0, realm, ToLocaleString);
            Intrinsics.DefineFunction(datePrototype, "toLocaleTimeString", 0, realm, ToLocaleTimeString);
            Intrinsics.DefineFunction(datePrototype, "toString", 0, realm, ToString);
            Intrinsics.DefineFunction(datePrototype, "toTimeString", 0, realm, ToTimeString);
            Intrinsics.DefineFunction(datePrototype, "toUTCString", 0, realm, ToUTCString);
            Intrinsics.DefineFunction(datePrototype, "valueOf", 0, realm, ValueOf);
            Intrinsics.DefineDataProperty(datePrototype, Symbol.ToPrimitive, Intrinsics.CreateBuiltinFunction(realm, ToPrimitive, functionPrototype, 1, "[Symbol.toPrimitive]"), false);

            Intrinsics.DefineDataProperty(date, "prototype", datePrototype, false, false, false);

            return (date, datePrototype);
        }

        private static ScriptValue Date([NotNull] ScriptArguments arg)
        {
            if (arg.NewTarget == null)
            {
                return ToDateString(DateTime.Now);
            }

            double timeValue;
            if (arg.Count == 0)
            {
                //https://tc39.github.io/ecma262/#sec-date-constructor-date
                timeValue = (DateTime.Now.Ticks - unixEpoch) / (double)TimeSpan.TicksPerMillisecond;
            }
            else if (arg.Count == 1)
            {
                //https://tc39.github.io/ecma262/#sec-date-value
                var value = arg[0];
                if (value.IsObject && ((ScriptObject)value).SpecialObjectType == SpecialObjectType.Date)
                {
                    timeValue = ((ScriptObject)value).DateValue;
                }
                else
                {
                    value = arg.Agent.ToPrimitive(value);
                    if (value.IsString)
                    {
                        timeValue = arg.Agent.ToNumber(Parse(arg));
                    }
                    else
                    {
                        timeValue = arg.Agent.ToNumber(value);
                    }
                }
            }
            else
            {
                //https://tc39.github.io/ecma262/#sec-date-year-month-date-hours-minutes-seconds-ms
                var year = arg.Agent.ToNumber(arg[0]);
                var month = arg.Agent.ToNumber(arg[1]);
                var date = arg[2] == ScriptValue.Undefined ? 1 : arg.Agent.ToInteger(arg[2]);
                var hour = arg[3] == ScriptValue.Undefined ? 0 : arg.Agent.ToInteger(arg[3]);
                var minute = arg[4] == ScriptValue.Undefined ? 0 : arg.Agent.ToInteger(arg[4]);
                var second = arg[5] == ScriptValue.Undefined ? 0 : arg.Agent.ToInteger(arg[5]);
                var millisecond = arg[6] == ScriptValue.Undefined ? 0 : arg.Agent.ToInteger(arg[6]);

                var intYear = Agent.ToInteger(year);
                if (!double.IsNaN(year) && intYear >= 0 && intYear <= 99)
                {
                    year = 1900 + intYear;
                }

                if (double.IsNaN(year) || double.IsInfinity(year) ||
                    double.IsNaN(month) || double.IsInfinity(month) ||
                    double.IsNaN(date) || double.IsInfinity(date) ||
                    double.IsNaN(hour) || double.IsInfinity(hour) ||
                    double.IsNaN(minute) || double.IsInfinity(minute) ||
                    double.IsNaN(second) || double.IsInfinity(year) ||
                    double.IsNaN(millisecond) || double.IsInfinity(millisecond))
                {
                    timeValue = double.NaN;
                }
                else
                {
                    timeValue = MakeDate(MakeDay(year, month, date), MakeTime(hour, minute, second, millisecond));
                    timeValue = TimeClip(UTC(timeValue));
                }
            }

            var obj = arg.Agent.OrdinaryCreateFromConstructor(arg.NewTarget, arg.NewTarget.Realm.DatePrototype, SpecialObjectType.Date);
            obj.DateValue = timeValue;
            return obj;
        }

        private static ScriptValue Now(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static readonly Regex dateExtendedFormat = new Regex(@"^(?<year>(\d\d\d\d)|((\+|\-)\d\d\d\d\d\d))(\-(?<month>\d\d)(\-(?<day>\d\d)(T(?<hour>\d\d):(?<minute>\d\d)(:(?<second>\d\d)(\.(?<millisecond>\d\d\d))?)?(?<timezone>(Z|(\+|\-)\d\d:\d\d))?)?)?)??$");
        private static readonly Regex toStringFormat = new Regex(@"^(Sun|Mon|Tue|Wed|Thu|Fri|Sat) (?<month>(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)) (?<day>\d\d) (?<year>\d\d\d\d) (?<hour>\d\d):(?<minute>\d\d):(?<second>\d\d) GMT(?<timezone>(\+|\-)\d\d\d\d) \(.+\)$");

        private static ScriptValue Parse([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-date.parse
            var str = arg.Agent.ToString(arg[0]);
            var match = dateExtendedFormat.Match(str);
            if (match.Success)
            {
                throw new NotImplementedException();
            }

            match = toStringFormat.Match(str);
            if (match.Success)
            {
                throw new NotImplementedException();
            }

            return double.NaN;
        }

        private static ScriptValue UTC(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetDate([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-date.prototype.getdate
            var time = ThisTimeValue(arg.Agent, arg.ThisValue);
            if (double.IsNaN(time))
            {
                return double.NaN;
            }

            return ToDateTime(time).ToLocalTime().Day;
        }

        private static ScriptValue GetDay([NotNull] ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetFullYear([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-date.prototype.getfullyear
            var time = ThisTimeValue(arg.Agent, arg.ThisValue);
            if (double.IsNaN(time))
            {
                return double.NaN;
            }

            return ToDateTime(LocalTime(time)).Year;
        }

        private static ScriptValue GetHours(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetMilliseconds(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetMinutes(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetMonth([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-date.prototype.getmonth
            var time = ThisTimeValue(arg.Agent, arg.ThisValue);
            if (double.IsNaN(time))
            {
                return double.NaN;
            }

            return ToDateTime(LocalTime(time)).Month - 1;
        }

        private static ScriptValue GetSeconds(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetTime(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetTimezoneOffset([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-date.prototype.gettimezoneoffset
            var time = ThisTimeValue(arg.Agent, arg.ThisValue);
            if (double.IsNaN(time))
            {
                return double.NaN;
            }

            return (time - LocalTime(time)) / MILLISECONDS_PER_MINUTE;
        }

        private static ScriptValue GetUTCDate([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-date.prototype.getutcdate
            var time = ThisTimeValue(arg.Agent, arg.ThisValue);
            if (double.IsNaN(time))
            {
                return double.NaN;
            }

            return ToDateTime(time).ToUniversalTime().Day;
        }

        private static ScriptValue GetUTCDay(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetUTCFullYear([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-date.prototype.getutcfullyear
            var time = ThisTimeValue(arg.Agent, arg.ThisValue);
            if (double.IsNaN(time))
            {
                return double.NaN;
            }

            return ToDateTime(time).ToUniversalTime().Year;
        }

        private static ScriptValue GetUTCHours(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetUTCMilliseconds(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetUTCMinutes(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetUTCMonth([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-date.prototype.getutcmonth
            var time = ThisTimeValue(arg.Agent, arg.ThisValue);
            if (double.IsNaN(time))
            {
                return double.NaN;
            }

            return ToDateTime(time).ToUniversalTime().Month - 1;
        }

        private static ScriptValue GetUTCSeconds(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetDate(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetFullYear(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetHours(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetMilliseconds(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetMinutes(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetMonth(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetSeconds(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetTime(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetUTCDate(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetUTCFullYear(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetUTCHours(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetUTCMilliseconds(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetUTCMinutes(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetUTCMonth(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetUTCSeconds(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToDateString(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToISOString(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToJSON(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToLocaleDateString(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToLocaleString(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToLocaleTimeString(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToString([NotNull] ScriptArguments arg)
        {
            var timeValue = ThisTimeValue(arg.Agent, arg.ThisValue);
            return ToDateString(timeValue);
        }

        private static ScriptValue ToTimeString(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToUTCString(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ValueOf([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-date.prototype.valueof
            return ThisTimeValue(arg.Agent, arg.ThisValue);
        }

        private static ScriptValue ToPrimitive([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-date.prototype-@@toprimitive
            var obj = arg.ThisValue;
            if (!obj.IsObject)
            {
                throw arg.Agent.CreateTypeError();
            }

            var hint = arg[0];
            ScriptValue.Type tryFirst;
            if (hint == "string" || hint == "default")
            {
                tryFirst = ScriptValue.Type.String;
            }
            else if (hint == "number")
            {
                tryFirst = ScriptValue.Type.Number;
            }
            else
            {
                throw arg.Agent.CreateTypeError();
            }

            return arg.Agent.OrdinaryToPrimitive((ScriptObject)obj, tryFirst);
        }


        private static double LocalTime(double time)
        {
            return time + LocalTZA + DaylightSavingTa(time);
        }

        private static double ThisTimeValue([NotNull] Agent agent, ScriptValue value)
        {
            if (!value.IsObject)
            {
                throw agent.CreateTypeError();
            }

            var obj = (ScriptObject)value;
            if (obj.SpecialObjectType != SpecialObjectType.Date)
            {
                throw agent.CreateTypeError();
            }

            return obj.DateValue;
        }

        private static int DaysInYear(int year)
        {
            //https://tc39.github.io/ecma262/#eqn-DaysInYear
            if (year % 4 != 0)
            {
                return 365;
            }

            if (year % 100 != 0)
            {
                return 366;
            }

            if (year % 400 != 0)
            {
                return 365;
            }

            return 366;
        }

        private static double DayFromYear(double y)
        {
            //https://tc39.github.io/ecma262/#eqn-DaysFromYear
            return 365 * (y - 1970) + Math.Floor((y - 1969) / 4) - Math.Floor((y - 1901) / 100) + Math.Floor((y - 1601) / 400);
        }

        private static int DayFromYear(int y)
        {
            //https://tc39.github.io/ecma262/#eqn-DaysFromYear
            return 365 * (y - 1970) + (y - 1969) / 4 - (y - 1901) / 100 + (y - 1601) / 400;
        }

        private static double TimeFromYear(double y)
        {
            return DayFromYear(y) * MILLISECONDS_PER_DAY;
        }

        private static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }

        private static double DayFromMonth(int month, int year)
        {
            var day = month * 30;

            if (month >= 7) { day += month / 2 - 1; }
            else if (month >= 2) { day += (month - 1) / 2 - 1; }
            else { day += month; }

            if (month >= 2 && IsLeapYear(year)) { ++day; }

            return day;
        }

        private static double UTC(double time)
        {
            //https://tc39.github.io/ecma262/#sec-utc-t
            return time - LocalTZA - DaylightSavingTa(time - LocalTZA);
        }

        private static double DaylightSavingTa(double d)
        {
            var time = ToDateTime(d);
            return (TimeZoneInfo.Local.GetUtcOffset(time) - TimeZoneInfo.Local.BaseUtcOffset).TotalMilliseconds;
        }

        private static DateTime ToDateTime(double time)
        {
            return new DateTime(unixEpoch + (long)time * TimeSpan.TicksPerMillisecond, DateTimeKind.Utc);
        }

        public static double LocalTZA => TimeZoneInfo.Local.BaseUtcOffset.TotalMilliseconds;

        private static double MakeTime(double hour, double minute, double second, double millisecond)
        {
            //https://tc39.github.io/ecma262/#sec-maketime
            if (double.IsInfinity(hour) || double.IsInfinity(minute) || double.IsInfinity(second) || double.IsInfinity(millisecond))
            {
                return double.NaN;
            }

            hour = Agent.ToInteger(hour);
            minute = Agent.ToInteger(minute);
            second = Agent.ToInteger(second);
            millisecond = Agent.ToInteger(millisecond);
            return hour * MILLISECONDS_PER_HOUR + minute * MILLISECONDS_PER_MINUTE + second * MILLISECONDS_PER_SECOND + millisecond;
        }

        private static double MakeDay(double year, double month, double date)
        {
            //https://tc39.github.io/ecma262/#sec-makeday
            if (double.IsInfinity(year) || double.IsInfinity(month) || double.IsInfinity(date))
            {
                return double.NaN;
            }

            year = Agent.ToInteger(year);
            month = Agent.ToInteger(month);
            date = Agent.ToInteger(date);

            year += Math.Floor(month / 12);
            month %= 12;

            var yearDay = Math.Floor(TimeFromYear(year) / MILLISECONDS_PER_DAY);
            var monthDay = DayFromMonth((int)month, (int)year);
            return yearDay + monthDay + date - 1;
        }

        private static double MakeDate(double day, double time)
        {
            //https://tc39.github.io/ecma262/#sec-makedate
            return day * MILLISECONDS_PER_DAY + time;
        }

        [NotNull]
        private static string ToDateString(double tv)
        {
            //https://tc39.github.io/ecma262/#sec-todatestring
            if (double.IsNaN(tv))
            {
                return "Invalid Date";
            }

            return ToDateString(ToDateTime(tv));
        }

        [NotNull]
        private static string ToDateString(DateTime dateTime)
        {
            return $"{DateString(dateTime)} {TimeString(dateTime)}{TimeZoneString(dateTime)}";
        }

        [NotNull]
        private static string TimeZoneString(DateTime tv)
        {
            var offset = TimeZoneInfo.Local.GetUtcOffset(tv);
            var sign = offset.TotalMilliseconds > 0 ? "+" : "-";
            offset = TimeSpan.FromTicks(Math.Abs(offset.Ticks));
            return $"{sign}{offset.Hours:D2}{offset.Minutes:D2} ({TimeZoneInfo.Local.StandardName})";
        }

        [NotNull]
        private static string TimeString(DateTime time)
        {
            return $"{time.Hour:D2}:{time.Minute:D2}:{time.Second:D2} GMT";
        }

        private static double TimeClip(double time)
        {
            //https://tc39.github.io/ecma262/#sec-timeclip
            if (double.IsInfinity(time))
            {
                return double.NaN;
            }

            if (Math.Abs(time) > 8.64E15)
            {
                return double.NaN;
            }

            var clippedTime = Agent.ToInteger(time);
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (clippedTime == -0)
            {
                clippedTime = 0;
            }

            return clippedTime;
        }

        private static readonly string[] weekDayLookup =
        {
            "Sun",
            "Mon",
            "Tue",
            "Wed",
            "Thu",
            "Fri",
            "Sat"
        };

        private static readonly string[] monthLookup =
        {
            "Jan",
            "Feb",
            "Mar",
            "Apr",
            "May",
            "Jun",
            "Jul",
            "Aug",
            "Sep",
            "Oct",
            "Nov",
            "Dec"
        };

        private static readonly long unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local).Ticks;

        [NotNull]
        private static string DateString(DateTime time)
        {
            //https://tc39.github.io/ecma262/#sec-datestring

            var weekday = weekDayLookup[(int)time.DayOfWeek];
            var month = monthLookup[time.Month - 1];
            var day = time.Day.ToString("D2", CultureInfo.InvariantCulture);
            var intYear = time.Year;
            var year = intYear < 1000 ? intYear.ToString("D4", CultureInfo.InvariantCulture) : intYear.ToString(CultureInfo.InvariantCulture);
            //Fucking american date format
            return weekday + " " + month + " " + day + " " + year;
        }
    }
}