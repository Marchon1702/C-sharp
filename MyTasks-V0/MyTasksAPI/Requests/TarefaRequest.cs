namespace MyTasksAPI.Requests;

public record TarefaRequest(string Nome, string Prioridade, DateOnly DataInicio, DateOnly DataFim);
