using Newtonsoft.Json;
using System.Collections.Generic;

namespace HuajiTech.Mirai.Messaging
{
    /// <summary>
    /// 表示戳一戳的 <see cref="MessageElement"/>
    /// </summary>
    public class Poke : MessageElement
    {
        internal override string Type { get; } = "Poke";

        /// <summary>
        /// 戳一戳类型 <see cref="Messaging.PokeType"/> 对 <see cref="string"/> 的字典
        /// </summary>
        [JsonIgnore]
        internal static readonly Dictionary<PokeType, string> PokeDictionary = new Dictionary<PokeType, string>()
        {
            [PokeType.Poke] = "Poke",
            [PokeType.Love] = "ShowLove",
            [PokeType.Like] = "Like",
            [PokeType.Heartbroken] = "Heartbroken",
            [PokeType.Awesome] = "SixSixSix",
            [PokeType.BigMove] = "FangDaZhao",
        };

        /// <summary>
        /// 获取当前 <see cref="Poke"/> 实例的戳一戳类型
        /// </summary>
        [JsonIgnore]
        public PokeType PokeType { get; }

        /// <summary>
        /// 指定当前 <see cref="Poke"/> 实例的戳一戳名称
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        internal string PokeName => PokeDictionary[PokeType];

        /// <summary>
        /// 创建 <see cref="Poke"/> 实例
        /// </summary>
        public Poke() => PokeType = PokeType.Poke;

        /// <summary>
        /// 创建 <see cref="Poke"/> 实例
        /// </summary>
        /// <param name="pokeType">指定 <see cref="Poke"/> 实例的戳一戳类型</param>
        public Poke(PokeType pokeType) => PokeType = pokeType;
    }

    /// <summary>
    /// 指定戳一戳类型
    /// </summary>
    public enum PokeType
    {
        /// <summary>
        /// 戳一戳
        /// </summary>
        Poke,
        /// <summary>
        /// 比心
        /// </summary>
        Love,
        /// <summary>
        /// 点赞
        /// </summary>
        Like,
        /// <summary>
        /// 心碎
        /// </summary>
        Heartbroken,
        /// <summary>
        /// 666
        /// </summary>
        Awesome,
        /// <summary>
        /// 放大招
        /// </summary>
        BigMove
    }
}