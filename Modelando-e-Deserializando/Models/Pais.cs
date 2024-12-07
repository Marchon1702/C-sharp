

using System.Text.Json.Serialization;

namespace Modelando_e_Deserializando.Models;

internal class Pais
{
    [JsonPropertyName("nome")]
    public string? Nome { get; set; }
    [JsonPropertyName("capital")]
    public string? Capital { get; set; }
    [JsonPropertyName("idioma")]
    public string? Idioma { get; set; }
}
