using System;
using System.Collections.Generic;
using System.Text;

namespace HuajiTech.Mirai.Messaging
{
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
