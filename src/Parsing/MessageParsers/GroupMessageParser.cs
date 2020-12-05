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
        /// <summary>
        /// 当前 <see cref="GroupMessageParser"/> 实例的群
        /// </summary>
        private Group Group { get; }

        protected override MessageElement ParseExt(JObject element) => element.Value<string>("type") switch
        {
            "At" => ToMention(element),
            "Quote" => ToQuote(element),
            _ => throw new InvalidOperationException()
        };

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Mention"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的提及</param>
        private Mention ToMention(JObject element) => new(Group.GetMemberAsync(element.Value<long>("target")).Result, element.Value<string>("display").TrimStart('@'));

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Quote"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的引用回复</param>
        private Quote ToQuote(JObject element)
        {
            var info = element.ToObject<QuoteInfo>();
            var message = new Message(CurrentUser.Session, ParseMore(info.Origin).ToList());
            var member = Group.GetMemberAsync(info.SenderId).Result;

            return new(message, member, Group);
        }

        /// <summary>
        /// 创建 <see cref="GroupMessageParser"/> 实例
        /// </summary>
        /// <param name="currentUser">指定 <see cref="GroupMessageParser"/> 实例所使用的当前用户</param>
        /// <param name="number">指定 <see cref="GroupMessageParser"/> 实例所使用的群号码</param>
        internal GroupMessageParser(CurrentUser currentUser, long number) : base(currentUser) => Group = CurrentUser.GetGroupAsync(number).Result;

        /// <summary>
        /// 创建 <see cref="GroupMessageParser"/> 实例
        /// </summary>
        /// <param name="currentUser">指定 <see cref="GroupMessageParser"/> 实例所使用的当前用户</param>
        /// <param name="group">指定 <see cref="GroupMessageParser"/> 实例所使用的群</param>
        internal GroupMessageParser(CurrentUser currentUser, Group group) : base(currentUser) => Group = group;
    }
}