using Newtonsoft.Json;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 表示自定义消息元素（请使用 <see cref="Newtonsoft.Json"/> 中的特性以指示 <see cref="JsonSerializer"/> 如何处理属性和字段）
    /// </summary>
    public abstract class CustomElement : MessageElement
    {
        [JsonIgnore]
        internal override string Type { get; } = null;
    }
}