using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Interop
{
    internal class GroupInfo : ChatInfo
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; init; }

        [JsonProperty(PropertyName = "permission")]
        public string Permission { get; init; }

        public Group ToGroup(CurrentUser currentUser) => new(currentUser, Id, Name, Member.MemberRoleDictionary[Permission]);

        public async Task<Group> GetGroupAsync(CurrentUser currentUser) => await currentUser.GetGroupAsync(Id);
    }
}