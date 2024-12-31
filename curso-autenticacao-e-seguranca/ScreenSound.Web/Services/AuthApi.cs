using System.Net.Http.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using ScreenSound.Web.Response;

namespace ScreenSound.Web.Services;

// Recebe um factory
public class AuthAPI(IHttpClientFactory factory) : AuthenticationStateProvider
{
    // gerenciador de autenticação
    private bool _autenticado = false;
    // Cria um cliente API
    private readonly HttpClient _httpClient = factory.CreateClient("API");

    // Implementando classe abstrata de AuthenticationStateProvider, ela é responsavel por identificar o estado de autenticação e propagar esse estado por toda a aplicação, além de retornar uma identidade autenticada ou não.
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        _autenticado = false;
        // Criando estado de autenticação que o método tem que retornar
        var pessoa = new ClaimsPrincipal();

        // na rota "auth/manage/info" é retornado um usuário caso tenha algum autenticado, essa rota é criado pela Api com Identity, está no projeto da API.

        // Realiza a requisição no endPoint
        var response = await _httpClient.GetAsync("auth/manage/info");

        // Se a requisição obter sucesso
        if (response.IsSuccessStatusCode)
        {
            // Captura o Json retornado pela requisição
            var info = await response.Content.ReadFromJsonAsync<InfoPessoaResponse>();

            // Pega a informação da requisição e relaciona com um array de Claim, onde ClaymTypes é uma classe abstrata que relaciona os dados do usuário obtidos pelo endpoint e declara eles para a identity.
            Claim[] dados = [
                new Claim(ClaimTypes.Name, info.Email),
                new Claim(ClaimTypes.Email, info.Email)
            ];

            // identificando a pessoa passando o array de Claims e como segundo argumento o tipo de autenticação.
            var identity = new ClaimsIdentity(dados, "Cookies");
            // Adicionando identificação a Pessoa.
            pessoa = new ClaimsPrincipal(identity);

            // mudando o boleando de autenticado para controlar outros métodos
            _autenticado = true;
        }

        // Caso pessoa seja null, o usuário não está autenticado.
        return new AuthenticationState(pessoa);
    }

    // Realizar requisição...
    public async Task<AuthResponse> LoginAsync(string email, string senha)
    {
        // Response executa a requisição e armazena o retorno do status final
        var response = await _httpClient.PostAsJsonAsync("auth/login?useCookies=true", new
        {
            email,
            password = senha
        });

        if (response.IsSuccessStatusCode)
        {
            // O único momento em que o estado de autenticação muda é na realização do Login, se essa condição for verdadeira então o Login foi feito, logo a linha abaixo informa isso para a aplicação

            // O argumento da autenticação é o retorno do método acima, que retorna uma identidade autenticada ou não.
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            // Instanciando uma classe setando sua prop com Sucesso com o valor true
            return new AuthResponse { Sucesso = true };
        }

        // Instanciando em caso de erro o Sucesso como false e adicionando o valor do erro.
        return new AuthResponse { Sucesso = false, Erros = ["Login/senha inválidos"] };
    }

    // Fazendo requisição para deslogar da applicação (Apagar o cookie no navegador)
    public async Task LogoutAsync()
    {
        await _httpClient.PostAsync("auth/logout", null);
        // Informando que o estado de autorização foi modificado
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task<bool> VerificaAutenticado()
    {
        // Executadando método que captura autenticado para receber o controlador de autenticação.
        await GetAuthenticationStateAsync();
        return _autenticado;
    }
}
