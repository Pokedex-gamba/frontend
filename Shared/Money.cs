using System.Text.Json.Serialization;

namespace PokedexGambaApp.Shared;

public class Money// : IJsonOnDeserialized
{
    [JsonPropertyName("userId")]
    public string UserIdString { get; set; }

    [JsonPropertyName("balance")]
    public int BalanceInt { get; set; }

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
