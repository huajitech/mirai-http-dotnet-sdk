﻿using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json.Linq;
using System;

namespace HuajiTech.Mirai.Parsing
{
    /// <summary>
    /// 用于解析用户消息的 <see cref="MessageParser"/>
    /// </summary>
    internal class UserMessageParser : MessageParser
    {
        protected override MessageElement ParseExt(JObject element) => element.Value<string>("type") == "Quote" ? ToQuote(element) : throw new InvalidOperationException();

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Quote"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的引用回复</param>
        private Quote ToQuote(JObject element) => /*new Quote(new Message(Session, ParseMore((JArray)element["origin"]).ToList()), CurrentUser.GetFriendAsync(element.Value<long>("senderId")).Result, CurrentUser)*/ null;

        /// <summary>
        /// 创建 <see cref="UserMessageParser"/> 实例
        /// </summary>
        /// <param name="currentUser">指定 <see cref="UserMessageParser"/> 实例所使用的当前用户</param>
        public UserMessageParser(CurrentUser currentUser) : base(currentUser)
        {
        }
    }
}