namespace HuajiTech.Mirai.Http.Messaging
{
    /// <summary>
    /// 表示提及全体成员的 <see cref="MessageElement"/>
    /// </summary>
    public class MentionAll : MessageElement
    {
        /// <inheritdoc/>
        protected override string Type { get; } = "AtAll";

        /// <summary>
        /// 创建 <see cref="MentionAll"/> 实例
        /// </summary>
        public MentionAll()
        {
        }
    }
}