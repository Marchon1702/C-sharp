using Microsoft.AspNetCore.Identity;

namespace ScreenSound.Shared.Dados.Modelos;

// Criando classe modelo PerfilDeAcesso, essa classe herda de IdentityUser que possui características de uma classe de autenticação, isso nos poupa de criar um modelo do zero e nos permite aproveitar todas as funcionalidades da classe Pai que vem da lib Indentity.

// <int> serve para definir o tipo da PrimariKey que será criada no banco de dados, nesse projeto outras entidades tem como tipo de PK sendo int então esse padrão se repete.

// Não esqueça de tornar a classe publica por questões de visibilidade.
//IndentityUser cuida caracteristicas de perfis dos usuários.
public class PessoaComAcesso : IdentityUser<int>
{}
