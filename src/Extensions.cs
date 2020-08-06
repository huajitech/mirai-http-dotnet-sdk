using HuajiTech.Mirai.Messaging;

namespace HuajiTech.Mirai
{
    public static class Extensions
    {
        public static Mention Mention(this Member member) => new Mention(member);

        public static Mention Mention(this Member member, string displayName) => new Mention(member, displayName);
    }
}
