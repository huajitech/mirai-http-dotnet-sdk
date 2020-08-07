using System;
using System.Collections.Generic;
using System.Text;

namespace HuajiTech.Mirai.Utilities
{
    internal class TimestampUtilities
    {
        public static readonly DateTime Zero = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1), TimeZoneInfo.Local);

        public static DateTime ToDateTime(int timestamp) => Zero.AddSeconds(timestamp);

        public static double FromDateTime(DateTime time) => (time - Zero).TotalSeconds;
    }
}
