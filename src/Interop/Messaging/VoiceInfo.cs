using HuajiTech.Mirai.Http.Messaging;
using Newtonsoft.Json;
using System;

namespace HuajiTech.Mirai.Http.Interop.Messaging
{
    internal class VoiceInfo
    {
        [JsonProperty(PropertyName = "voiceId")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "path")]
        public string FilePath { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Uri { get; set; }

        private Uri GetUri() => Uri == null ? null : new Uri(Uri);

        public Voice ToVoice() => new Voice(Id, FilePath, GetUri());
    }
}