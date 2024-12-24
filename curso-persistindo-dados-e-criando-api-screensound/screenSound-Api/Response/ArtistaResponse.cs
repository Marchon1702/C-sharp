namespace screenSound_Api.Response;
// Criando record para modelar os dados que serão respondidos nas requisições de Artista
public record ArtistaResponse(int id, string nome, string bio, string? fotoPerfil);

