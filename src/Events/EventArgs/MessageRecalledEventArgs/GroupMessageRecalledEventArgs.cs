namespace HuajiTech.Mirai.Http.Events
{
    /// <summary>
    /// 为群消息撤回事件提供数据
    /// </summary>
    public class GroupMessageRecalledEventArgs : MessageRecalledEventArgs
    {
        /// <summary>
        /// 获取当前 <see cref="GroupMessageRecalledEventArgs"/> 实例的操作用户
        /// </summary>
        public virtual new Member Operator { get; }

        /// <summary>
        /// 获取当前 <see cref="GroupMessageRecalledEventArgs"/> 实例的目标用户
        /// </summary>
        public virtual new Member Target { get; }

        /// <summary>
        /// 创建 <see cref="GroupMessageRecalledEventArgs"/> 实例
        /// </summary>
        /// <param name="operator">指定 <see cref="GroupMessageRecalledEventArgs"/> 实例的操作用户</param>
        /// <param name="target">指定 <see cref="GroupMessageRecalledEventArgs"/> 实例的目标用户</param>
        /// <param name="message">指定 <see cref="GroupMessageRecalledEventArgs"/> 实例的消息</param>
        internal GroupMessageRecalledEventArgs(Member @operator, Member target, Message message) : base(@operator, target, message)
        {
            Operator = @operator;
            Target = target;
        }
    }
}