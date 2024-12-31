using Microsoft.AspNetCore.Identity;

namespace ScreenSound.Shared.Dados.Modelos;

// PerfilDeAcesso segue o mesmo padrão de PerfilComAcesso, porém ele herda de IdentityRole.
// IndentityRole cuida de funções do usuário..
public class PerfilDeAcesso : IdentityRole<int>
{}
