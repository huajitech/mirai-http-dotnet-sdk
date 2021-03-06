﻿using HuajiTech.Mirai.Http.Messaging;
using Newtonsoft.Json;

namespace HuajiTech.Mirai.Http.Interop.Messaging
{
    internal class FaceInfo
    {
        [JsonProperty(PropertyName = "faceId")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public Emoticon ToEmoticon() => new Emoticon(Id, Name);
    }
}