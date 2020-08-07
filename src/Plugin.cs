using HuajiTech.Mirai.Parsing;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    public abstract class Plugin : SessionProcessor
    {
        internal protected virtual async Task Initialize() => await Task.Delay(0);

        protected CurrentUser CurrentUser => new CurrentUser(CurrentSession);

        protected Group Group(long number) => new Group(CurrentSession, number);

        protected Friend Friend(long number) => new Friend(CurrentSession, number);

        protected Member Member(long group, long target) => new Member(CurrentSession, group, target);

        protected Member Member(Group group, long target) => new Member(group, target);

        protected async Task<Message> GetMessageAsync(int id) => await Message.GetMessageAsync(CurrentSession, id);
    }
}