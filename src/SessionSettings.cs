using System;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 定义 Session 设置
    /// </summary>
    public class SessionSettings
    {
        /// <summary>
        /// 获取当前 <see cref="SessionSettings"/> 实例的 HTTP URI
        /// </summary>
        public string HttpUri { get; }

        /// <summary>
        /// 获取当前 <see cref="SessionSettings"/> 实例的 WebSocket URI
        /// </summary>
        public string WebsocketUri { get; }

        /// <summary>
        /// 获取当前 <see cref="SessionSettings"/> 实例的 Auth Key
        /// </summary>
        public string AuthKey { get; }

        /// <summary>
        /// 获取当前 <see cref="SessionSettings"/> 实例的机器人号码
        /// </summary>
        public long BotNumber { get; }

        /// <summary>
        /// Specifies that the URI is accessed through the Websocket.
        /// This field is read-only.
        /// </summary>
        private readonly string UriSchemeWebsocket = "ws";

        /// <summary>
        /// 创建 <see cref="SessionSettings"/> 实例
        /// </summary>
        /// <param name="address">指定 <see cref="SessionSettings"/> 实例的 URI 地址</param>
        /// <param name="port">指定 <see cref="SessionSettings"/> 实例的 URI 端口</param>
        /// <param name="authKey">指定 <see cref="SessionSettings"/> 实例的 Auth Key</param>
        /// <param name="botNumber">指定 <see cref="SessionSettings"/> 实例的机器人号码</param>
        public SessionSettings(string address, int port, string authKey, long botNumber)
        {
            HttpUri = new UriBuilder(Uri.UriSchemeHttp, address, port).Uri.AbsoluteUri;
            WebsocketUri = new UriBuilder(UriSchemeWebsocket, address, port).Uri.AbsoluteUri;
            AuthKey = authKey ?? throw new ArgumentNullException(nameof(authKey));
            BotNumber = botNumber;
        }
    }
}