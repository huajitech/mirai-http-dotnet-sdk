namespace HuajiTech.Mirai
{
    /// <summary>
    /// 定义成员信息
    /// </summary>
    internal class MemberInfo
    {
        /// <summary>
        /// 获取当前 <see cref="MemberInfo"/> 实例的群名片
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 获取当前 <see cref="MemberInfo"/> 实例的头衔
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// 创建 <see cref="MemberInfo"/> 实例
        /// </summary>
        /// <param name="name">指定 <see cref="MemberInfo"/> 实例的群名片</param>
        /// <param name="title">指定 <see cref="MemberInfo"/> 实例的头衔</param>
        public MemberInfo(string name, string title)
        {
            Name = name;
            Title = title;
        }
    }
}