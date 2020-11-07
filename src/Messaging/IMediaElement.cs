using System;

namespace HuajiTech.Mirai.Messaging
{
    /// <summary>
    /// 表示媒体元素
    /// </summary>
    public interface IMediaElement
    {
        /// <summary>
        /// 获取当前 <see cref="IMediaElement"/> 实例的 ID
        /// </summary>
        string Id { get; }

        /// <summary>
        /// 获取当前 <see cref="IMediaElement"/> 实例的相对文件路径
        /// </summary>
        string FilePath { get; }

        /// <summary>
        /// 获取当前 <see cref="IMediaElement"/> 实例的 URI
        /// </summary>
        Uri Uri { get; }
    }
}
