using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json;
using System;

namespace HuajiTech.Mirai.Interop.Messaging
{
    internal class ImageInfo
    {
        [JsonProperty(PropertyName = "imageId")]
        public string Id { get; init; }

        [JsonProperty(PropertyName = "path")]
        public string FilePath { get; init; }

        [JsonProperty(PropertyName = "url")]
        public string Uri { get; init; }

        private Uri GetUri() => Uri == null ? null : new(Uri);

        public Image ToImage() => new(Id, FilePath, GetUri());

        public FlashImage ToFlashImage() => new(Id, FilePath, GetUri());
    }
}