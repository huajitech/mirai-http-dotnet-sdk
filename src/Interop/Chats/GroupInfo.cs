using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http.Interop
{
    internal class GroupInfo : ChatInfo
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "permission")]
        public string Permission { get; set; }

        public Group ToGroup(CurrentUser currentUser) => new Group(currentUser, Id, Name, Member.MemberRoleDictionary[Permission]);

        public async Task<Group> GetGroupAsync(CurrentUser currentUser) => await currentUser.GetGroupAsync(Id);
    }
}