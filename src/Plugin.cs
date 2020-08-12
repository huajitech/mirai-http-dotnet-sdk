﻿using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 用作插件的基类
    /// </summary>
    public abstract class Plugin : SessionProcessor
    {
        /// <summary>
        /// 异步初始化 <see cref="Plugin"/> 类型的可重写方法
        /// </summary>
        internal protected virtual async Task Initialize() => await Task.Delay(0);

        /// <summary>
        /// 获取当前 <see cref="Plugin"/> 实例的当前用户
        /// </summary>
        protected CurrentUser CurrentUser => new CurrentUser(Session);

        /// <summary>
        /// 异步获取指定 ID 的消息
        /// </summary>
        /// <param name="id">消息 ID</param>
        /// <returns>指定 ID 的 <see cref="Message"/> 实例</returns>
        protected async Task<Message> GetMessageAsync(int id) => await Message.GetMessageAsync(CurrentUser, id);
    }
}