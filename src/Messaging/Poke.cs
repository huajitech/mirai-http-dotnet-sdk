using Newtonsoft.Json;
using System.Collections.Generic;

namespace HuajiTech.Mirai.Messaging
{
    public class Poke : MessageElement
    {
        internal override string Type { get; } = "Poke";

        [JsonIgnore]
        internal static Dictionary<PokeType, string> PokeDictionary = new Dictionary<PokeType, string>()
        {
            [PokeType.Poke] = "Poke",
            [PokeType.Love] = "ShowLove",
            [PokeType.Like] = "Like",
            [PokeType.Heartbroken] = "Heartbroken",
            [PokeType.Awesome] = "SixSixSix",
            [PokeType.BigMove] = "FangDaZhao",
        };

        [JsonIgnore]
        public PokeType PokeType { get; }

        [JsonProperty(PropertyName = "name")]
        internal string PokeName => PokeDictionary[PokeType];

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