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
    // Informando que o EF ser� usado como "Armazem de informa��es (Stores) usando o Contexto ScreendSoundContext"
    .AddEntityFrameworkStores<ScreenSoundContext>();

// Adicionando recursos de autoriza��o da Lib Identity
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

// Aten��o: Ao chamar esse m�todo n�s definimos metaforicamente uma "catraca" que limita o acesso de usu�rios, apenas permitindo o acesso ap�s autoriza��o ser bem sucedida.
// O pr�ximo passo � tratar as autoriza��es nos EndPoints, que queremos adicionar essa "catraca".
app.UseAuthorization();

app.AddEndPointsArtistas();
app.AddEndPointsMusicas();
app.AddEndPointGeneros();

// Criando um efeito visual na Api que mapeia e agrupa na rota "auth", os endpoints da IdentityApi usando PessoaComAcesso como modelo de dados e a tag desse agrupamento se chamar� Autorization.
app.MapGroup("auth").MapIdentityApi<PessoaComAcesso>().WithTags("Authorization");

// Criando requisi��o para o usu�rio deslogar da aplica��o, esse m�todo apaga o cookie de sess�o do usu�rio que est� salvo no navegador.
app.MapPost("auth/logout", async ([FromServices] SignInManager<PessoaComAcesso> signInManager) =>
{
    await signInManager.SignOutAsync();
}).RequireAuthorization().WithTags("Authorization");


app.UseSwagger();
app.UseSwaggerUI();

app.Run();
