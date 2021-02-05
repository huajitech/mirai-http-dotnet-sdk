using HuajiTech.Mirai.Http.Interop.Messaging;
using HuajiTech.Mirai.Http.Messaging;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace HuajiTech.Mirai.Http.Parsing
{
    /// <summary>
    /// 用作解析群消息的 <see cref="MessageParser"/>
    /// </summary>
    internal class GroupMessageParser : MessageParser
    {
        protected override MessageElement ParseExt(JObject element) => element.Value<string>("type") == "Quote" ? ToQuote(element) : throw new InvalidMessageTypeException(element.Value<string>("type"));

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Quote"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的引用回复</param>
        private Quote ToQuote(JObject element)
        {
            var info = element.ToObject<QuoteInfo>();
            var message = new Message(CurrentUser.Session, ParseMore(info.Origin).ToList());

            try
            {
                var target = CurrentUser.GetGroupAsync(info.TargetId).Result;
                var sender = target.GetMemberAsync(info.SenderId).Result;

                return new Quote(message, sender, target);
            }
            catch (AggregateException)
            {
                var target = new Group(CurrentUser, info.TargetId, null, default);
                var sender = new Member(target, info.SenderId, null, default);

                return new Quote(message, sender, target);
            }
        }

        /// <summary>
        /// 创建 <see cref="GroupMessageParser"/> 实例
        /// </summary>
        /// <param name="currentUser">指定 <see cref="GroupMessageParser"/> 实例所使用的当前用户</param>
        internal GroupMessageParser(CurrentUser currentUser) : base(currentUser)
        {
        }
    }
}