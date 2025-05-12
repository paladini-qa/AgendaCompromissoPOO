using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaCompromissoPOO.Modelos;

public class Usuario
{
  public string? NomeCompleto { get; set; }

  private readonly List<Compromisso> _compromissos = new();

  public IReadOnlyCollection<Compromisso> Compromissos => _compromissos.AsReadOnly();

  public Usuario(string nomeCompleto)
  {
    if (string.IsNullOrWhiteSpace(nomeCompleto))
    {
      throw new ArgumentException("O nome do usuário não pode estar vazio.", nameof(nomeCompleto));
    }

    NomeCompleto = nomeCompleto;
  }

  public void AdicionarCompromisso(Compromisso compromisso)
  {
    if (compromisso == null)
    {
      throw new ArgumentNullException(nameof(compromisso), "O compromisso não pode ser nulo.");
    }

    // Verifica se já existe um compromisso na mesma data E na mesma hora
    if (_compromissos.Any(c => c.Data.Date == compromisso.Data.Date && c.Hora == compromisso.Hora))
    {
      throw new InvalidOperationException("Já existe um compromisso agendado para esta data e hora.");
    }

    _compromissos.Add(compromisso);
  }
}
