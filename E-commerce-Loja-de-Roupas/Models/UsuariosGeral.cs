namespace E_commerce_Loja_de_Roupas.Models;

internal class UsuariosGeral
{
    private List<Usuario> usuarios = new List<Usuario> 
    {
        new Usuario("Alice", "senha123", "Rua das Flores, 123", new List<ProdutoPreAdquirido> 
        { 
            new ProdutoPreAdquirido("Camisa", "Bonita Camisa", 25, "Camisas", "G", 2, 1),
            new ProdutoPreAdquirido("Camisa", "Bonita Camisa", 25, "Camisas", "G", 4, 1),
            new ProdutoPreAdquirido("Camisa", "Bonita Camisa", 25, "Camisas", "G", 1, 1),
            new ProdutoPreAdquirido("Camisa", "Bonita Camisa", 25, "Camisas", "G", 7, 1),
        }),
        new Usuario("Bob", "senha456", "Avenida Central, 456", new List<ProdutoPreAdquirido>()),
        new Usuario("Carlos", "senha789", "Travessa das Palmeiras, 789", new List<ProdutoPreAdquirido>()),
        new Usuario("Diana", "senha321", "Praça das Nações, 321", new List<ProdutoPreAdquirido>()),
        new Usuario("Eduardo", "senha654", "Rua das Acácias, 654", new List<ProdutoPreAdquirido>())
    };
    public IEnumerable<Usuario> RetornarTodosOsUsuarios() => usuarios;
    
    public void AdicionarUsuario(Usuario novoUsuario) => usuarios.Add(novoUsuario);
}
