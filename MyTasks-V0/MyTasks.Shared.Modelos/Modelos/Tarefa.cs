namespace MyTasks.Shared.Modelos.Modelos;

public class Tarefa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Prioridade { get; set; }
    public DateOnly DataInicio { get; set; }
    public DateOnly DataFim { get; set; }
    public bool Concluida { get; set; } = false;

    public void ValidaDatas(DateOnly dataInicio, DateOnly dataFim)
    {
        var dataDeHoje = DateOnly.FromDateTime(DateTime.Now);

        if (dataInicio < dataDeHoje) DataInicio = dataDeHoje;
        else DataInicio = dataInicio;

        if (dataFim < DataInicio) DataFim = dataInicio;
        else DataFim = dataFim;
    }
}
