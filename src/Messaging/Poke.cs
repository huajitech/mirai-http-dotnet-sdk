using Newtonsoft.Json;
using System;

namespace HuajiTech.Mirai.Messaging
{
    public class Poke : MessageElement
    {
        internal override string Type { get; } = "Poke";

        [JsonIgnore]
        public PokeType PokeType { get; }

        [JsonProperty(PropertyName = "name")]
        internal string PokeName => PokeType switch
        {
            PokeType.Poke => "Poke",
            PokeType.Love => "ShowLove",
            PokeType.Like => "Like",
            PokeType.Heartbroken => "Heartbroken",
            PokeType.Awesome => "SixSixSix",
            PokeType.BigMove => "FangDaZhao",
            _ => throw new ArgumentOutOfRangeException(nameof(PokeType))
        };

        public Poke() => PokeType = PokeType.Poke;

        public Poke(PokeType pokeType) => PokeType = pokeType;
    }

    public enum PokeType
    {
        Poke,
        Love,
        Like,
        Heartbroken,
        Awesome,
        BigMove
    }
}