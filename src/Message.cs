using HuajiTech.Mirai.Parsing;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    public class Message : SessionProcessor
    {
        public int Id { get; }

        public List<MessageElement> Content { get; }

        public async Task RecallAsync() => JObject.Parse(await HttpSessions.Recall(CurrentSession.Settings.Uri, CurrentSession.SessionKey, Id)).CheckError();

        public static async Task<Message> GetMessageAsync(Session session, int id)
        {
            var result = JObject.Parse(await HttpSessions.GetMessage(session.Settings.Uri, session.SessionKey, id)).CheckError()["data"];
            var parser = MessageParser.GetParser(result.Value<string>("type"));
            var elements = await Task.Run(() => parser.ParseMore((JArray)result["messageChain"]));
            return new Message(id, elements.ToList(), session);
        }

        public static implicit operator List<MessageElement>(Message message) => message.Content;

        internal Message(int id, List<MessageElement> content, Session session) : base(session)
        {
            Id = id;
            Content = content;
        }
    }
}