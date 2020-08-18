using HuajiTech.Mirai.Events;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 用作插件的基类
    /// </summary>
    public abstract class Plugin : SessionProcessor
    {
        /// <summary>
        /// 异步初始化 <see cref="Plugin"/> 类型的可重写方法
        /// </summary>
        internal protected virtual async Task Initialize() => await Task.Delay(0);

        /// <summary>
        /// 获取当前 <see cref="Plugin"/> 实例的当前用户
        /// </summary>
        internal protected CurrentUser CurrentUser => new CurrentUser(Session);

        internal protected MessageEventSource MessageEventSource { get; }

        public Plugin()
        {
            MessageEventSource = new MessageEventSource(Session);
        }
    }
}