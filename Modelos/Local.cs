using System;

namespace AgendaCompromissoPOO.Modelos;

public class Local
{
  public string Nome { get; set; } = string.Empty;
  public int CapacidadeMaxima { get; set; }

  public Local(string nome, int capacidadeMaxima)
  {
    if (string.IsNullOrWhiteSpace(nome))
    {
      throw new ArgumentException("O nome do local não pode estar vazio.", nameof(nome));
    }

    if (capacidadeMaxima <= 0)
    {
      throw new ArgumentException("A capacidade máxima deve ser maior que zero.", nameof(capacidadeMaxima));
    }

    Nome = nome;
    CapacidadeMaxima = capacidadeMaxima;
  }
  public Local()
  {
  }

  public void ValidarCapacidade(int quantidade)
  {
    if (quantidade > CapacidadeMaxima)
    {
      throw new InvalidOperationException("A quantidade de pessoas excede a capacidade máxima do local.");
    }
  }

  private readonly List<Compromisso> _compromissos = new();
  public IReadOnlyCollection<Compromisso> Compromissos => _compromissos.AsReadOnly();

  public void AdicionarCompromisso(Compromisso compromisso)
  {
    if (compromisso == null)
    {
      throw new ArgumentNullException(nameof(compromisso), "O compromisso não pode ser nulo.");
    }

    _compromissos.Add(compromisso);
  }
}
