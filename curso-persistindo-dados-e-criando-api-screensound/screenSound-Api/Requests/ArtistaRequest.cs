using System.ComponentModel.DataAnnotations;

namespace screenSound_Api.Requests;

// A estrutura de dados record é um recurso C# criado para modelarmos diretamente quais dados o cliente deve fornecer como parâmetro para uma determinada requisição. No caso abaixo está sendo definido que o usuário precisar fornecer apenas nome e bio.
public record ArtistaRequest( [Required] string Nome, [Required] string Bio);
