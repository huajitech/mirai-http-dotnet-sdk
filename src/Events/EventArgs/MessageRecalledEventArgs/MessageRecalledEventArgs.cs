using System;

namespace HuajiTech.Mirai.Http.Events
{
    /// <summary>
    /// 为消息撤回事件提供数据
    /// </summary>
    public class MessageRecalledEventArgs : EventArgs
    {
        /// <summary>
        /// 获取当前 <see cref="MessageRecalledEventArgs"/> 实例的操作用户
        /// </summary>
        public virtual User Operator { get; }

        /// <summary>
        /// 获取当前 <see cref="MessageRecalledEventArgs"/> 实例的目标用户
        /// </summary>
        public virtual User Target { get; }

        /// <summary>
        /// 获取当前 <see cref="MessageRecalledEventArgs"/> 实例的消息
        /// </summary>
        public virtual Message Message { get; }

        /// <summary>
        /// 创建 <see cref="MessageRecalledEventArgs"/> 实例
        /// </summary>
        /// <param name="operator">指定 <see cref="MessageRecalledEventArgs"/> 实例的操作用户</param>
        /// <param name="target">指定 <see cref="MessageRecalledEventArgs"/> 实例的目标用户</param>
        /// <param name="message">指定 <see cref="MessageRecalledEventArgs"/> 实例的消息</param>
        internal MessageRecalledEventArgs(User @operator, User target, Message message)
        {
            Operator = @operator;
            Target = target;
            Message = message;
        }
    }
}