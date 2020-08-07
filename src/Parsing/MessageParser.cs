﻿using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HuajiTech.Mirai.Parsing
{
    internal abstract class MessageParser : SessionProcessor
    {
        protected virtual MessageElement ParseExt(JObject element) => throw new InvalidOperationException();

        public MessageElement Parse(JObject element) => element.Value<string>("type") switch
        {
            "Source" => ToSource(element),
            "Face" => ToEmoticon(element),
            "FlashImage" => ToFlashImage(element),
            "Image" => ToImage(element),
            "AtAll" => ToMentionAll(),
            "Plain" => ToPlainText(element),
            "Poke" => ToPoke(element),
            _ => ParseExt(element)
        };

        public IEnumerable<MessageElement> ParseMore(JArray elements)
        {
            foreach (JObject element in elements)
            {
                yield return Parse(element);
            }
        }

        public static MessageParser GetParser(Session session, JObject data) => data.Value<string>("type") switch
        {
            "FriendMessage" => new UserMessageParser(session),
            "GroupMessage" => new GroupMessageParser(new Group(session, data["sender"]["group"].Value<long>("id"))),
            "TempMessage" => new MemberMessageParser(session),
            _ => throw new InvalidOperationException()
        };

        private Source ToSource(JObject element) => new Source(element.Value<int>("id"), element.Value<int>("time"));

        private Emoticon ToEmoticon(JObject element) => new Emoticon(element.Value<int>("id"), element.Value<string>("name"));

        private FlashImage ToFlashImage(JObject element) => new FlashImage(element.Value<string>("imageId"), element.Value<string>("path"), new Uri(element.Value<string>("url")));

        private Image ToImage(JObject element) => new Image(element.Value<string>("imageId"), element.Value<string>("path"), new Uri(element.Value<string>("url")));

        private MentionAll ToMentionAll() => new MentionAll();

        private PlainText ToPlainText(JObject element) => new PlainText(element.Value<string>("text"));

        private Poke ToPoke(JObject element) => new Poke(Poke.PokeDictionary.FirstOrDefault(x => x.Value == element.Value<string>("name")).Key);

        internal MessageParser(Session session) : base(session)
        {
        }
    }
}
