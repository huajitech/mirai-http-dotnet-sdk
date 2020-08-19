﻿using HuajiTech.Mirai.ApiHandlers;
using HuajiTech.Mirai.Events;
using System.Threading.Tasks;

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
        internal protected CurrentUser CurrentUser => new CurrentUser(Session);

        /// <summary>
        /// 获取当前用户事件源
        /// </summary>
        internal protected CurrentUserEventSource CurrentUserEventSource { get; }

        /// <summary>
        /// 获取好友事件源
        /// </summary>
        internal protected FriendEventSource FriendEventSource { get; }

        /// <summary>
        /// 获取群事件源
        /// </summary>
        internal protected GroupEventSource GroupEventSource { get; }

        /// <summary>
        /// 获取成员事件源
        /// </summary>
        internal protected MemberEventSource MemberEventSource { get; }

        /// <summary>
        /// 异步绑定 <see cref="Session"/> 实例
        /// </summary>
        /// <param name="session">要绑定的 <see cref="Session"/> 实例</param>
        public async Task BindAsync(Session session)
        {
            SetSession(session);
            await Initialize();
        }

        /// <summary>
        /// 异步监听事件
        /// </summary>
        /// <returns></returns>
        public async Task ListenAsync()
        {
            var events = new ApiEventHandler(this);
            await events.ListenAsync();
        }

        /// <summary>
        /// 创建 <see cref="Plugin"/> 实例
        /// </summary>
        public Plugin()
        {
            CurrentUserEventSource = new CurrentUserEventSource(Session);
            FriendEventSource = new FriendEventSource(Session);
            GroupEventSource = new GroupEventSource(Session);
            MemberEventSource = new MemberEventSource(Session);
        }
    }
}