using Newtonsoft.Json;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 表示自定义消息元素
    /// </summary>
    public abstract class CustomElement : MessageElement
    {
        [JsonIgnore]
        internal override string Type { get; } = null;
    }
}