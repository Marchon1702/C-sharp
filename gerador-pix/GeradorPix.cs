namespace gerador_pix;

/// <summary>
/// Classe que gera chaves Pix usando o formato Guid.
/// </summary>
public static class GeradorPix
{
    /// <summary>
    /// Método que retorna uma chave aleatória de PIX.
    /// </summary>
    /// <returns>Retorna uma chave PIX no formato String.</returns>
    public static string GerarChavePix() => Guid.NewGuid().ToString();

    /// <summary>
    ///  Método que retorna uma lista aleatória de
    ///  chaves Pix.
    /// </summary>
    /// <param name="quantidadeDeChaves"> Quantidade de chaves
    /// a serem geradas.</param>
    /// <returns>Lista de strings de chaves Pix.</returns>
    public static List<string> GerarListaDeChavesPix(int quantidadeDeChaves)
    {
        if (quantidadeDeChaves <= 0) return null;
        else
        {
            var chaves = new List<string>();
            for (int i = 0; i < quantidadeDeChaves; i++)
            {
                chaves.Add(Guid.NewGuid().ToString());
            }
            return chaves;
        }
    }
}