namespace screenSound_Api.Requests;

public record MusicaRequest([required] string nome, [required]int anoLancamento,[required] int artistaId);

