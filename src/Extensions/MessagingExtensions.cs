using HuajiTech.Mirai.Messaging;

namespace HuajiTech.Mirai.Extensions
{
    public static class MessagingExtensions
    {
        public static Mention Mention(this Member member) => new Mention(member);

        public static Mention Mention(this Member member, string displayName) => new Mention(member, displayName);
    }
}
