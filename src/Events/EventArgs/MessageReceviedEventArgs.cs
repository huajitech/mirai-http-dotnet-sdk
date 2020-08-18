using System;

namespace HuajiTech.Mirai.Events
{
    public class MessageReceviedEventArgs : EventArgs
    {
        public Chat Source { get; }

        public User Sender { get; }

        public Message Message { get; }

        public MessageReceviedEventArgs(Chat source, User sender, Message message)
        {
            Source = source;
            Sender = sender;
            Message = message;
        }
    }
}