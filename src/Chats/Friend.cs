﻿using HuajiTech.Mirai.Sessions;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 定义好友
    /// </summary>
    public class Friend : User
    {
        internal override async Task<string> InternalSendAsync(MessageElement[] message) => await HttpSessions.SendFriendMessageAsync(Session.Settings.Uri, Session.SessionKey, Number, message);

        /// <summary>
        /// 获取当前 <see cref="Friend"/> 实例的昵称
        /// </summary>
        public string Nickname { get; }

        /// <summary>
        /// 获取当前 <see cref="Friend"/> 实例的别名
        /// </summary>
        public string Alias { get; }

        /// <summary>
        /// 创建 <see cref="Friend"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="Friend"/> 实例所使用的 Session</param>
        /// <param name="number">指定 <see cref="Friend"/> 实例的号码</param>
        /// <param name="nickname">指定 <see cref="Friend"/> 实例的昵称</param>
        /// <param name="alias">指定 <see cref="Friend"/> 实例的别名</param>
        internal Friend(Session session, long number, string nickname, string alias) : base(session, number)
        {
            Nickname = nickname;
            Alias = alias;
        }
    }
}