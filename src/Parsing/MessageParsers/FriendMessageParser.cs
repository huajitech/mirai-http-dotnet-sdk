using HuajiTech.Mirai.Http.Interop.Messaging;
using HuajiTech.Mirai.Http.Messaging;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace HuajiTech.Mirai.Http.Parsing
{
    /// <summary>
    /// 用作解析用户消息的 <see cref="MessageParser"/>
    /// </summary>
    internal class FriendMessageParser : MessageParser
    {
        protected override MessageElement ParseExt(JObject element) => element.Value<string>("type") == "Quote" ? ToQuote(element) : throw new InvalidOperationException();

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Quote"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的引用回复</param>
        private Quote ToQuote(JObject element)
        {
            var info = element.ToObject<QuoteInfo>();
            var message = new Message(CurrentUser.Session, ParseMore(info.Origin).ToList());
            var friend = CurrentUser.GetFriendAsync(info.SenderId).Result;

            return new Quote(message, friend, CurrentUser);
        }

        /// <summary>
        /// 创建 <see cref="FriendMessageParser"/> 实例
        /// </summary>
        /// <param name="currentUser">指定 <see cref="FriendMessageParser"/> 实例所使用的当前用户</param>
        public FriendMessageParser(CurrentUser currentUser) : base(currentUser)
        {
        }
    }
}