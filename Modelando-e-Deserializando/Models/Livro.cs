using System.Text.Json.Serialization;

namespace Modelando_e_Deserializando.Models;

internal class Livro
{
    [JsonPropertyName("titulo")]
    public string? Nome { get; set; }
    [JsonPropertyName("autor")]
    public string? Autor { get; set; }
    [JsonPropertyName("ano_publicacao")]
    public int AnoDePublicacao { get; set; }
}
