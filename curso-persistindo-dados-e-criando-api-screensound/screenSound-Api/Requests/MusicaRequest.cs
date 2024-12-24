using System.ComponentModel.DataAnnotations;
namespace screenSound_Api.Requests;

public record MusicaRequest([Required] string Nome, [Required]int AnoLancamento,[Required] int ArtistaId, ICollection<GeneroRequest> GenerosRequest = null);

