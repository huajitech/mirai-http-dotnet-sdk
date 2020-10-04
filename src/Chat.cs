using HuajiTech.Mirai.Extensions;
using HuajiTech.Mirai.Messaging;
using HuajiTech.Mirai.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 定义聊天
    /// </summary>
    public abstract class Chat : SessionProcessor, IEquatable<Chat>
    {
        /// <summary>
        /// 获取当前 <see cref="Chat"/> 实例的号码
        /// </summary>
        public long Number { get; }

        /// <summary>
        /// 异步发送消息到当前 <see cref="Chat"/> 实例
        /// </summary>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        internal abstract Task<string> InternalSendAsync(MessageElement[] message);

        /// <summary>
        /// 异步发送消息到当前 <see cref="Chat"/> 实例
        /// </summary>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public async Task<Message> SendAsync(ComplexMessage message)
        {
            var result = JObject.Parse((await InternalSendAsync(message.ToArray())).CheckError());
            return new Message(Session, GetSource(result.Value<int>("messageId")), message);
        }

        /// <summary>
        /// 获取所发送消息的来源
        /// </summary>
        /// <param name="id">消息 ID</param>
        /// <returns>表示所发送消息来源的 <see cref="Source"/> 实例</returns>
        private Source GetSource(int id) => new Source(id, (int)TimestampUtilities.FromDateTime(DateTime.Now));

        /// <inheritdoc/>
        public bool Equals(Chat other) => other != null && other.GetType() == GetType() && other.Number == Number;

        /// <inheritdoc/>
        public override int GetHashCode() => base.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => $"{GetType().Name}({Number})";

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as Chat);

        /// <inheritdoc/>
        public static bool operator ==(Chat left, Chat right) => left?.Equals(right) ?? NullableUtilities.NullEquals(left, right);

        /// <inheritdoc/>
        public static bool operator !=(Chat left, Chat right) => !(left?.Equals(right) ?? NullableUtilities.NullEquals(left, right));

        /// <summary>
        /// 创建 <see cref="Chat"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="Chat"/> 实例所使用的 Session</param>
        /// <param name="number">指定 <see cref="Chat"/> 实例的号码</param>
        internal Chat(Session session, long number) : base(session) => Number = number;
    }
}