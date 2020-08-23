using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Interop
{
    internal class MemberSenderInfo : SenderInfo
    {
        [JsonProperty(PropertyName = "memberName")]
        public string Name { get; }

        [JsonProperty(PropertyName = "permission")]
        public string Permission { get; }

        [JsonProperty(PropertyName = "group")]
        public GroupInfo Group { get; }

        public Member ToMember(CurrentUser currentUser) => new Member(Group.ToGroup(currentUser), Id, Name, Member.MemberRoleDictionary[Permission]);

        public async Task<Member> GetMember(CurrentUser currentUser) => await (await Group.GetGroupAsync(currentUser)).GetMemberAsync(Id);

        public MemberSenderInfo(long id, string permission, GroupInfo group) : base(id)
        {
            Permission = permission;
            Group = group;
        }
    }
}