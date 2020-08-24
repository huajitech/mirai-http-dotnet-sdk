//using HuajiTech.Mirai.ApiHandlers;
//using HuajiTech.Mirai.Events;
//using System.Collections.Immutable;
//using System.Threading.Tasks;

//namespace HuajiTech.Mirai
//{
//    /// <summary>
//    /// 用作插件的基类
//    /// </summary>
//    public abstract class Plugin
//    {
//        public ImmutableList<Session> Sessions;

//        public void Listen(params ApiEventHandler[] source) => ApiEventHandlers = ApiEventHandlers.AddRange(source);

//        /// <summary>
//        /// 异步绑定 <see cref="Session"/> 实例
//        /// </summary>
//        /// <param name="session">要绑定的 <see cref="Session"/> 实例</param>
//        public void Bind(params Session[] session) => Sessions = Sessions.AddRange(session);

//        /// <summary>
//        /// 创建 <see cref="Plugin"/> 实例
//        /// </summary>
//        public Plugin()
//        {
//        }
//    }
//}