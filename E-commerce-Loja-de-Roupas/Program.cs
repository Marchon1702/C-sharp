using E_commerce_Loja_de_Roupas.Models;
using E_commerce_Loja_de_Roupas.Views;
using E_commerce_Loja_de_Roupas.Views.Pages;

AreaDeLogin areaDeLogin = new AreaDeLogin();
areaDeLogin.Verificar();
Usuario usuarioLogado = areaDeLogin.Usuario!;
NavegacaoGeral navegacaoGeral = new NavegacaoGeral(usuarioLogado);

if (areaDeLogin.Liberado) navegacaoGeral.ExibirOpcoesDeNavegacao();
else new PaginaProdutos(usuarioLogado).Executar();
