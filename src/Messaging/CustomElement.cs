namespace HuajiTech.Mirai
{
    /// <summary>
    /// 表示自定义消息元素
    /// </summary>
    public abstract class CustomElement : MessageElement
    {
        /// <summary>
        /// 指定 <see cref="CustomElement"/> 对应的类型名称
        /// </summary>
        public abstract string TypeName { get; }

        internal override string Type => TypeName;
    }
}