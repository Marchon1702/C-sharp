using System.Text.Json.Serialization;

namespace Modelando_e_Deserializando.Models;

internal class Filme
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    [JsonPropertyName("title")]
    public string? Nome { get; set; }
    [JsonPropertyName("year")]
    public string? Ano { get; set; }
    [JsonPropertyName("rank")]
    public string? Rank { get; set; }
}
