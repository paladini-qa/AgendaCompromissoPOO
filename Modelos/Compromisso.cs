using System;

namespace AgendaCompromissoPOO.Modelos;

public class Compromisso
{
  public DateTime Data { get; set; }
  public TimeSpan Hora { get; set; }
  public string Descricao { get; set; } = string.Empty;

  private readonly List<Anotacao> _anotacoes = new();
  public IReadOnlyCollection<Anotacao> Anotacoes => _anotacoes.AsReadOnly();

  public Compromisso(DateTime data, TimeSpan hora, string descricao)
  {
    var dataHora = data.Date + hora;

    if (dataHora <= DateTime.Now)
    {
      throw new ArgumentException("A data do compromisso deve ser no futuro.");
    }

    if (string.IsNullOrWhiteSpace(descricao))
    {
      throw new ArgumentException("A descrição do compromisso não pode ser nula.");
    }

    Data = data.Date;
    Hora = hora;
    Descricao = descricao;
    // tem que adicionar o usuario
  }

  public void AdicionarAnotacao(string textoAnotacao)
  {
    if (string.IsNullOrWhiteSpace(textoAnotacao))
    {
      throw new ArgumentException("O texto da anotação não pode ser nulo.");
    }

    _anotacoes.Add(new Anotacao(textoAnotacao));
  }

  //Falta adicionar participante

  public override string ToString()
  {
    return $"Compromisso data{Data:dd/MM/yyyy} hora {Hora:hh:mm} - {Descricao}" +
            $"\nDescrição: {Descricao}" +
            $"\nAnotações: {_anotacoes.Count}";
    //Falta implementar a ToSring do local, participantes e usuario
  }

}
