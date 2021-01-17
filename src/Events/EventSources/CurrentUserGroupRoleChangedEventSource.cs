using HuajiTech.Mirai.Http.Interop.Events;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http.Events
{
    /// <summary>
    /// 指定当前用户成员角色更改事件源
    /// </summary>
    public class CurrentUserGroupRoleChangedEventSource : EventSource<CurrentUserGroupRoleChangedEventArgs>
    {
        /// <inheritdoc/>
        internal override string Type { get; } = "BotGroupPermissionChangeEvent";

        /// <inheritdoc/>
        private protected override async Task<CurrentUserGroupRoleChangedEventArgs> ToEventArgsAsync(string data, Session session)
        {
            var eventData = JsonConvert.DeserializeObject<BotGroupPermissionChangeEventData>(data);
            var group = await eventData.Group.GetGroupAsync(session.CurrentUser);
            var origin = Member.MemberRoleDictionary[eventData.Origin];
            var current = Member.MemberRoleDictionary[eventData.Current];

            return new CurrentUserGroupRoleChangedEventArgs(group, origin, current);
        }

        /// <summary>
        /// 创建 <see cref="CurrentUserGroupRoleChangedEventSource"/> 实例
        /// </summary>
        public CurrentUserGroupRoleChangedEventSource()
        {
        }
    }
}