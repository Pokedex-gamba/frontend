using System.Text.Json.Serialization;

namespace PokedexGambaApp.Shared;

public class Token// : IJsonOnDeserialized
{
    [JsonPropertyName("token")]
    public required string TokenString { get; set; }

    // public void OnDeserialized()
    // {
    //     CapitalizePokemonName();
    // }

    // private void CapitalizePokemonName()
    // {
    //     if (!string.IsNullOrEmpty(PokemonName))
    //     {
    //         string firstLetter = PokemonName[..1].ToUpper();
    //         PokemonName = firstLetter + PokemonName[1..];
    //     }
    // }
}
