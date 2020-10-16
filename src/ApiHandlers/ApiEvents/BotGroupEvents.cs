using HuajiTech.Mirai.Events;
using HuajiTech.Mirai.Interop.Events;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    public partial class ApiEventHandler
    {
        private async Task BotGroupPermissionChangeEventHandling(string data)
        {
            var eventData = JsonConvert.DeserializeObject<BotGroupPermissionChangeEventData>(data);
            var group = await eventData.Group.GetGroupAsync(Session.CurrentUser);
            var origin = Member.MemberRoleDictionary[eventData.Origin];
            var current = Member.MemberRoleDictionary[eventData.Current];

            var e = new CurrentUserGroupRoleChangedEventArgs(group, origin, current);
            await InvokeAsync<CurrentUserEventSource>(x => x.OnCurrentUserGroupRoleChanged(Session, e));
        }
    }
}
