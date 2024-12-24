using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco_com_Entity;
using ScreenSound.Modelos;
using screenSound_Api.Requests;

namespace screenSound_Api.Endpoints;

public static class MusicaExtensions
{
    public static void AddEndPointsMusica(this WebApplication app)
    {
        app.MapGet("/Musicas", ([FromServices] DAL<Musica> musicaDAL) =>
        {
            var musicas = musicaDAL.Listar();

            if (musicas is null) return Results.NotFound();

            // Retornando um objeto diretamente devido a problemas com LazyLoadingProxies
            var result = musicas.Select(m => new
            {
                m.Id,
                m.Nome,
                m.AnoLancamento,
                m.Artista
            });

            return Results.Ok(result);
        });

        app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> musicaDAL, string nome) =>
        {
            var musica = musicaDAL.RecuperarPor(m => m.Nome.Equals(nome));

            if (musica is null) return Results.NotFound();

            var result = new
            {
                musica.Id,
                musica.Nome,
                musica.AnoLancamento,
                musica.Artista
            };

            return Results.Ok(result);
        });

        app.MapPost("/Musicas", ([FromServices] DAL<Musica> musicaDAL, [FromBody] MusicaRequest musicaRequest) =>
        {
            var novaMusica = new Musica(musicaRequest.nome)
            {
                AnoLancamento = musicaRequest.anoLancamento,
                ArtistaId = musicaRequest.artistaId,
            };

            var musicaAhAdicionar = musicaDAL.RecuperarPor(m => m.Nome.Equals(novaMusica.Nome) && m.Artista.Nome.Equals(novaMusica.Artista.Nome));

            if (musicaAhAdicionar is not null) return Results.Conflict();

            if (novaMusica is null) return Results.BadRequest();

            musicaDAL.Adicionar(novaMusica);
            return Results.Ok();
        });

        app.MapDelete("/Musicas/{id}", ([FromServices] DAL<Musica> musicaDAL, int id) =>
        {
            var musicaAhDeletar = musicaDAL.RecuperarPor(m => m.Id == id);
            if (musicaAhDeletar is null) return Results.NotFound();

            musicaDAL.Deletar(musicaAhDeletar);
            return Results.NoContent();
        });

        app.MapPut("/Musicas", ([FromServices] DAL<Musica> musicaDAL, [FromBody] Musica musica) =>
        {
            var musicaAhAtualizar = musicaDAL.RecuperarPor(m => m.Id == musica.Id);
            if (musicaAhAtualizar is null) return Results.NotFound();

            musicaAhAtualizar.Nome = musica.Nome;
            musicaAhAtualizar.AnoLancamento = musica.AnoLancamento;

            musicaDAL.Atualizar(musicaAhAtualizar);
            return Results.Ok();
        });
    }
}
