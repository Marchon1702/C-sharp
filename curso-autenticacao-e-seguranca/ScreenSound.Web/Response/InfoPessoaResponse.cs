namespace ScreenSound.Web.Response;

public class InfoPessoaResponse
{
    // Esse o formato da resposta que rota de estado do usuário entrega.
    public string? Email { get; set; }
    public bool IsEmailConfirmed { get; set; }
}
