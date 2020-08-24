using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json;
using System;

namespace HuajiTech.Mirai.Interop.Messaging
{
    internal class VoiceInfo
    {
        [JsonProperty(PropertyName = "imageId")]
        public string Id { get; }

        [JsonProperty(PropertyName = "path")]
        public string FilePath { get; }

        [JsonProperty(PropertyName = "url")]
        public string Uri { get; }

        public Voice ToVoice() => new Voice(Id, FilePath, new Uri(Uri));

        public VoiceInfo(string id, string path, string uri)
        {
            Id = id;
            FilePath = path;
            Uri = uri;
        }
    }
}