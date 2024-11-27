using ScreenSound.Models;

namespace ScreenSound.Interfaces;

internal interface IAvaliavel
{
    public void AdicionarNota(Avaliacao nota);
    public double Media { get; }
}
