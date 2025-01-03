using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ScreenSound.API.Endpoints;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Dados.Modelos;
using ScreenSound.Shared.Modelos.Modelos;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>((options) => {
    options
            .UseSqlServer(builder.Configuration["ConnectionStrings:ScreenSoundDB"])
            .UseLazyLoadingProxies();
});

// Adicionando Endpoints do Identity usando como Types PessoaComAcesso
builder.Services
    .AddIdentityApiEndpoints<PessoaComAcesso>()
    // Informando que o EF será usado como "Armazem de informações (Stores) usando o Contexto ScreendSoundContext"
    .AddEntityFrameworkStores<ScreenSoundContext>();

// Adicionando recursos de autorização da Lib Identity
builder.Services.AddAuthorization();

builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();
builder.Services.AddTransient<DAL<Genero>>();
builder.Services.AddTransient<DAL<PessoaComAcesso>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(
    options => options.AddPolicy(
        "wasm",
        policy => policy.WithOrigins([builder.Configuration["BackendUrl"] ?? "https://localhost:7089",
            builder.Configuration["FrontendUrl"] ?? "https://localhost:7015"])
            .AllowAnyMethod()
            .SetIsOriginAllowed(pol => true)
            .AllowAnyHeader()
            .AllowCredentials())
);


var app = builder.Build();

app.UseCors("wasm");

app.UseStaticFiles();

// Atenção: Ao chamar esse método nós definimos metaforicamente uma "catraca" que limita o acesso de usuários, apenas permitindo o acesso após autorização ser bem sucedida.
// O próximo passo é tratar as autorizações nos EndPoints, que queremos adicionar essa "catraca".
app.UseAuthorization();

app.AddEndPointsArtistas();
app.AddEndPointsMusicas();
app.AddEndPointGeneros();

// Criando um efeito visual na Api que mapeia e agrupa na rota "auth", os endpoints da IdentityApi usando PessoaComAcesso como modelo de dados e a tag desse agrupamento se chamará Autorization.
app.MapGroup("auth").MapIdentityApi<PessoaComAcesso>().WithTags("Authorization");

// Criando requisição para o usuário deslogar da aplicação, esse método apaga o cookie de sessão do usuário que está salvo no navegador.
app.MapPost("auth/logout", async ([FromServices] SignInManager<PessoaComAcesso> signInManager) =>
{
    await signInManager.SignOutAsync();
}).RequireAuthorization().WithTags("Authorization");


app.UseSwagger();
app.UseSwaggerUI();

app.Run();
