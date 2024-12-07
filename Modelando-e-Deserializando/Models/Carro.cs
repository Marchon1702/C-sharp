

using System.Text.Json.Serialization;

namespace Modelando_e_Deserializando.Models;

internal class Carro
{
    [JsonPropertyName("marca")]
    public string? Marca { get; set; }
    [JsonPropertyName("modelo")]
    public string? Modelo { get; set; }
    [JsonPropertyName("ano")]
    public int Ano { get; set; }
}
