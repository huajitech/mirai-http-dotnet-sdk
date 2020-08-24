using System.Threading.Tasks;

namespace HuajiTech.Mirai.Events
{
    /// <summary>
    /// 指定机器人事件源
    /// </summary>
    public class BotEventSource : EventSource
    {
        /// <summary>
        /// 在机器人登录时引发
        /// </summary>
        public event AsyncEventHandler<BotEventArgs> BotLoginedEvent;

        /// <summary>
        /// 在机器人重新登录时引发
        /// </summary>
        public event AsyncEventHandler<BotEventArgs> BotReloginedEvent;

        /// <summary>
        /// 触发 <see cref="BotLoginedEvent"/> 事件
        /// </summary>
        /// <param name="number">机器人号码</param>
        internal async Task OnBotLogined(BotEventArgs e) => await InvokeAsync(BotLoginedEvent, e);

        /// <summary>
        /// 触发 <see cref="BotReloginedEvent"/> 事件
        /// </summary>
        /// <param name="number">机器人号码</param>
        internal async Task OnBotRelogined(BotEventArgs e) => await InvokeAsync(BotReloginedEvent, e);

        /// <summary>
        /// 创建 <see cref="BotEventSource"/> 实例
        /// </summary>
        public BotEventSource()
        {
        }
    }
}