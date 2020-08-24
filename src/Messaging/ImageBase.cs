using Newtonsoft.Json;
using System;

namespace HuajiTech.Mirai.Messaging
{
    /// <summary>
    /// 表示属于图片的 <see cref="MessageElement"/>
    /// </summary>
    public abstract class ImageBase : MessageElement
    {
        /// <summary>
        /// 获取当前 <see cref="ImageBase"/> 实例的 ID
        /// </summary>
        [JsonProperty(PropertyName = "imageId", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// 获取当前 <see cref="ImageBase"/> 实例的相对文件路径
        /// </summary>
        [JsonProperty(PropertyName = "path", NullValueHandling = NullValueHandling.Ignore)]
        public string FilePath { get; }

        /// <summary>
        /// 获取当前 <see cref="ImageBase"/> 实例的 URI
        /// </summary>
        [JsonIgnore]
        public Uri Uri { get; }

        /// <summary>
        /// 指定当前 <see cref="ImageBase"/> 实例的 URI 绝对路径
        /// </summary>
        [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
        internal string AbsoluteUri => Uri?.AbsoluteUri;

        /// <summary>
        /// 创建 <see cref="ImageBase"/> 实例
        /// </summary>
        /// <param name="str">指定 <see cref="ImageBase"/> 实例的字符串（可为 ID、字符串形式的 URI、相对文件路径）</param>
        /// <param name="source">指定 <see cref="ImageBase"/> 实例的来源</param>
        public ImageBase(string str, ElementSource source)
        {
            switch (source)
            {
                case ElementSource.Id:
                    Id = str;
                    break;
                case ElementSource.Uri:
                    Uri = new Uri(str);
                    break;
                case ElementSource.File:
                    FilePath = str;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(str));
            }
        }

        /// <summary>
        /// 创建 <see cref="ImageBase"/> 实例
        /// </summary>
        /// <param name="id">指定 <see cref="ImageBase"/> 实例的 ID</param>
        public ImageBase(string id) => Id = id;

        /// <summary>
        /// 创建 <see cref="ImageBase"/> 实例
        /// </summary>
        /// <param name="uri">指定 <see cref="ImageBase"/> 实例的 URI</param>
        public ImageBase(Uri uri) => Uri = uri ?? throw new ArgumentNullException(nameof(uri));

        /// <summary>
        /// 创建 <see cref="ImageBase"/> 实例
        /// </summary>
        /// <param name="id">指定 <see cref="ImageBase"/> 实例的 ID</param>
        /// <param name="filePath">指定 <see cref="ImageBase"/> 实例的相对文件路径</param>
        /// <param name="uri">指定 <see cref="ImageBase"/> 实例的 URI</param>
        internal ImageBase(string id, string filePath, Uri uri)
        {
            Id = id;
            FilePath = filePath;
            Uri = uri ?? throw new ArgumentNullException(nameof(uri));
        }
    }
}