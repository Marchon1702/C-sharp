namespace ScreenSound.Modelos;

public class Genero
{
    public int Id { get; set; }
    public string? Nome { get; set; } = "";
    public string? Descricao { get; set; } = "";
    // Um genero pode ter muitas músicas
    public virtual ICollection<Musica> Musicas { get; set; }

    public override string ToString()
    {
        return $"Nome: {Nome} - Descrição: {Descricao}";
    }
}
