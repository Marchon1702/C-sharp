using Microsoft.AspNetCore.Mvc;
using MyTasks.Shared.Dados.Banco;
using MyTasks.Shared.Modelos.Modelos;
using MyTasksAPI.Requests;

namespace MyTasksAPI.EndPoints;

public static class TarefaExtensions 
{
    public static void AddEnpointsTarefa(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("tarefas").WithTags("Tarefas");

        groupBuilder.MapGet("", ([FromServices] DAL<Tarefa> tarefasDAL) =>
        {
            var listaDeTarefas = tarefasDAL.Listar();

            if (listaDeTarefas is null) return Results.NotFound();

            return Results.Ok(listaDeTarefas);
        });

        groupBuilder.MapGet("{nome}", ([FromServices] DAL<Tarefa> tarefasDAL, string nome) =>
        {
            var tarefa = tarefasDAL.ListarPor(t => t.Nome.ToUpper().Equals(nome.ToUpper()));
            if(tarefa is null) return Results.NotFound();

            return Results.Ok(tarefa);
        });

        groupBuilder.MapPost("", ([FromServices] DAL<Tarefa> tarefasDAL, [FromBody] TarefaRequest request) =>
        {
            var tarefa = new Tarefa() 
            {
                Nome = request.Nome,
                Prioridade = request.Prioridade,
                Concluida = false
            };
            tarefa.ValidaDatas(request.DataInicio, request.DataFim);

            tarefasDAL.Adicionar(tarefa);

            return Results.Created();
        });

        groupBuilder.MapPut("", ([FromServices] DAL<Tarefa> tarefasDAL, [FromBody] TarefaRequestEdit request) =>
        {
            var tarefaAhEditar = tarefasDAL.RecuperarPor(t => t.Id == request.Id);
            if(tarefaAhEditar is null) return Results.NotFound();

            tarefaAhEditar.Nome = request.Nome;
            tarefaAhEditar.Prioridade = request.Prioridade;
            tarefaAhEditar.Concluida = request.Concluido;
            tarefaAhEditar.ValidaDatas(request.DataInicio, request.DataFim);

            tarefasDAL.Atualizar(tarefaAhEditar);
            return Results.Ok();
        });

        groupBuilder.MapDelete("{id}", ([FromServices] DAL<Tarefa> tarefasDAL, int id) =>
        {
            var tarefaAhDeletar = tarefasDAL.RecuperarPor(t => t.Id == id);
            if(tarefaAhDeletar is null) return Results.NotFound();

            tarefasDAL.Remover(tarefaAhDeletar);
            return Results.NoContent();
        });
    }
}
