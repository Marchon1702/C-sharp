using System.Text.Json.Serialization;
using screenSound_Api.Endpoints;
using ScreenSound.Banco_com_Entity;
using ScreenSound.Banco_Entity;
using ScreenSound.Modelos;

var builder = WebApplication.CreateBuilder(args);

//Adicionando recursos do Swagger na API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionando contexto de EF e classe DAL para evitar repeição de instanciação no código.
builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();

// Configuração para que o ASPNETCore serialize os dados retornados do banco, essa configuração é feita para SYstem.Text.Json, ela apresentou conflito com o EF proxies.
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

var app = builder.Build();

app.AddEndPointsArtista();
app.AddEndPointsMusica();


// Declarando uso de Swagger quando a aplicação for executada...
app.UseSwagger();
app.UseSwaggerUI();

// Em Properties/launchSettings.json adicionamos uma configuração para que ao iniciar a aplicação o navegador nos direcione direto para o swagger.

// Nos portocolos http e https: "launchUrl": "Swagger/index.html"

app.Run();
