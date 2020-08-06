using Newtonsoft.Json;

namespace HuajiTech.Mirai.Messaging
{
    public class PlainText : MessageElement
    {
        internal override string Type { get; } = "Plain";

        [JsonProperty(PropertyName = "text")]
        public string Content { get; }

        public PlainText(string content) => Content = content;

        public static implicit operator string(PlainText plainText) => plainText.Content ?? string.Empty;
    }
}