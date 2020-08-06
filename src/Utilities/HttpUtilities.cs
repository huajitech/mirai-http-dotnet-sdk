using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Utilities
{
    internal static class HttpUtilities
    {
        private static async Task<string> ReadAsStringAsync(HttpResponseMessage message) => message.IsSuccessStatusCode ? await message.Content.ReadAsStringAsync() : throw new HttpRequestException(string.Format(Resources.CannotConnectToApi, message.StatusCode));

        public static async Task<string> GetAsync(Uri uri) => await ReadAsStringAsync(await new HttpClient().GetAsync(uri));

        public static async Task<string> GetAsync(string uri) => await ReadAsStringAsync(await new HttpClient().GetAsync(uri));

        public static async Task<string> PostAsync(Uri uri, string content) => await ReadAsStringAsync(await new HttpClient().PostAsync(uri, new StringContent(content)));

        public static async Task<string> PostAsync(string uri, string content) => await ReadAsStringAsync(await new HttpClient().PostAsync(uri, new StringContent(content)));
    }
}