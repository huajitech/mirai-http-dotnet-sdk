﻿using HuajiTech.Mirai.Extensions;
using HuajiTech.Mirai.Messaging;
using HuajiTech.Mirai.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    public abstract class Chat : SessionProcessor
    {
        public long Number { get; protected set; }

        internal abstract Task<string> InternalSendAsync(MessageElement[] message);

        public async Task<Message> SendAsync(List<MessageElement> message)
        {
            var result = JObject.Parse(await InternalSendAsync(message.ToArray())).CheckError();
            return new Message(CurrentSession, GetSource(result.Value<int>("messageId")), message);
        }

        public async Task<Message> SendAsync(MessageElement[] message)
        {
            var result = JObject.Parse(await InternalSendAsync(message)).CheckError();
            return new Message(CurrentSession, GetSource(result.Value<int>("messageId")), message.ToList());
        }

        private Source GetSource(int id) => new Source(id, (int)TimestampUtilities.FromDateTime(DateTime.Now));

        public async Task<Message> SendAsync(string message) => await SendAsync(new MessageElement[] { new PlainText(message) });

        public async Task<Message> SendAsync(MessageElement message) => await SendAsync(new MessageElement[] { message });

        public async Task<Message> SendAsync(PlainText message) => await SendAsync((MessageElement)message);

        public override bool Equals(object obj) => obj is Chat chat && chat.GetType() == GetType() && chat.Number == Number;

        public override int GetHashCode() => base.GetHashCode();

        public override string ToString() => $"{GetType()}({Number})";

        public static bool operator ==(Chat left, Chat right) => left.Equals(right);

        public static bool operator !=(Chat left, Chat right) => !left.Equals(right);

        public Chat(Session session) : base(session)
        {
        }
    }
}