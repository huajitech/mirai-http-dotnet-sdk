using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json.Linq;
using System;

namespace HuajiTech.Mirai.Parsing
{
    internal class GroupMessageParser : MessageParser
    {
        private Group Group { get; }

        protected override MessageElement ParseExt(JObject element) => element.Value<string>("type") == "At" ? ToMention(element, Group) : throw new InvalidOperationException();

        private Mention ToMention(JObject element, Group group) => new Mention(new Member(CurrentSession, group, element.Value<long>("target")), element.Value<string>("display").TrimStart('@'));

        internal GroupMessageParser()
        {
        }

        internal GroupMessageParser(Session session, Group group) : base(session)
        {
            Group = group;
        }
    }
}
