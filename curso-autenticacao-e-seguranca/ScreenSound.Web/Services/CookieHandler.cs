
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace ScreenSound.Web.Services;

public class CookieHandler : DelegatingHandler
{
    // Deleganting handler é uma classe que nos permite executar ações antes que uma requisição senha retornada, ou finalizada.
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Adicionando credenciais do navegador incluindo cookies, ao retorno da requisição
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        return base.SendAsync(request, cancellationToken);
    }
}
