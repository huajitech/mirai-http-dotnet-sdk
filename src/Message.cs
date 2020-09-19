using HuajiTech.Mirai.ApiHandlers;
using HuajiTech.Mirai.Extensions;
using HuajiTech.Mirai.Interop;
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
    /// <summary>
    /// 表示消息
    /// </summary>
    public class Message : SessionProcessor
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
        public List<MessageElement> Content { get; }

        /// <summary>
        /// 获取当前 <see cref="Message"/> 实例的详细内容
        /// </summary>
        internal List<MessageElement> FullContent => Source + Content;

        /// <summary>
        /// 异步撤回指定 ID 的 <see cref="Message"/> 实例
        /// </summary>
        public static async Task RecallMessageAsync(Session session, int id) => (await ApiMethods.RecallAsync(session.HttpUri, session.SessionKey, id)).CheckError();

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
            var session = currentUser.Session;
            var result = (await ApiMethods.GetMessageAsync(session.Settings.HttpUri, session.SessionKey, id)).CheckError();
            var data = JObject.Parse(result)["data"].ToObject<MessageData>();
            var parser = MessageParser.GetParser(currentUser, data);
            var elements = await Task.Run(() => parser.ParseMore(data.MessageChain));
            return new Message(session, elements.ToList());
        }

        /// <inheritdoc/>
        public static implicit operator List<MessageElement>(Message message) => message.Content;

        /// <summary>
        /// 创建 <see cref="Message"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="Message"/> 实例所使用的 Session</param>
        /// <param name="content">指定 <see cref="Message"/> 实例的完整内容</param>
        internal Message(Session session, List<MessageElement> content) : base(session)
        {
            Source = content.First() as Source ?? throw new InvalidOperationException();
            Content = content.Skip(1).ToList();
        }

        /// <summary>
        /// 创建 <see cref="Message"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="Message"/> 实例所使用的 Session</param>
        /// <param name="source">指定 <see cref="Message"/> 实例的来源</param>
        /// <param name="content">指定 <see cref="Message"/> 实例的内容</param>
        internal Message(Session session, Source source, List<MessageElement> content) : base(session)
        {
            Source = source;
            Content = content;
        }
    }
}