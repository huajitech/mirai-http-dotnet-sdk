using HuajiTech.Mirai.Http.ApiHandlers;
using HuajiTech.Mirai.Http.Interop;
using HuajiTech.Mirai.Http.Messaging;
using HuajiTech.Mirai.Http.Parsing;
using HuajiTech.Mirai.Http.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http
{
    /// <summary>
    /// 表示消息
    /// </summary>
    public sealed class Message : SessionProcessor
    {
        /// <summary>
        /// 指定当前 <see cref="Message"/> 实例的来源
        /// </summary>
        internal Source Source { get; }

        /// <summary>
        /// 获取当前 <see cref="Message"/> 实例的 ID
        /// </summary>
        public int Id => Source.Id;

        /// <summary>
        /// 获取当前 <see cref="Message"/> 实例的时间
        /// </summary>
        public DateTime Time => TimestampUtilities.ToDateTime(Source.Time);

        /// <summary>
        /// 获取当前 <see cref="Message"/> 实例的内容
        /// </summary>
        public ComplexMessage Content { get; }

        /// <summary>
        /// 获取当前 <see cref="Message"/> 实例的详细内容
        /// </summary>
        internal ComplexMessage FullContent { get; }

        /// <summary>
        /// 异步撤回指定 ID 的 <see cref="Message"/> 实例
        /// </summary>
        public static async Task RecallMessageAsync(Session session, int id) => (await ApiMethods.RecallAsync(session.Settings.HttpUri, session.SessionKey, id)).CheckError();

        /// <summary>
        /// 异步撤回当前 <see cref="Message"/> 实例
        /// </summary>
        public Task RecallAsync() => RecallMessageAsync(Session, Id);

        /// <summary>
        /// 异步获取 <see cref="Message"/> 实例
        /// </summary>
        /// <param name="currentUser">指定获取 <see cref="Message"/> 实例的当前用户</param>
        /// <param name="id">指定获取 <see cref="Message"/> 实例的 ID</param>
        /// <returns>指定的当前用户和 ID 的 <see cref="Message"/> 实例</returns>
        public static async Task<Message> GetMessageAsync(CurrentUser currentUser, int id)
        {
            currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));

            var session = currentUser.Session;
            var result = (await ApiMethods.GetMessageAsync(session.Settings.HttpUri, session.SessionKey, id)).CheckError();
            var data = JObject.Parse(result)["data"].ToObject<MessageData>();
            var parser = MessageParser.GetParser(currentUser, data);

            return await ToMessageAsync(session, parser, data.MessageChain);
        }

        /// <summary>
        /// 异步转换消息链 Json 至 <see cref="Message"/> 实例
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="parser">消息解析器</param>
        /// <param name="messageChain">消息链</param>
        /// <returns></returns>
        internal static async Task<Message> ToMessageAsync(Session session, MessageParser parser, JArray messageChain)
        {
            session = session ?? throw new ArgumentNullException(nameof(session));
            parser = parser ?? throw new ArgumentNullException(nameof(parser));
            messageChain = messageChain ?? throw new ArgumentNullException(nameof(messageChain));

            var elements = await Task.Run(() => parser.ParseMore(messageChain));
            return new Message(session, elements.ToList());
        }

        /// <summary>
        /// 异步尝试获取指定 ID 的消息
        /// </summary>
        /// <param name="currentUser">指定获取 <see cref="Message"/> 实例的当前用户</param>
        /// <param name="id">指定获取 <see cref="Message"/> 实例的 ID</param>
        /// <returns>成功获取则返回指定的当前用户和 ID 的 <see cref="Message"/> 实例，否则返回 null</returns>
        internal static async Task<Message> TryGetMessageAsync(CurrentUser currentUser, int id)
        {
            currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));

            try
            {
                return await GetMessageAsync(currentUser, id);
            }
            catch (ApiException ex) when (ex.ErrorCode == 5)
            {
                return null;
            }
        }

        /// <inheritdoc/>
        public static implicit operator ComplexMessage(Message message) => message.Content;

        /// <summary>
        /// 创建 <see cref="Message"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="Message"/> 实例所使用的 Session</param>
        /// <param name="content">指定 <see cref="Message"/> 实例的完整内容</param>
        internal Message(Session session, List<MessageElement> content) : base(session)
        {
            content = content ?? throw new ArgumentNullException(nameof(content));

            try
            {
                Source = (Source)content.SingleOrDefault(x => x is Source) ?? throw new MessageFormatException(nameof(Messaging.Source));
            }
            catch (InvalidOperationException)
            {
                throw new MessageFormatException(nameof(Messaging.Source));
            }

            Content = new ComplexMessage(content.Skip(1));
            FullContent = new ComplexMessage(content);
        }

        /// <summary>
        /// 创建 <see cref="Message"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="Message"/> 实例所使用的 Session</param>
        /// <param name="source">指定 <see cref="Message"/> 实例的来源</param>
        /// <param name="content">指定 <see cref="Message"/> 实例的内容</param>
        internal Message(Session session, Source source, ComplexMessage content) : base(session)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Content = content ?? throw new ArgumentNullException(nameof(content));
            FullContent = Source + Content;
        }
    }
}