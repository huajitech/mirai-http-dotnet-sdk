using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Interop
{
    internal class MemberSenderInfo : SenderInfo
    {
        [JsonProperty(PropertyName = "memberName")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "permission")]
        public string Permission { get; set; }

        [JsonProperty(PropertyName = "group")]
        public GroupInfo Group { get; set; }

        public Member ToMember(CurrentUser currentUser) => new Member(Group.ToGroup(currentUser), Id, Name, Member.MemberRoleDictionary[Permission]);

        public async Task<Member> GetMemberAsync(CurrentUser currentUser) => await (await Group.GetGroupAsync(currentUser)).GetMemberAsync(Id);
    }
}