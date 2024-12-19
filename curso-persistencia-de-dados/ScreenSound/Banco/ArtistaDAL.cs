using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

internal class ArtistaDAL
{
    public IEnumerable<Artista> Listar()
    {
        var listaDeArtistas = new List<Artista>();
        // Abrindo conexão
        using var connection = new Connection().ObterConexao();
        connection.Open();

        // Definindo comando a ser executado no banco com a classe SqlCommand
        string sql = "SELECT * FROM Artistas";
        // Recebe o comando e conexão como argumento        
        SqlCommand command = new SqlCommand(sql, connection);
        // Criando um leitor de dados resultante do comando adicionado
        using SqlDataReader dataReader = command.ExecuteReader();

        // Enquanto tiver linhas da tabela para ler...
        while (dataReader.Read())
        {
            // Pegando os dados das colunas nas linhas da tabela do indice atual
            string nomeArtista = Convert.ToString(dataReader["Nome"])!;
            string bioArtista = Convert.ToString(dataReader["Bio"])!;
            int idArtista = Convert.ToInt32(dataReader["Id"]);

            // Criando novo objeto Artista com os dados obtidos e adicionando à lista
            Artista artista = new Artista(nomeArtista, bioArtista);
            artista.Id = idArtista;

            listaDeArtistas.Add(artista);
        }

        return listaDeArtistas;
    }

    // Adicionando artista recebi na Aplicação para o banco de dados...
    public void Adicionar(Artista artista)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();

        string sql = "INSERT INTO Artistas (Nome, FotoPerfil, Bio) VALUES (@nome, @perfilPadrao, @bio)"; 
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@nome", artista.Nome);
        command.Parameters.AddWithValue("@perfilPadrao", artista.FotoPerfil);
        command.Parameters.AddWithValue("@bio", artista.Bio);

        // Verificando se a adição foi bem sucedida

        // Método que verifica quantas linha foram afetadas
        int linhasAfetadas = command.ExecuteNonQuery();
        Console.WriteLine($"Linhas afetadas {linhasAfetadas}");
    }

    public void Editar(Artista artista)
    {
        using var connection = new Connection().ObterConexao(); 
        connection.Open();

        string sql = "UPDATE Artistas SET Nome = @nome, Bio = @bio WHERE Id = @id";
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@nome", artista.Nome);
        command.Parameters.AddWithValue("@bio", artista.Bio);
        command.Parameters.AddWithValue("@id", artista.Id);

        int linhasAfetadas = command.ExecuteNonQuery();
        Console.WriteLine($"Linhas afetadas {linhasAfetadas}");
    }

    public void Deletar(Artista artista)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();

        string sql = "DELETE FROM Artistas WHERE Id = @id";
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", artista.Id);

        int linhasAfetadas = command.ExecuteNonQuery();
        Console.WriteLine($"Linhas afetadas {linhasAfetadas}");
    }
}
