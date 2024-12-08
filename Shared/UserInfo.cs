using System.Text.Json.Serialization;

namespace PokedexGambaApp.Shared;

public class UserInfo
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }
    [JsonPropertyName("username")]
    public required string Username { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("surname")]
    public required string Surname { get; set; }
}

