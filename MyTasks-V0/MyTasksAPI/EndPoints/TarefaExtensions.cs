using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Shared.Dados.Banco;
using MyTasks.Shared.Dados.Modelos;
using MyTasksAPI.Requests;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyTasksAPI.EndPoints;

public static class TarefaExtensions 
{
    public static void AddEnpointsTarefa(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("tarefas").RequireAuthorization().WithTags("Tarefas");

        groupBuilder.MapGet("", (
            HttpContext context,
            [FromServices] DAL<Tarefa> tarefasDAL, 
            [FromServices]
        DAL<UsuarioAutenticado> usuarioDAL
            ) =>
        {
            var email = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? throw new InvalidOperationException("Pessoa não encontrada");
            var usuarioAutenticado = usuarioDAL.RecuperarPor(p => p.Email.Equals(email)) ?? throw new InvalidOperationException("Pessoa não encontrada");

            var listaDeTarefas = tarefasDAL.ListarPor(t => t.UsuarioAutenticadoId == usuarioAutenticado.Id);
            var listaDeTarefasResponse = EntityListToResponseList(listaDeTarefas);

            if (listaDeTarefas is null) return Results.NotFound();

            return Results.Ok(listaDeTarefasResponse);
        });

        groupBuilder.MapGet("{nome}", (
            HttpContext context,
            [FromServices] DAL<Tarefa> tarefasDAL,
            [FromServices]
            DAL<UsuarioAutenticado> usuarioDAL,
            string nome
            ) =>
        {
            var email = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? throw new InvalidOperationException("Pessoa não encontrada");
            var usuarioAutenticado = usuarioDAL.RecuperarPor(p => p.Email.Equals(email)) ?? throw new InvalidOperationException("Pessoa não encontrada");
            var listaDeTarefas = tarefasDAL.ListarPor(t => t.UsuarioAutenticadoId == usuarioAutenticado.Id);

            var tarefa = listaDeTarefas.FirstOrDefault(t => t.Nome.ToUpper().Equals(nome.ToUpper()));
            var tarefaResponse = EntityToResponse(tarefa);
            if (tarefa is null) return Results.NotFound();

            return Results.Ok(tarefaResponse);
        });

        groupBuilder.MapPost("", (
            HttpContext context,
            [FromServices] DAL<Tarefa> tarefasDAL,
            [FromServices]
            DAL<UsuarioAutenticado> usuarioDAL,
            [FromBody] TarefaRequest request
            ) =>
        {
            var email = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? throw new InvalidOperationException("Pessoa não encontrada");
            var usuarioAutenticado = usuarioDAL.RecuperarPor(p => p.Email.Equals(email)) ?? throw new InvalidOperationException("Pessoa não encontrada");

            var tarefa = new Tarefa() 
            {
                Nome = request.Nome,
                Prioridade = request.Prioridade,
                Concluida = false,
                UsuarioAutenticadoId = usuarioAutenticado.Id
            };
            tarefa.ValidaDatas(request.DataInicio, request.DataFim);

            tarefasDAL.Adicionar(tarefa);

            return Results.Created();
        });

        groupBuilder.MapPut("", (
            HttpContext context, 
            [FromServices] DAL<Tarefa> tarefasDAL, 
            [FromServices] DAL<UsuarioAutenticado> usuarioDAL, 
            [FromBody] TarefaRequestEdit request) =>
        {
            var email = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? throw new InvalidOperationException("Pessoa não encontrada");
            var usuarioAutenticado = usuarioDAL.RecuperarPor(p => p.Email.Equals(email)) ?? throw new InvalidOperationException("Pessoa não encontrada");
            var listaDeTarefas = tarefasDAL.ListarPor(t => t.UsuarioAutenticadoId == usuarioAutenticado.Id);

            var tarefaAhEditar = listaDeTarefas.FirstOrDefault(t => t.Id == request.Id);
            if(tarefaAhEditar is null) return Results.NotFound();

            tarefaAhEditar.Nome = request.Nome;
            tarefaAhEditar.Prioridade = request.Prioridade;
            tarefaAhEditar.Concluida = request.Concluida;
            tarefaAhEditar.ValidaDatas(request.DataInicio, request.DataFim);

            tarefasDAL.Atualizar(tarefaAhEditar);
            return Results.Ok();
        });

        groupBuilder.MapDelete("{id}", (
            HttpContext context,
            [FromServices] DAL<Tarefa> tarefasDAL,
            [FromServices] DAL<UsuarioAutenticado> usuarioDAL, 
            int id
            ) =>
        {
            var email = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? throw new InvalidOperationException("Pessoa não encontrada");
            var usuarioAutenticado = usuarioDAL.RecuperarPor(p => p.Email.Equals(email)) ?? throw new InvalidOperationException("Pessoa não encontrada");
            var listaDeTarefas = tarefasDAL.ListarPor(t => t.UsuarioAutenticadoId == usuarioAutenticado.Id);

            var tarefaAhDeletar = listaDeTarefas.FirstOrDefault(t => t.Id == id);
            if(tarefaAhDeletar is null) return Results.NotFound();

            tarefasDAL.Remover(tarefaAhDeletar);
            return Results.NoContent();
        });
    }
    private static ICollection<TarefaResponse> EntityListToResponseList(IEnumerable<Tarefa> listaDeTarefas)
    {
        return listaDeTarefas.Select(a => EntityToResponse(a)).ToList();
    }

    private static TarefaResponse EntityToResponse(Tarefa tarefa)
    {
        return new TarefaResponse(tarefa.Id, tarefa.Nome!, tarefa.Prioridade!, tarefa.DataInicio, tarefa.DataFim, tarefa.Concluida);
    }
}
