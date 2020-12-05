namespace HuajiTech.Mirai.Http
{
    /// <summary>
    /// 定义 <see cref="Mirai"/> 内部的扩展方法
    /// </summary>
    internal static class InternalExtensions
    {
        /// <summary>
        /// 检查字符串是否为空
        /// </summary>
        /// <param name="str">要检查的字符串</param>
        /// <returns>如果字符串为 <see langword="null"/> 或为空，则返回 <see langword="null"/>，否则返回原字符串</returns>
        internal static string CheckEmpty(this string str) => string.IsNullOrEmpty(str) ? null : str;
    }
}