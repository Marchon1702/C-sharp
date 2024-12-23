using ScreenSound.Banco_com_Entity;
using ScreenSound.Banco_Entity;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Adicionando contexto de EF e classe DAL para evitar repeição de instanciação no código.
builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();

// Configuração para que o ASPNETCore serialize os dados retornados do banco, essa configuração é feita para SYstem.Text.Json, ela apresentou conflito com o EF proxies.
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

var app = builder.Build();

// [FromServices] indica que o arguemento para o parâmetro artistaDAL foi injetado de da Prop Services no builder.
app.MapGet("/Artistas", ([FromServices] DAL<Artista> artistaDAL) =>
{
    var artistas =  artistaDAL.Listar();

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

app.MapGet("/Artistas/{nome}", ([FromServices] DAL < Artista > artistaDAL, string nome) =>
{
    var artista = artistaDAL.RecuperarPor(artista => artista.Nome.ToUpper().Equals(nome.ToUpper().Trim()));

    if(artista is null) return Results.NotFound();

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
app.MapPost("/Artistas", ([FromServices] DAL <Artista> artistaDAL, [FromBody] Artista artista) =>
{
    artistaDAL.Adicionar(artista);
    return Results.Ok();
});

app.MapDelete("/Artistas/{id}", ([FromServices] DAL<Artista> artistaDAL, int id) =>
{
    var artista = artistaDAL.RecuperarPor(artista => artista.Id == id);
    if(artistaDAL is null) return Results.NotFound();

    artistaDAL.Deletar(artista!);
    return Results.NoContent();
});

app.MapPut("/Artistas", ([FromServices] DAL<Artista> artistaDAL,[FromBody] Artista artista) =>
{
    var artistaAhAtualizar = artistaDAL.RecuperarPor(art => art.Id == artista.Id);
    if (artistaAhAtualizar is null) return Results.NotFound();

    artistaAhAtualizar.Nome = artista.Nome;
    artistaAhAtualizar.Bio = artista.Bio;
    artistaAhAtualizar.FotoPerfil = artista.FotoPerfil;

    artistaDAL.Atualizar(artistaAhAtualizar);
    return Results.Ok();
});

app.Run();
