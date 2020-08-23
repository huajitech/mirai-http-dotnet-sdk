using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json;
using System;

namespace HuajiTech.Mirai.Interop.Messaging
{
    internal class ImageInfo
    {
        [JsonProperty(PropertyName = "imageId")]
        public string Id { get; }

        [JsonProperty(PropertyName = "path")]
        public string FilePath { get; }

        [JsonProperty(PropertyName = "url")]
        public string Uri { get; }

        public Image ToImage() => new Image(Id, FilePath, new Uri(Uri));

        public FlashImage ToFlashImage() => new FlashImage(Id, FilePath, new Uri(Uri));

        public ImageInfo(string id, string path, string uri)
        {
            Id = id;
            FilePath = path;
            Uri = uri;
        }
    }
}