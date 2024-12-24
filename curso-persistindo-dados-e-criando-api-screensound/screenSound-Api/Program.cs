using System.Text.Json.Serialization;
using screenSound_Api.Endpoints;
using ScreenSound.Banco_com_Entity;
using ScreenSound.Banco_Entity;
using ScreenSound.Modelos;

var builder = WebApplication.CreateBuilder(args);

//Adicionando recursos do Swagger na API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionando contexto de EF e classe DAL para evitar repei��o de instancia��o no c�digo.
builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();

// Configura��o para que o ASPNETCore serialize os dados retornados do banco, essa configura��o � feita para SYstem.Text.Json, ela apresentou conflito com o EF proxies.
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

var app = builder.Build();

app.AddEndPointsArtista();
app.AddEndPointsMusica();


// Declarando uso de Swagger quando a aplica��o for executada...
app.UseSwagger();
app.UseSwaggerUI();

// Em Properties/launchSettings.json adicionamos uma configura��o para que ao iniciar a aplica��o o navegador nos direcione direto para o swagger.

// Nos portocolos http e https: "launchUrl": "Swagger/index.html"

app.Run();
