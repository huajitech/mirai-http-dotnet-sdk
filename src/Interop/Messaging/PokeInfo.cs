using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop.Messaging
{
    internal class PokeInfo
    {
        [JsonProperty(PropertyName = "name")]
        public string PokeName { get; set; }

        public Poke ToPoke() => new Poke(Poke.PokeDictionary[PokeName]);
    }
}