using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace HuajiTech.Mirai.Parsing
{
    /// <summary>
    /// 用作解析临时会话消息的 <see cref="MessageParser"/>
    /// </summary>
    internal class MemberMessageParser : MessageParser
    {
        protected override MessageElement ParseExt(JObject element) => element.Value<string>("type") == "Quote" ? ToQuote(element) : throw new InvalidOperationException();

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Quote"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的引用回复</param>
        private Quote ToQuote(JObject element) => new Quote(new Message(CurrentUser.Session, ParseMore((JArray)element["origin"]).ToList()), CurrentUser.GetGroupAsync(element.Value<long>("groupId")).Result.GetMemberAsync(element.Value<long>("senderId")).Result, CurrentUser);

        /// <summary>
        /// 创建 <see cref="MemberMessageParser"/> 实例
        /// </summary>
        /// <param name="currentUser">指定 <see cref="MemberMessageParser"/> 实例所使用的当前用户</param>
        public MemberMessageParser(CurrentUser currentUser) : base(currentUser)
        {
        }
    }
}