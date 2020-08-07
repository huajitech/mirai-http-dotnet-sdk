using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace HuajiTech.Mirai.Parsing
{
    internal class UserMessageParser : MessageParser
    {
        protected override MessageElement ParseExt(JObject element) => element.Value<string>("type") == "Quote" ? ToQuote(element) : throw new InvalidOperationException();

        private Quote ToQuote(JObject element) => new Quote(new Message(CurrentSession, ParseMore((JArray)element["origin"]).ToList()), new Friend(CurrentSession, element.Value<long>("senderId")), new CurrentUser(CurrentSession));

        public UserMessageParser(Session session) : base(session)
        {
        }
    }
}
