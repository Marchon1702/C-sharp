using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco_com_Entity;
using ScreenSound.Modelos;
using screenSound_Api.Requests;

namespace screenSound_Api.Endpoints;

// As classes no namespace Endpoints são classes que extendem o program.cs, é uma boa prática de código para que ocorra o encapsulamento e a divisão de responsabilidades, assim cada Endpoint de uma tabela fica separado por classe.
public static class ArtistaExtensions
{
    // Esse parametro indica q o método extende a classe program.cs usando a variável app....
    public static void AddEndPointsArtista(this WebApplication app)
    {
        // [FromServices] indica que o arguemento para o parâmetro artistaDAL foi injetado de da Prop Services no builder.
        app.MapGet("/Artistas", ([FromServices] DAL<Artista> artistaDAL) =>
        {
            var artistas = artistaDAL.Listar();

            if (artistas is null) return Results.NotFound();

            // Retornando um objeto diretamento devido a problemas com LazyLoadingProxies
            var result = artistas.Select(a => new
            {
                a.Id,
                a.Nome,
                a.Bio,
                a.FotoPerfil,
                a.Musicas
            });

            // Criar um constructor vazio na classe Artista também resolveria pórem, o json sempre retorna um atributo vazio chama lazyLoader. 
            return Results.Ok(result);
        });

        app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> artistaDAL, string nome) =>
        {
            var artista = artistaDAL.RecuperarPor(artista => artista.Nome.ToUpper().Equals(nome.ToUpper().Trim()));

            if (artista is null) return Results.NotFound();

            //var result = new
            //{
            //    artista.Id,
            //    artista.Nome,
            //    artista.Bio,
            //    artista.FotoPerfil,
            //    artista.Musicas
            //};

            //return Results.Ok(result);   

            // Optando por retornar direto e recebendo atributo vazio lazyLoader.
            return Results.Ok(artista);
        });

        // [FromBody] para indicar que esse parâmetro vem do corpo da requisição.
        app.MapPost("/Artistas", ([FromServices] DAL<Artista> artistaDAL, [FromBody] ArtistaResquest artistaRequest) =>
        {
            // Convertendo artista request para Artista
            var artista = new Artista(artistaRequest.nome, artistaRequest.bio);
            artistaDAL.Adicionar(artista);
            return Results.Ok();
        });

        app.MapDelete("/Artistas/{id}", ([FromServices] DAL<Artista> artistaDAL, int id) =>
        {
            var artista = artistaDAL.RecuperarPor(artista => artista.Id == id);
            if (artistaDAL is null) return Results.NotFound();

            artistaDAL.Deletar(artista!);
            return Results.NoContent();
        });

        app.MapPut("/Artistas", ([FromServices] DAL<Artista> artistaDAL, [FromBody] ArtistaResquest artistaRequest) =>
        {
            // Convertendo artista request para Artista
            var artista = new Artista(artistaRequest.nome, artistaRequest.bio);

            var artistaAhAtualizar = artistaDAL.RecuperarPor(art => art.Id == artista.Id);
            if (artistaAhAtualizar is null) return Results.NotFound();

            artistaAhAtualizar.Nome = artista.Nome;
            artistaAhAtualizar.Bio = artista.Bio;
            artistaAhAtualizar.FotoPerfil = artista.FotoPerfil;

            artistaDAL.Atualizar(artistaAhAtualizar);
            return Results.Ok();
        });
    }
}
