﻿using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http.Interop
{
    internal class MemberInfo : ChatInfo
    {
        [JsonProperty(PropertyName = "memberName")]
        public string Name { get; init; }

        [JsonProperty(PropertyName = "permission")]
        public string Permission { get; init; }

        [JsonProperty(PropertyName = "group")]
        public GroupInfo Group { get; init; }

        public Member ToMember(Group group) => new(group, Id, Name, Member.MemberRoleDictionary[Permission]);

        public Member ToMember(CurrentUser currentUser) => new(Group.ToGroup(currentUser), Id, Name, Member.MemberRoleDictionary[Permission]);

        public async Task<Member> GetMemberAsync(CurrentUser currentUser) => await (await Group.GetGroupAsync(currentUser)).GetMemberAsync(Id);
    }
}