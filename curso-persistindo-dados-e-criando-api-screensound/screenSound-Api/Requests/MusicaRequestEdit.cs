namespace screenSound_Api.Requests;

public record MusicaRequestEdit(int Id, string Nome, int AnoLancamento, int ArtistaId, ICollection<GeneroRequest> GenerosRequest);

