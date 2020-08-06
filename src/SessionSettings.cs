using System;

namespace HuajiTech.Mirai
{
    public class SessionSettings
    {
        public Uri Uri { get; private set; }

        public string AuthKey { get; private set; }

        public long BotNumber { get; private set; }

        public SessionSettings(Uri uri, string authKey, long botNumber)
        {
            Uri = uri ?? throw new ArgumentNullException(nameof(uri));
            AuthKey = authKey ?? throw new ArgumentNullException(nameof(authKey));
            BotNumber = botNumber;
        }

        public SessionSettings(string hostName, int port, string authKey, long botNumber)
        {
            Uri = new UriBuilder(Uri.UriSchemeHttp, hostName, port).Uri;
            AuthKey = authKey ?? throw new ArgumentNullException(nameof(authKey));
            BotNumber = botNumber;
        }
    }
}