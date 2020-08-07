using System;
using System.Collections.Generic;
using System.Text;

namespace HuajiTech.Mirai.Messaging
{
    internal class Source : MessageElement
    {
        internal override string Type { get; } = "Source";

        public int Id { get; }

        public int Timestamp { get; }

        public Source(int id, int timestamp)
        {
            Id = id;
            Timestamp = timestamp;
        }
    }
}
