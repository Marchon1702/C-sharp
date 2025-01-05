using Microsoft.EntityFrameworkCore;
using MyTasks.Shared.Dados.Banco;
using MyTasks.Shared.Dados.Modelos;
using MyTasksAPI.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityApiEndpoints<UsuarioAutenticado>()
    .AddEntityFrameworkStores<MyTasksContext>();

builder.Services.AddAuthorization();

builder.Services.AddDbContext<MyTasksContext>(options =>
{
    options
      .UseSqlServer(
        builder.Configuration.GetConnectionString("MyTasksDB"))
            .UseLazyLoadingProxies();
});

builder.Services.AddTransient<DAL<UsuarioAutenticado>>();
builder.Services.AddTransient<DAL<Tarefa>>();

var app = builder.Build();

app.UseAuthorization();

app.AddEnpointsTarefa();

app.MapGroup("auth").MapIdentityApi<UsuarioAutenticado>().WithTags("Autorização");

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
