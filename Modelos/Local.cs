using System;

namespace AgendaCompromissoPOO.Modelos;

public class Local
{
  public string Nome { get; set; } = string.Empty;
  public int CapacidadeMaxima { get; set; }

  public void ValidarCapacidade(int quantidade)
  {
    if (quantidade > CapacidadeMaxima)
    {
      throw new InvalidOperationException("A quantidade de pessoas excede a capacidade máxima do local.");
    }
  }

  // Opcional: lista de compromissos realizados no local
  private readonly List<Compromisso> _compromissos = new();
  public IReadOnlyCollection<Compromisso> Compromissos => _compromissos.AsReadOnly();

  public void AdicionarCompromisso(Compromisso compromisso)
  {
    _compromissos.Add(compromisso);
  }
}
