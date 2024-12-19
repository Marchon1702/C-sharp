using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

// Classe responsavel por se conectar com o banco de dados do SQL server.
internal class Connection
{
    // Connect Timeout=30, esse comando representa o tempo de conexão que o banco levará para se conectar, mas esse comando foi tirado a fim de otimizar o tempo da aula.
    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=screenSound-DB;Integrated Security=True; Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    // Método responsável por conectar-se ao banco de dados com o parâmetro sendo o endereção da cadeia de conexão.
    public SqlConnection ObterConexao() => new SqlConnection(connectionString);

    
}
