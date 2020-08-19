using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace HuajiTech.Mirai.Parsing
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
        private Mention ToMention(JObject element)
        {
            try
            {
                return new Mention(Group.GetMemberAsync(element.Value<long>("target")).Result, element.Value<string>("display").TrimStart('@'));
            }
            catch (ChatNotFoundException)
            {
                return null;
            }
        }

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Quote"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的引用回复</param>
        private Quote ToQuote(JObject element) => new Quote(new Message(CurrentUser.Session, ParseMore((JArray)element["origin"]).ToList()), Group.GetMemberAsync(element.Value<long>("senderId")).Result, Group);

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