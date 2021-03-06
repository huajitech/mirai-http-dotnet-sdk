﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace HuajiTech.Mirai.Http.Messaging
{
    /// <summary>
    /// 表示戳一戳的 <see cref="MessageElement"/>
    /// </summary>
    public class Poke : MessageElement
    {
        /// <inheritdoc/>
        protected override string Type { get; } = "Poke";

        /// <summary>
        /// 戳一戳类型 <see cref="Messaging.PokeType"/> 对 <see cref="string"/> 的字典
        /// </summary>
        [JsonIgnore]
        internal static readonly Dictionary<string, PokeType> PokeDictionary = new Dictionary<string, PokeType>()
        {
            ["Poke"] = PokeType.Poke,
            ["ShowLove"] = PokeType.Love,
            ["Like"] = PokeType.Like,
            ["Heartbroken"] = PokeType.Heartbroken,
            ["SixSixSix"] = PokeType.Awesome,
            ["FangDaZhao"] = PokeType.BigMove,
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
        internal string PokeName => PokeDictionary.SingleOrDefault(x => x.Value == PokeType).Key;

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