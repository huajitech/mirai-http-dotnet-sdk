﻿using System;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http
{
    /// <summary>
    /// 定义 <see cref="CurrentUser"/> 的扩展方法
    /// </summary>
    public static class CurrentUserExtensions
    {
        /// <summary>
        /// 异步获取指定 ID 的消息
        /// </summary>
        /// <param name="currentUser">当前用户</param>
        /// <param name="id">消息 ID</param>
        /// <returns>指定 ID 的 <see cref="Message"/> 实例</returns>
        public static Task<Message> GetMessageAsync(this CurrentUser currentUser, int id) => Message.GetMessageAsync(currentUser ?? throw new ArgumentNullException(nameof(currentUser)), id);

        /// <summary>
        /// 异步撤回指定 ID 的消息
        /// </summary>
        /// <param name="currentUser">当前用户</param>
        /// <param name="id">消息 ID</param>
        /// <returns>指定 ID 的 <see cref="Message"/> 实例</returns>
        public static Task RecallMessageAsync(this CurrentUser currentUser, int id) => Message.RecallMessageAsync(currentUser?.Session ?? throw new ArgumentNullException(nameof(currentUser)), id);
    }
}