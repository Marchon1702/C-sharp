using ScreenSound.Banco_Entity;
using ScreenSound.Modelos;

namespace ScreenSound.Banco_com_Entity;

// DAL é uma classe que contém todos os métodos padrões de um CRUD simples da aplicação em conjunto com o Banco de SQLServer, sabendo que esses métodos se repetem em diversas classes DAL, eles são feitos em DAL sendo a classe pai para evitar códigos iguais em diversas classes DAL.

// Declarando que T é uma classe para usar o EntityGenerics (<T> where T : class )
internal class DAL<T> where T : class 
{
    protected readonly ScreenSoundContext context;

    public DAL(ScreenSoundContext context)
    {
        this.context = context;
    }

    // Retorna a DbSet de context que relaciona a classe T do sistema, para a Tabela do Banco "T".
    public IEnumerable<T> Listar()
    {
        // Sabendo que pra acessar os métodos de CRUD do Entity nós temos que informar o nome da tabela a ser executados o método, EX:  context.Artistas.ToList();
        // O EF criou uma forma de declarar essa informação de forma genérica usando o Set<T>().
        // Assim quando chamarmos esse métodos nas classes filhas de DAL, o seu gerenic será associado a Set<T>()
        // Para essa implementação funcionar o generics da classe deve ter uma declaração dizendo qual estrutura esse gerenics é, no caso T é uma class.
        return context.Set<T>().ToList();
    }

    // Adicionando T com método direto do Entity...
    public void Adicionar(T objeto)
    {
        context.Set<T>().Add(objeto);
        context.SaveChanges();
    }
    // Update do Entity realiza a lógica de edição de forma interna dentro do próprio banco...
    public void Atualizar(T objeto)
    {       
        context.Set<T>().Update(objeto);
        context.SaveChanges();
    }

    public void Deletar(T objeto)
    {
        context.Set<T>().Remove(objeto);
        context.SaveChanges();
    }

    // Recuperar pelo nome se tornou recuperarPor, um método que ao invés de recuperar apenas por uma condição, ele é capaz de receber condições diferentes que serão passadas como argumento.
    public T? RecuperarPor(Func<T, bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao);
    }

    public IEnumerable<T>? ListarPor(Func<T, bool> condicao)
    {
        return context.Set<T>().Where(condicao);
    }
}
