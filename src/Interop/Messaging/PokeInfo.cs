using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop.Messaging
{
    internal class PokeInfo
    {
        [JsonProperty(PropertyName = "name")]
        public string PokeName { get; }

        public Poke ToPoke() => new Poke(Poke.PokeDictionary[PokeName]);

        public PokeInfo(string name) => PokeName = name;
    }
}