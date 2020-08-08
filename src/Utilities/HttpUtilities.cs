using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Utilities
{
    /// <summary>
    /// 提供与 HTTP 交互的方法
    /// </summary>
    internal static class HttpUtilities
    {
        /// <summary>
        /// 异步获取 <see cref="HttpResponseMessage"/> 实例的字符串形式内容
        /// </summary>
        /// <param name="message">要获取内容的 <see cref="HttpResponseMessage"/> 实例</param>
        private static async Task<string> ReadAsStringAsync(HttpResponseMessage message) => message.IsSuccessStatusCode ? await message.Content.ReadAsStringAsync() : throw new HttpRequestException(string.Format(Resources.CannotConnectToApi, message.StatusCode));

        /// <summary>
        /// 异步通过 Get 方式获取字符串形式的内容
        /// </summary>
        /// <param name="uri">目标 URI</param>
        public static async Task<string> GetAsync(Uri uri) => await ReadAsStringAsync(await new HttpClient().GetAsync(uri));

        /// <summary>
        /// 异步通过 Get 方式获取字符串形式的内容
        /// </summary>
        /// <param name="uri">目标 URI</param>
        public static async Task<string> GetAsync(string uri) => await ReadAsStringAsync(await new HttpClient().GetAsync(uri));

        /// <summary>
        /// 异步通过 Post 方式获取字符串形式的内容
        /// </summary>
        /// <param name="uri">目标 URI</param>
        /// <param name="content">要 Post 的内容</param>
        public static async Task<string> PostAsync(Uri uri, string content) => await ReadAsStringAsync(await new HttpClient().PostAsync(uri, new StringContent(content)));

        /// <summary>
        /// 异步通过 Post 方式获取字符串形式的内容
        /// </summary>
        /// <param name="uri">目标 URI</param>
        /// <param name="content">要 Post 的内容</param>
        public static async Task<string> PostAsync(string uri, string content) => await ReadAsStringAsync(await new HttpClient().PostAsync(uri, new StringContent(content)));
    }
}