
using Microsoft.AspNetCore.Identity;

namespace MyTasks.Shared.Dados.Modelos;

public class UsuarioAutenticado : IdentityUser<int>
{
    public virtual ICollection<Tarefa> Tarefas { get; set; }
}
