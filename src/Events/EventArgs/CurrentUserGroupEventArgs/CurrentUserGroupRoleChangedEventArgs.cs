namespace HuajiTech.Mirai.Events
{
    /// <summary>
    /// 为当前用户的成员角色更改事件提供数据
    /// </summary>
    public class CurrentUserGroupRoleChangedEventArgs : CurrentUserGroupEventArgs
    {
        /// <summary>
        /// 指定 <see cref="CurrentUserGroupRoleChangedEventArgs"/> 的原权限
        /// </summary>
        public MemberRole Origin { get; }

        /// <summary>
        /// 指定 <see cref="CurrentUserGroupRoleChangedEventArgs"/> 的新权限
        /// </summary>
        public MemberRole Current { get; }

        /// <summary>
        /// 创建 <see cref="CurrentUserGroupRoleChangedEventArgs"/> 实例
        /// </summary>
        /// <param name="source">指定 <see cref="CurrentUserGroupRoleChangedEventArgs"/> 实例的来源</param>
        /// <param name="origin">指定 <see cref="CurrentUserGroupRoleChangedEventArgs"/> 实例的原权限</param>
        /// <param name="current">指定 <see cref="CurrentUserGroupRoleChangedEventArgs"/> 实例的新权限</param>
        internal CurrentUserGroupRoleChangedEventArgs(Group source, MemberRole origin, MemberRole current) : base(source)
        {
            Origin = origin;
            Current = current;
        }
    }
}