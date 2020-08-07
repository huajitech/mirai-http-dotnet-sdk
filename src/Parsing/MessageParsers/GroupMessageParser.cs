using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace HuajiTech.Mirai.Parsing
{
    internal class GroupMessageParser : MessageParser
    {
        private Group Group { get; }

        protected override MessageElement ParseExt(JObject element) => element.Value<string>("type") switch
        {
            "At" => ToMention(element),
            "Quote" => ToQuote(element),
            _ => throw new InvalidOperationException()
        };

        private Mention ToMention(JObject element) => new Mention(new Member(Group, element.Value<long>("target")), element.Value<string>("display").TrimStart('@'));

        private Quote ToQuote(JObject element)
        {
            var group = new Group(CurrentSession, element.Value<long>("groupId"));
            return new Quote(new Message(CurrentSession, ParseMore((JArray)element["origin"]).ToList()), new Member(group, element.Value<long>("senderId")), group);
        }

        internal GroupMessageParser(Group group) : base(group.CurrentSession) => Group = group;
    }
}
