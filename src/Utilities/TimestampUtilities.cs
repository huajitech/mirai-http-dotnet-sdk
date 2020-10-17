using System;

namespace HuajiTech.Mirai.Utilities
{
    /// <summary>
    /// 提供 <see cref="DateTime"/> 与时间戳之间的转换方法
    /// </summary>
    internal static class TimestampUtilities
    {
        /// <summary>
        /// 表示时间戳起始值所对应的 <see cref="DateTime"/> 实例
        /// </summary>
        public static readonly DateTime Zero = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1), TimeZoneInfo.Local);

        /// <summary>
        /// 转换时间戳到 <see cref="DateTime"/> 实例
        /// </summary>
        /// <param name="timestamp">要转换的时间戳</param>
        public static DateTime ToDateTime(int timestamp) => Zero.AddSeconds(timestamp);

        /// <summary>
        /// 转换 <see cref="DateTime"/> 实例到时间戳
        /// </summary>
        /// <param name="time">要转换的 <see cref="DateTime"/> 实例</param>
        /// <returns></returns>
        public static double FromDateTime(DateTime time) => (time - Zero).TotalSeconds;
    }
}