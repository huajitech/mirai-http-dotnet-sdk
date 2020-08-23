using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Interop
{
    internal class GroupInfo
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; }

        [JsonProperty(PropertyName = "permission")]
        public string Permission { get; }

        public Group ToGroup(CurrentUser currentUser) => new Group(currentUser, Id, Name, Member.MemberRoleDictionary[Permission]);

        public async Task<Group> GetGroupAsync(CurrentUser currentUser) => await currentUser.GetGroupAsync(Id);

        public GroupInfo(long id, string name, string permission)
        {
            Id = id;
            Name = name;
            Permission = permission;
        }
    }
}