namespace E_commerce_Loja_de_Roupas.Models;

internal class UsuariosGeral
{
    private List<Usuario> usuarios = new List<Usuario> 
    {
        new Usuario("Alice", "senha123", "Rua das Flores, 123", new List<Produto> 
        { 
            new Produto("Camisa", "Bonita Camisa", 25, "Camisas", "G", 2 ),
            new Produto("Calca", "Bonita Camisa", 25, "Camisas", "G", 4 ),
            new Produto("Boné", "Bonita Camisa", 25, "Camisas", "G", 1 ),
            new Produto("Casaco", "Bonita Camisa", 25, "Camisas", "G", 7 ),
        }),
        new Usuario("Bob", "senha456", "Avenida Central, 456", new List<Produto>()),
        new Usuario("Carlos", "senha789", "Travessa das Palmeiras, 789", new List<Produto>()),
        new Usuario("Diana", "senha321", "Praça das Nações, 321", new List<Produto>()),
        new Usuario("Eduardo", "senha654", "Rua das Acácias, 654", new List<Produto>())
    };
    public IEnumerable<Usuario> RetornarTodosOsUsuarios() => usuarios;
    
    public void AdicionarUsuario(Usuario novoUsuario) => usuarios.Add(novoUsuario);
}
