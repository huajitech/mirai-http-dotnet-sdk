using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    public class Message : SessionProcessor
    {
        public int Id { get; }

        public List<MessageElement> Content { get; }

        public async Task RecallAsync() => JObject.Parse(await HttpSessions.Recall(CurrentSession.Settings.Uri, CurrentSession.SessionKey, Id)).CheckError();

        public static implicit operator List<MessageElement>(Message message) => message.Content;

        internal Message(int id, List<MessageElement> content, Session session) : base(session)
        {
            Id = id;
            Content = content;
        }
    }
}