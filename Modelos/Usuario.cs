using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaCompromissoPOO.Modelos;

public class Usuario
{
  public string NomeCompleto { get; set; }

  private readonly List<Compromisso> _compromissos = new();

  public IReadOnlyCollection<Compromisso> Compromissos => _compromissos.AsReadOnly();

  public void AdicionarCompromisso(Compromisso compromisso)
  {
    if (compromisso == null)
    {
      throw new ArgumentNullException(nameof(compromisso), "O compromisso não pode ser nulo.");
    }

    if (_compromissos.Any(c => c.Data == compromisso.Data))
    {
      throw new InvalidOperationException("Já existe um compromisso agendado para esta data e hora.");
    }

    _compromissos.Add(compromisso);
  }
}
