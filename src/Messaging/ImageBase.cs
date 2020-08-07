using Newtonsoft.Json;
using System;

namespace HuajiTech.Mirai.Messaging
{
    public abstract class ImageBase : MessageElement
    {
        [JsonProperty(PropertyName = "imageId", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        [JsonProperty(PropertyName = "path", NullValueHandling = NullValueHandling.Ignore)]
        public string FilePath { get; }

        [JsonIgnore]
        public Uri Uri { get; }

        [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
        internal string AbsoluteUri => Uri?.AbsoluteUri;

        public ImageBase(string str, ImageSource source)
        {
            switch (source)
            {
                case ImageSource.Id:
                    Id = str;
                    break;
                case ImageSource.Uri:
                    Uri = new Uri(str);
                    break;
                case ImageSource.File:
                    FilePath = str;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(str));
            }
        }

        public ImageBase(string id) => Id = id;

        public ImageBase(Uri uri) => Uri = uri ?? throw new ArgumentNullException(nameof(uri));

        internal ImageBase(string id, string filePath, Uri uri)
        {
            Id = id;
            FilePath = filePath;
            Uri = uri ?? throw new ArgumentNullException(nameof(uri));
        }
    }

    public enum ImageSource
    {
        Id,
        Uri,
        File
    }
}
