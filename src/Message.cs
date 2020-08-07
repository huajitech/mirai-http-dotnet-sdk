using HuajiTech.Mirai.Extensions;
using HuajiTech.Mirai.Messaging;
using HuajiTech.Mirai.Parsing;
using HuajiTech.Mirai.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    public class Message : SessionProcessor
    {
        internal Source Source { get; }

        public int Id => Source.Id;

        public DateTime Time => TimestampUtilities.ToDateTime(Source.Time);

        public List<MessageElement> Content { get; }

        internal List<MessageElement> FullContent => Source + Content;

        public async Task RecallAsync() => JObject.Parse(await HttpSessions.Recall(CurrentSession.Settings.Uri, CurrentSession.SessionKey, Id)).CheckError();

        public static async Task<Message> GetMessageAsync(Session session, int id)
        {
            var result = (JObject)JObject.Parse(await HttpSessions.GetMessage(session.Settings.Uri, session.SessionKey, id)).CheckError()["data"];
            var parser = MessageParser.GetParser(session, result);
            var elements = await Task.Run(() => parser.ParseMore((JArray)result["messageChain"]));
            return new Message(session, elements.ToList());
        }

        public static implicit operator List<MessageElement>(Message message) => message.Content;

        internal Message(Session session, List<MessageElement> content) : base(session)
        {
            Source = content.First() as Source ?? throw new InvalidOperationException();
            Content = content.Skip(1).ToList();
        }

        internal Message(Session session, Source source, List<MessageElement> content) : base(session)
        {
            Source = source;
            Content = content;
        }
    }
}