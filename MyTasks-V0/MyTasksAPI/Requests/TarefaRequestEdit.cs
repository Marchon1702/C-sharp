namespace MyTasksAPI.Requests;

public record TarefaRequestEdit(int Id, string Nome, string Prioridade, DateOnly DataInicio, DateOnly DataFim, bool Concluido);
