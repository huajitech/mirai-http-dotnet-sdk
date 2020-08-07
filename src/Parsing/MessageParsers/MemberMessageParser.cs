using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuajiTech.Mirai.Parsing
{
    internal class MemberMessageParser : MessageParser
    {
        protected override MessageElement ParseExt(JObject element) => element.Value<string>("type") == "Quote" ? ToQuote(element) : throw new InvalidOperationException();

        private Quote ToQuote(JObject element) => new Quote(new Message(CurrentSession, ParseMore((JArray)element["origin"]).ToList()), new Member(CurrentSession, element.Value<long>("groupId"), element.Value<long>("senderId")), new CurrentUser(CurrentSession));

        public MemberMessageParser(Session session) : base(session)
        {
        }
    }
}
