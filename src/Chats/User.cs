using System;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http
{
    /// <summary>
    /// 定义用户
    /// </summary>
    public class User : Chat
    {
        private protected override Task<string> InternalSendAsync(MessageElement[] message, int? quoteId) => throw new NotSupportedException();

        /// <summary>
        /// 创建 <see cref="User"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="User"/> 实例所使用的 Session</param>
        /// <param name="number">指定 <see cref="User"/> 实例的号码</param>
        internal User(Session session, long number) : base(session, number)
        {
        }
    }
}