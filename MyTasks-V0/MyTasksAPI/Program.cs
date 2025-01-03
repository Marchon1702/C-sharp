using Microsoft.EntityFrameworkCore;
using MyTasks.Shared.Dados.Banco;
using MyTasks.Shared.Modelos.Modelos;
using MyTasksAPI.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyTasksContext>(options =>
{
    options
      .UseSqlServer(
        builder.Configuration.GetConnectionString("MyTasksDB"))
            .UseLazyLoadingProxies();
});

builder.Services.AddTransient<DAL<Tarefa>>();

var app = builder.Build();

app.AddEnpointsTarefa();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
