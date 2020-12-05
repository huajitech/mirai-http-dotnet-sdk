using System.Linq;

namespace HuajiTech.Mirai.Http.Utilities
{
    /// <summary>
    /// 提供实例转换为类型字符串的方法
    /// </summary>
    internal static class TypeStringUtilities
    {
        /// <summary>
        /// 实例转换为类型字符串的格式
        /// </summary>
        private static readonly string TypeStringFormat = "[{0}({1})]";

        /// <summary>
        /// 以字符串形式表达 <see langword="null"/>
        /// </summary>
        private static readonly string NullString = "null";

        /// <summary>
        /// 转换到类型字符串
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        /// <param name="t">将要转换到类型字符串的实例</param>
        /// <returns>表达该实例的字符串</returns>
        public static string ToTypeString<T>(T t)
        {
            var type = t.GetType();
            var properties = type.GetProperties();
            var strs = properties.Select(x => $"{x.Name}:{x.GetValue(t, null) ?? NullString}");
            string str = string.Join(',', strs);
            return string.Format(TypeStringFormat, type.Name, str);
        }
    }
}