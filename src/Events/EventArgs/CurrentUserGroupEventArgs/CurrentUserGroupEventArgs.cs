using System;

namespace HuajiTech.Mirai.Events
{
    /// <summary>
    /// 为当前用户群事件提供数据
    /// </summary>
    public class CurrentUserGroupEventArgs : EventArgs
    {
        /// <summary>
        /// 获取当前 <see cref="CurrentUserGroupEventArgs"/> 实例的来源
        /// </summary>
        public Group Source { get; }

        /// <summary>
        /// 创建 <see cref="CurrentUserGroupEventArgs"/> 实例
        /// </summary>
        /// <param name="source">指定 <see cref="CurrentUserGroupEventArgs"/> 实例的来源</param>
        internal CurrentUserGroupEventArgs(Group source) => Source = source;
    }
}