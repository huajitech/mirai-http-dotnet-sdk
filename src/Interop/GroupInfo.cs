using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Interop
{
    internal class GroupInfo
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "permission")]
        public string Permission { get; set; }

        public Group ToGroup(CurrentUser currentUser) => new Group(currentUser, Id, Name, Member.MemberRoleDictionary[Permission]);

        public async Task<Group> GetGroupAsync(CurrentUser currentUser) => await currentUser.GetGroupAsync(Id);
    }
}