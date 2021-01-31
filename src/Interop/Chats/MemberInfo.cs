using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http.Interop
{
    internal class MemberInfo : ChatInfo
    {
        [JsonProperty(PropertyName = "memberName")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "permission")]
        public string Permission { get; set; }

        [JsonProperty(PropertyName = "group")]
        public GroupInfo Group { get; set; }

        public Member ToMember(Group group) => new Member(group, Id, Name, Member.MemberRoleDictionary[Permission]);

        public Member ToMember(CurrentUser currentUser) => new Member(Group.ToGroup(currentUser), Id, Name, Member.MemberRoleDictionary[Permission]);

        public async Task<Member> GetMemberAsync(CurrentUser currentUser) => await (await Group.GetGroupAsync(currentUser)).GetMemberAsync(Id);
    }
}