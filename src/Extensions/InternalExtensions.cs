namespace HuajiTech.Mirai.Extensions
{
    internal static class InternalExtensions
    {
        internal static string CheckEmpty(this string str) => string.IsNullOrEmpty(str) ? null : str;
    }
}
