using System.Collections.Generic;

namespace HuajiTech.Mirai
{
    public class Message
    {
        public int Id { get; }

        public List<MessageElement> Content { get; }

        public static implicit operator List<MessageElement>(Message message) => message.Content;

        internal Message(int id, List<MessageElement> content)
        {
            Id = id;
            Content = content;
        }
    }
}