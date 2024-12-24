namespace ScreenSound.Modelos;

public class Musica
{
    public Musica(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; set; }
    public int Id { get; set; }
    public int? AnoLancamento { get; set; }
    public int? ArtistaId { get; set; }

    // Com proxies as classes que se relacionam deve ser virtuais
    public virtual Artista? Artista { get; set; }
    // Uma Musica pode ter muitos generos 
    public virtual ICollection<Genero> Generos { get; set; }


    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");     
    }

    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Nome}";
    }
}