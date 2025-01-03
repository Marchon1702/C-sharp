using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using ScreenSound.Banco;
using ScreenSound.Migrations;
using ScreenSound.Modelos;
using ScreenSound.Shared.Dados.Modelos;

namespace ScreenSound.API.Endpoints;

public static class ArtistasExtensions
{
    public static void AddEndPointsArtistas(this WebApplication app)
    {

        #region Endpoint Artistas

        #region Forma "bruta" de usar autorização obrigatória
        // Uma das formas de especificarmos que determinada rota precisa de autorização para ser acessada é simplismente ao final de MapGet adicionar um método chamado RequireAuthorization

        // Ex:
        // app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
        //{
        // Lógica do endpoint    
        //}
        //).RequireAuthorization(); Isso já seria suficiente, esse método por padrão apenas obriga o usuario a estar autenticado(logado) na aplicação, porém tem mais exigencias a se fazer com ele.
        #endregion

        // Forma prática
        // Com o app mapeie um grupo com a rota artistas e adicione autorização necessária, esse grupo é separado visualmente para a área de Artistas.
        // WithTags e apenas um recurso visual que separa oque for de groupBuilder em uma "sessão" chamada artistas.
        var groupBuilder = app.MapGroup("artistas").RequireAuthorization().WithTags("Artistas");


        // Adicione groupBuilder em todas as rotas onde autorização for necessária.
        // O caminho "/artistas" na criação dos enpoints foi apagado pois o MapGroup já cria esse caminho para seus atribuidos.
        groupBuilder.MapGet("", ([FromServices] DAL<Artista> dal) =>
        {
            var listaDeArtistas = dal.Listar();
            if (listaDeArtistas is null)
            {
                return Results.NotFound();
            }
            var listaDeArtistaResponse = EntityListToResponseList(listaDeArtistas);
            return Results.Ok(listaDeArtistaResponse);
        });

        groupBuilder.MapGet("{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
        {
            var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (artista is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(EntityToResponse(artista));

        });

        groupBuilder.MapPost("", async ([FromServices]IHostEnvironment env,[FromServices] DAL<Artista> dal, [FromBody] ArtistaRequest artistaRequest) =>
        {
            
            var nome = artistaRequest.nome.Trim();
            var imagemArtista = DateTime.Now.ToString("ddMMyyyyhhss") + "." + nome + ".jpg";

            var path = Path.Combine(env.ContentRootPath,
                "wwwroot", "FotosPerfil", imagemArtista);

            using MemoryStream ms = new MemoryStream(Convert.FromBase64String(artistaRequest.fotoPerfil!));
            using FileStream fs = new(path, FileMode.Create);
            await ms.CopyToAsync(fs);

            var artista = new Artista(artistaRequest.nome, artistaRequest.bio) { FotoPerfil = $"/FotosPerfil/{imagemArtista}" };

            dal.Adicionar(artista);
            return Results.Ok();
        });

        groupBuilder.MapDelete("{id}", ([FromServices] DAL<Artista> dal, int id) => {
            var artista = dal.RecuperarPor(a => a.Id == id);
            if (artista is null)
            {
                return Results.NotFound();
            }
            dal.Deletar(artista);
            return Results.NoContent();

        });

        groupBuilder.MapPut("", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequestEdit artistaRequestEdit) => {
            var artistaAAtualizar = dal.RecuperarPor(a => a.Id == artistaRequestEdit.Id);
            if (artistaAAtualizar is null)
            {
                return Results.NotFound();
            }
            artistaAAtualizar.Nome = artistaRequestEdit.nome;
            artistaAAtualizar.Bio = artistaRequestEdit.bio;        
            dal.Atualizar(artistaAAtualizar);
            return Results.Ok();
        });

        groupBuilder.MapPost("avaliacoes",
            (
                HttpContext context,
                [FromBody] AvaliacaoArtistaRequest request,
                [FromServices] DAL<Artista> artistaDAL,
                [FromServices] DAL<PessoaComAcesso> pessoaDAL
            ) =>
        {
            var artista = artistaDAL.RecuperarPor(a => a.Id == request.ArtistaId);
            if(artista is null) return Results.NotFound();

            var email = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? throw new InvalidOperationException("Pessoa não encontrada");

            var pessoa = pessoaDAL.RecuperarPor(p => p.Email.Equals(email)) ?? throw new InvalidOperationException("Pessoa não encontrada");

            // verificando se pessoa já avaliou o artista
            var avaliacao = artista.Avaliacoes.FirstOrDefault(a => a.ArtistaId == artista.Id && a.PessoaId == pessoa.Id);

            // Se a pessoa nunca avaliou o artista antes adicione uma nova avaliacao
            if (avaliacao is null)
            {
                artista.AdicionarAvaliacao(pessoa.Id, request.Nota);
            } 
            // Se a pessoa já avaliou, só atualiza a nota e mantém o Id da pessoa com a ArtistaId
            else
            {
                avaliacao.Nota = request.Nota;
            }
            
            artistaDAL.Atualizar(artista);
            return Results.Created();
        });

        groupBuilder.MapGet("{id}/avaliacoes", 
            (
                int id,
                HttpContext context,
                [FromServices] DAL<Artista> artistaDAL,
                [FromServices] DAL<PessoaComAcesso> pessoaDAL
            ) =>
        {
            var artista = artistaDAL.RecuperarPor(a => a.Id == id);
            if(artista is null) return Results.NotFound();

            // email recebe o email relacionado com o cookie do navegador 
            var email = context.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value ?? throw new InvalidOperationException("Não foi encontrado email da pessoa logada!");

            // pessoa recupera o usuario logado no banco de dados comparando o email relacionado ao cookie do navegador com o email do usuário do banco
            var pessoa = pessoaDAL.RecuperarPor(p => p.Email.Equals(email)) ?? throw new InvalidOperationException("Não foi encontrado email da pessoa logada!");

            var avaliacao = artista.Avaliacoes.FirstOrDefault(a => a.ArtistaId == id && a.PessoaId == pessoa.Id);

            if (avaliacao is null) return Results.Ok(new AvaliacaoArtistaResponse(id, 0));
            else return Results.Ok(new AvaliacaoArtistaResponse(id, avaliacao.Nota));
        });
        #endregion
    }

    private static ICollection<ArtistaResponse> EntityListToResponseList(IEnumerable<Artista> listaDeArtistas)
    {
        return listaDeArtistas.Select(a => EntityToResponse(a)).ToList();
    }

    private static ArtistaResponse EntityToResponse(Artista artista)
    {
        return new ArtistaResponse(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil)
        {
            Classificacao = artista
            .Avaliacoes
            .Select(a => a.Nota)
            .DefaultIfEmpty(0)
            .Average()
        };
    }
}
