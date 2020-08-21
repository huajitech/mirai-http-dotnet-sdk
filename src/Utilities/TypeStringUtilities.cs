using System.Linq;

namespace HuajiTech.Mirai.Utilities
{
    internal static class TypeStringUtilities
    {
        private static readonly string TypeStringFormat = "[{0}({1})]";

        public static string ToTypeString<T>(T t)
        {
            var type = t.GetType();
            var properties = type.GetProperties();
            var strs = properties.Select(x => $"{x.Name}:{x.GetValue(t, null)}");
            string str = string.Join(',', strs);
            return string.Format(TypeStringFormat, type.Name, str);
        }
    }
}