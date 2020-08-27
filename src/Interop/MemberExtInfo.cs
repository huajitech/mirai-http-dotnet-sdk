namespace HuajiTech.Mirai.Interop
{
    /// <summary>
    /// 定义成员信息
    /// </summary>
    internal class MemberExtInfo
    {
        /// <summary>
        /// 获取当前 <see cref="MemberExtInfo"/> 实例的群名片
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取当前 <see cref="MemberExtInfo"/> 实例的头衔
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 创建 <see cref="MemberExtInfo"/> 实例
        /// </summary>
        /// <param name="name">指定 <see cref="MemberExtInfo"/> 实例的群名片</param>
        /// <param name="title">指定 <see cref="MemberExtInfo"/> 实例的头衔</param>
        public MemberExtInfo(string name, string title)
        {
            Name = name;
            Title = title;
        }
    }
}