using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 定义群
    /// </summary>
    public class Group : Chat
    {
        internal override async Task<string> InternalSendAsync(MessageElement[] message) => await HttpSessions.SendGroupMessageAsync(Session.Settings.Uri, Session.SessionKey, Number, message);

        /// <summary>
        /// 创建 <see cref="Group"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="Group"/> 实例所使用的 Session</param>
        /// <param name="number">指定 <see cref="Group"/> 实例的号码</param>
        public Group(Session session, long number) : base(session) => Number = number;
    }
}