using System.Threading.Tasks;

namespace HuajiTech.Mirai.Events
{
    public class BotEventSource : EventSource
    {
        /// <summary>
        /// 在机器人登录时引发
        /// </summary>
        public event EventHandler<BotEventArgs> BotLoginedEvent;

        /// <summary>
        /// 在机器人重新登录时引发
        /// </summary>
        public event EventHandler<BotEventArgs> BotReloginedEvent;

        /// <summary>
        /// 触发 <see cref="BotLoginedEvent"/> 事件
        /// </summary>
        /// <param name="number">机器人号码</param>
        internal async Task OnBotLogined(long number)
        {
            var e = new BotEventArgs(number);
            await InvokeAsync(BotLoginedEvent, e);
        }

        /// <summary>
        /// 触发 <see cref="BotReloginedEvent"/> 事件
        /// </summary>
        /// <param name="number">机器人号码</param>
        internal async Task OnBotRelogined(long number)
        {
            var e = new BotEventArgs(number);
            await InvokeAsync(BotReloginedEvent, e);
        }

        /// <summary>
        /// 创建 <see cref="BotEventSource"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="BotEventSource"/> 实例所使用的会话</param>
        internal BotEventSource(Session session) : base(session)
        {
        }
    }
}