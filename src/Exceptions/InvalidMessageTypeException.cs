using System;

namespace HuajiTech.Mirai.Http
{
    /// <summary>
    /// 消息类型无效时所引发的异常
    /// </summary>
    public class InvalidMessageTypeException : Exception
    {
        /// <summary>
        /// 创建 <see cref="InvalidMessageTypeException"/> 实例
        /// </summary>
        /// <param name="type">消息元素类型</param>
        public InvalidMessageTypeException(string type) : base(string.Format(Resources.InvalidMessageType, type))
        {
        }
    }
}