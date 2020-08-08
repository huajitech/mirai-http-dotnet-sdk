using System;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 定义 Session 设置
    /// </summary>
    public class SessionSettings
    {
        /// <summary>
        /// 获取当前 <see cref="SessionSettings"/> 实例的 URI
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        /// 获取当前 <see cref="SessionSettings"/> 实例的 Auth Key
        /// </summary>
        public string AuthKey { get; private set; }

        /// <summary>
        /// 获取当前 <see cref="SessionSettings"/> 实例的机器人号码
        /// </summary>
        public long BotNumber { get; private set; }

        /// <summary>
        /// 创建 <see cref="SessionSettings"/> 实例
        /// </summary>
        /// <param name="uri">指定 <see cref="SessionSettings"/> 实例的 URI</param>
        /// <param name="authKey">指定 <see cref="SessionSettings"/> 实例的 Auth Key</param>
        /// <param name="botNumber">指定 <see cref="SessionSettings"/> 实例的机器人号码</param>
        public SessionSettings(Uri uri, string authKey, long botNumber)
        {
            Uri = uri ?? throw new ArgumentNullException(nameof(uri));
            AuthKey = authKey ?? throw new ArgumentNullException(nameof(authKey));
            BotNumber = botNumber;
        }

        /// <summary>
        /// 创建 <see cref="SessionSettings"/> 实例
        /// </summary>
        /// <param name="address">指定 <see cref="SessionSettings"/> 实例的 URI 地址</param>
        /// <param name="port">指定 <see cref="SessionSettings"/> 实例的 URI 端口</param>
        /// <param name="authKey">指定 <see cref="SessionSettings"/> 实例的 Auth Key</param>
        /// <param name="botNumber">指定 <see cref="SessionSettings"/> 实例的机器人号码</param>
        public SessionSettings(string address, int port, string authKey, long botNumber)
        {
            Uri = new UriBuilder(Uri.UriSchemeHttp, address, port).Uri;
            AuthKey = authKey ?? throw new ArgumentNullException(nameof(authKey));
            BotNumber = botNumber;
        }
    }
}