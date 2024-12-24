using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco_com_Entity;
using ScreenSound.Modelos;
using screenSound_Api.Requests;
using screenSound_Api.Response;

namespace screenSound_Api.Endpoints;

public static class MusicaExtensions
{
    public static void AddEndPointsMusica(this WebApplication app)
    {
        app.MapGet("/Musicas", ([FromServices] DAL<Musica> musicaDAL) =>
        {
            var musicas = musicaDAL.Listar();

            if (musicas is null) return Results.NotFound();
            #region Corrigindo problemas com LazyLoading
            // Retornando um objeto diretamente devido a problemas com LazyLoadingProxies
            //var result = musicas.Select(m => new
            //{
            //    m.Id,
            //    m.Nome,
            //    m.AnoLancamento,
            //    m.Artista
            //});
            #endregion

            var musicasAhRetornar = EntityListToResponseList(musicas);
            return Results.Ok(musicasAhRetornar);
        });

        app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> musicaDAL, string nome) =>
        {
            var musica = musicaDAL.RecuperarPor(m => m.Nome.Equals(nome));

            if (musica is null) return Results.NotFound();
            #region Corrigindo problemas com LazyLoading
            //var result = new
            //{
            //    musica.Id,
            //    musica.Nome,
            //    musica.AnoLancamento,
            //    musica.Artista
            //};
            #endregion

            var musicaAhRetornar = EntityToResponse(musica);
            return Results.Ok(musicaAhRetornar);
        });

        app.MapPost("/Musicas", ([FromServices] DAL<Musica> musicaDAL, [FromServices] DAL<Genero> generoDAL, [FromBody] MusicaRequest musicaRequest) =>
        {
            var novaMusica = new Musica(musicaRequest.Nome)
            {
                AnoLancamento = musicaRequest.AnoLancamento,
                ArtistaId = musicaRequest.ArtistaId,
                Generos = musicaRequest.GenerosRequest is not null ? GeneroRequestConverter(generoDAL, musicaRequest.GenerosRequest) : new List<Genero>()
            };

            var musicaAhAdicionar = musicaDAL.RecuperarPor(m => m.Nome.Equals(novaMusica.Nome) && m.Artista!.Nome.Equals(novaMusica.Artista!.Nome));

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

        app.MapPut("/Musicas", ([FromServices] DAL<Musica> musicaDAL, [FromServices] DAL <Genero> generoDAL, [FromBody] MusicaRequestEdit musicaRequestEdit) =>
        {
            var musicaAhAtualizar = musicaDAL.RecuperarPor(m => m.Id == musicaRequestEdit.Id);
            if (musicaAhAtualizar is null) return Results.NotFound();

            musicaAhAtualizar.Nome = musicaRequestEdit.Nome;
            musicaAhAtualizar.AnoLancamento = musicaRequestEdit.AnoLancamento;
            musicaAhAtualizar.Generos = musicaRequestEdit.GenerosRequest is not null ? GeneroRequestConverter(generoDAL, musicaRequestEdit.GenerosRequest) : musicaAhAtualizar.Generos;

            musicaDAL.Atualizar(musicaAhAtualizar);
            return Results.Ok();
        });
    }

    public static ICollection<MusicaResponse> EntityListToResponseList(IEnumerable<Musica> listaDeMusicas)
    {
        return listaDeMusicas.Select(m => EntityToResponse(m)).ToList();
    }

    public static MusicaResponse EntityToResponse(Musica musica)
    {
        return new MusicaResponse(musica.Id, musica.Nome, musica.Artista!.Id, musica.Artista.Nome);
    }
    private static Genero RequestToEntity(GeneroRequest genero)
    {
        return new Genero() { Nome = genero.Nome, Descricao = genero.Descricao };
    }

    private static ICollection<Genero> GeneroRequestConverter([FromServices] DAL<Genero> generoDAL, ICollection<GeneroRequest> listaDeGeneroRequests)
    {
        // A lista de Generos é inicializada vazia e será preenchida com Generos existentes ou novos, conforme a necessidade
        var listaDeGeneros = new List<Genero>();

        // Para cada objeto generoRequest
        foreach (var generoRequest in listaDeGeneroRequests)
        {
            // Seu valor é atribuido a entity
            var entity = RequestToEntity(generoRequest);
            // Armazena um valor não null caso o Genero já exista no banco
            var genero = generoDAL.RecuperarPor(g => g.Nome.ToUpper().Equals(generoRequest.Nome.ToUpper()));

            // Se o genero já existir adicione o próprio genero existente
            if (genero is not null) listaDeGeneros.Add(genero);
            // Se não, adicione o novo genero
            else listaDeGeneros.Add(entity);          
        }

        return listaDeGeneros;
    }
}
