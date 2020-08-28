using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json;
using System;

namespace HuajiTech.Mirai.Interop.Messaging
{
    internal class ImageInfo
    {
        [JsonProperty(PropertyName = "imageId")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "path")]
        public string FilePath { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Uri { get; set; }

        public Image ToImage() => new Image(Id, FilePath, new Uri(Uri));

        public FlashImage ToFlashImage() => new FlashImage(Id, FilePath, new Uri(Uri));
    }
}