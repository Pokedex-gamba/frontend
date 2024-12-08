using System.Text.Json.Serialization;

namespace PokedexGambaApp.Shared;

public class Pokemon : IJsonOnDeserialized
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }
    [JsonPropertyName("userId")]
    public required string UserId { get; set; }
    [JsonPropertyName("pokemonName")]
    public required string PokemonName { get; set; }
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
    [JsonPropertyName("baseHP")]
    public required int BaseHP { get; set; }
    [JsonPropertyName("baseAttack")]
    public required int BaseAttack { get; set; }
    [JsonPropertyName("baseDefense")]
    public required int BaseDefense { get; set; }
    [JsonPropertyName("baseSpeed")]
    public required int BaseSpeed { get; set; }
    [JsonPropertyName("type")]
    public required string Type { get; set; }
    [JsonPropertyName("totalRarity")]
    public required int TotalRarity { get; set; }
    [JsonPropertyName("frontDefault")]
    public required string FrontDefault { get; set; }
    [JsonPropertyName("frontShiny")]
    public required string FrontShiny { get; set; }
    [JsonPropertyName("legendary")]
    public required bool Legendary { get; set; }

    public void OnDeserialized()
    {
        CapitalizePokemonName();
    }

    private void CapitalizePokemonName()
    {
        if (!string.IsNullOrEmpty(PokemonName))
        {
            string firstLetter = PokemonName[..1].ToUpper();
            PokemonName = firstLetter + PokemonName[1..];
        }
    }
}
