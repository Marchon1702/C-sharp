using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco_com_Entity;
using ScreenSound.Modelos;
using screenSound_Api.Requests;
using screenSound_Api.Response;


namespace screenSound_Api.Endpoints;

// As classes no namespace Endpoints são classes que extendem o program.cs, é uma boa prática de código para que ocorra o encapsulamento e a divisão de responsabilidades, assim cada Endpoint de uma tabela fica separado por classe.
public static class ArtistaExtensions
{
    // WebApplication é um parâmetro indica q o método extende a classe program.cs usando a variável app....
    public static void AddEndPointsArtista(this WebApplication app)
    {
        // [FromServices] indica que o arguemento para o parâmetro artistaDAL foi injetado de da Prop Services no builder.
        app.MapGet("/Artistas", ([FromServices] DAL<Artista> artistaDAL) =>
        {
            var artistas = artistaDAL.Listar();

            if (artistas is null) return Results.NotFound();

            #region Corringindo problema com LazyLoading
        // Retornando um objeto diretamento devido a problemas com LazyLoadingProxies
        //var result = artistas.Select(a => new
        //{
        //    a.Id,
        //    a.Nome,
        //    a.Bio,
        //    a.FotoPerfil,
        //    a.Musicas
        //});

        // Criar um constructor vazio na classe Artista também resolveria pórem, o json sempre retorna um atributo vazio chama lazyLoader. 
        #endregion

            var artistasAhRetornar = (EntityListToResponseList(artistas));
            return Results.Ok(artistasAhRetornar);
        });

        app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> artistaDAL, string nome) =>
        {
            var artista = artistaDAL.RecuperarPor(artista => artista.Nome.ToUpper().Equals(nome.ToUpper().Trim()));

            if (artista is null) return Results.NotFound();

            #region Corringo problemas de LazyLoading
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
            #endregion

            // Como o response é modelado retornando um objeto que está na aplicação, o problema de LazyLoading já é resolvido.
            var artistaAhRetornar = EntityToResponse(artista);
            return Results.Ok(artistaAhRetornar);
        });

        // [FromBody] para indicar que esse parâmetro vem do corpo da requisição.
        app.MapPost("/Artistas", ([FromServices] DAL<Artista> artistaDAL, [FromBody] ArtistaRequest artistaRequest) =>
        {
            // Convertendo artista request para Artista
            var artista = new Artista(artistaRequest.Nome, artistaRequest.Bio);
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

        app.MapPut("/Artistas", ([FromServices] DAL<Artista> artistaDAL, [FromBody] ArtistaRequestEdit artistaRequestEdit) =>
        {
            var artistaAhAtualizar = artistaDAL.RecuperarPor(art => art.Id == artistaRequestEdit.Id);
            if (artistaAhAtualizar is null) return Results.NotFound();

            artistaAhAtualizar.Nome = artistaRequestEdit.Nome;
            if(artistaRequestEdit.Bio is null) artistaAhAtualizar.Bio = artistaAhAtualizar.Bio;
            else artistaAhAtualizar.Bio = artistaRequestEdit.Bio;
     
            artistaDAL.Atualizar(artistaAhAtualizar);
            return Results.Ok();
        });
    }

    // Método para modelar a response de uma lista de artistas
    public static ICollection<ArtistaResponse> EntityListToResponseList(IEnumerable<Artista> listaDeArtistas)
    {
        // Recebe uma lista de artista e retorna um ArtistaResponse para cada artista da lista.
        return listaDeArtistas.Select(a => EntityToResponse(a)).ToList();
    }

    // Método para modelar a response de um único objeto Artista
    public static ArtistaResponse EntityToResponse(Artista artista)
    {
        // Recebe um artista e rotorna a resposta modelada com ArtistaResponse
        return new ArtistaResponse(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil);
    }
}
