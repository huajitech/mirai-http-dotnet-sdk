using System.Net.Http;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http.Utilities
{
    /// <summary>
    /// 提供与 HTTP 交互的方法
    /// </summary>
    internal static class ApiHttpUtilities
    {
        /// <summary>
        /// 异步通过 Get 方式获取字符串形式的内容
        /// </summary>
        /// <param name="uri">目标 URI</param>
        public static Task<string> GetAsync(string uri)
        {
            var client = new HttpClient();

            try
            {
                return client.GetStringAsync(uri);
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException(Resources.CannotConnectToApi, e); 
            }
        }

        /// <summary>
        /// 异步通过 Post 方式获取字符串形式的内容
        /// </summary>
        /// <param name="uri">目标 URI</param>
        /// <param name="content">要 Post 的内容</param>
        public static async Task<string> PostAsync(string uri, string content)
        {
            var client = new HttpClient();

            try
            {
                var res = (await client.PostAsync(uri, new StringContent(content))).EnsureSuccessStatusCode();
                return await res.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException(Resources.CannotConnectToApi, e);
            }
        }
    }
}