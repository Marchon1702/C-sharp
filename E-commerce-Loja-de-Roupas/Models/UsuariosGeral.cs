namespace E_commerce_Loja_de_Roupas.Models;

internal class UsuariosGeral
{
    public static IEnumerable<Usuario> RetornarTodosOsUsuarios()
    {
        IEnumerable<Usuario> usuarios = new List<Usuario>
        {
            new Usuario("Alice", "senha123", "Rua das Flores, 123", new List<Produto>()),
            new Usuario("Bob", "senha456", "Avenida Central, 456", new List<Produto>()),
            new Usuario("Carlos", "senha789", "Travessa das Palmeiras, 789", new List<Produto>()),
            new Usuario("Diana", "senha321", "Praça das Nações, 321", new List<Produto>()),
            new Usuario("Eduardo", "senha654", "Rua das Acácias, 654", new List<Produto>())
        };
        return usuarios;
    }
}
