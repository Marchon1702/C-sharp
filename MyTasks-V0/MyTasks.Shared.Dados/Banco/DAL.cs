namespace MyTasks.Shared.Dados.Banco;

public class DAL<T> where T : class
{
    private readonly MyTasksContext _context;

    public DAL(MyTasksContext context)
    {
        _context = context;
    }

    public IEnumerable<T> Listar()
    {
        return _context.Set<T>().ToList();
    }

    public void Adicionar(T obj)
    {
        _context.Set<T>().Add(obj);
        _context.SaveChanges();
    }

    public void Atualizar(T obj)
    {
        _context.Set<T>().Update(obj);
        _context.SaveChanges();
    }

    public void Remover(T obj)
    {
        _context.Set<T>().Remove(obj);
        _context.SaveChanges();
    }

    public T? RecuperarPor(Func<T, bool> condicao)
    {
        return _context.Set<T>().FirstOrDefault(condicao);
    }

    public IEnumerable<T> ListarPor(Func<T, bool> condicao)
    {
        return _context.Set<T>().Where(condicao);
    }
}
