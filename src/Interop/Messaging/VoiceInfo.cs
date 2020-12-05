﻿using HuajiTech.Mirai.Http.Messaging;
using Newtonsoft.Json;
using System;

namespace HuajiTech.Mirai.Http.Interop.Messaging
{
    internal class VoiceInfo
    {
        [JsonProperty(PropertyName = "voiceId")]
        public string Id { get; init; }

        [JsonProperty(PropertyName = "path")]
        public string FilePath { get; init; }

        [JsonProperty(PropertyName = "url")]
        public string Uri { get; init; }

        private Uri GetUri() => Uri == null ? null : new(Uri);

        public Voice ToVoice() => new(Id, FilePath, GetUri());
    }
}