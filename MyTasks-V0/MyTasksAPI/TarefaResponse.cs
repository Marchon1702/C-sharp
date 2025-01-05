namespace MyTasksAPI;

public record TarefaResponse(int Id, string Nome, string Prioridade, DateOnly DataInicio, DateOnly DataFim, bool Concluida);
