using System;

namespace HuajiTech.Mirai.Http
{
    /// <summary>
    /// 消息格式不正确时所引发的异常
    /// </summary>
    public class MessageFormatException : Exception
    {
        /// <summary>
        /// 创建 <see cref="MessageFormatException"/> 实例
        /// </summary>
        /// <param name="type">消息元素类型</param>
        internal MessageFormatException(string type) : base(string.Format(Resources.UnexpectedMessageFormat, type))
        {
        }
    }
}