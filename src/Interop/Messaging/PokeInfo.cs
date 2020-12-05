using HuajiTech.Mirai.Http.Messaging;
using Newtonsoft.Json;

namespace HuajiTech.Mirai.Http.Interop.Messaging
{
    internal class PokeInfo
    {
        [JsonProperty(PropertyName = "name")]
        public string PokeName { get; init; }

        public Poke ToPoke() => new(Poke.PokeDictionary[PokeName]);
    }
}