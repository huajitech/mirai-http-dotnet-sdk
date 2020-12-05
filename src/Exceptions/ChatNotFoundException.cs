using System;

namespace HuajiTech.Mirai.Http
{
    /// <summary>
    /// 所指定的 <see cref="Chat"/> 未找到时引发的异常
    /// </summary>
    public class ChatNotFoundException : Exception
    {
        /// <summary>
        /// 创建 <see cref="ChatNotFoundException"/> 实例
        /// </summary>
        /// <param name="type">指定 <see cref="Chat"/> 的类型</param>
        /// <param name="number">指定 <see cref="Chat"/> 的号码</param>
        internal ChatNotFoundException(Type type, long number) : base(string.Format(Resources.ChatNotFound, type.Name, number))
        {
        }
    }
}