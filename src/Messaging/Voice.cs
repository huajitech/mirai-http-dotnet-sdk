﻿using Newtonsoft.Json;
using System;

namespace HuajiTech.Mirai.Http.Messaging
{
    /// <summary>
    /// 表示语音的 <see cref="MessageElement"/>
    /// </summary>
    public class Voice : MessageElement, IMediaElement
    {
        internal override string Type { get; } = "Voice";

        /// <inheritdoc/>
        [JsonProperty(PropertyName = "voiceId", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <inheritdoc/>
        [JsonProperty(PropertyName = "path", NullValueHandling = NullValueHandling.Ignore)]
        public string FilePath { get; }

        /// <inheritdoc/>
        [JsonIgnore]
        public Uri Uri { get; }

        /// <summary>
        /// 指定当前 <see cref="Voice"/> 实例的 URI 绝对路径
        /// </summary>
        [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
        internal string AbsoluteUri => Uri?.AbsoluteUri;

        /// <summary>
        /// 创建 <see cref="Voice"/> 实例
        /// </summary>
        /// <param name="str">指定 <see cref="Voice"/> 实例的字符串（可为 ID、字符串形式的 URI、相对文件路径）</param>
        /// <param name="source">指定 <see cref="Voice"/> 实例的来源</param>
        public Voice(string str, ElementSource source)
        {
            switch (source)
            {
                case ElementSource.Id:
                    Id = str;
                    break;
                case ElementSource.Uri:
                    Uri = new(str);
                    break;
                case ElementSource.File:
                    FilePath = str;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(str));
            }
        }

        /// <summary>
        /// 创建 <see cref="Voice"/> 实例
        /// </summary>
        /// <param name="id">指定 <see cref="Voice"/> 实例的 ID</param>
        public Voice(string id) => Id = id;

        /// <summary>
        /// 创建 <see cref="Voice"/> 实例
        /// </summary>
        /// <param name="uri">指定 <see cref="Voice"/> 实例的 URI</param>
        public Voice(Uri uri) => Uri = uri ?? throw new ArgumentNullException(nameof(uri));

        /// <summary>
        /// 创建 <see cref="Voice"/> 实例
        /// </summary>
        /// <param name="id">指定 <see cref="Voice"/> 实例的 ID</param>
        /// <param name="filePath">指定 <see cref="Voice"/> 实例的相对文件路径</param>
        /// <param name="uri">指定 <see cref="Voice"/> 实例的 URI</param>
        internal Voice(string id, string filePath, Uri uri)
        {
            Id = id;
            FilePath = filePath;
            Uri = uri;
        }
    }
}