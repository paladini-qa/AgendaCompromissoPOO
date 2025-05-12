using System;

namespace AgendaCompromissoPOO.Modelos;

public class Compromisso
{
  public DateTime Data { get; set; }
  public TimeSpan Hora { get; set; }
  public string Descricao { get; set; } = string.Empty;

  public Usuario usuario { get; set; } = new Usuario("Nome Padrão");
  public Local local { get; set; } = new Local("Local Padrão", 10);

  private readonly List<Participante> _participantes = new();
  public IReadOnlyCollection<Participante> Participantes => _participantes.AsReadOnly();

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

    usuario = usuario ?? throw new ArgumentNullException(nameof(usuario), "O usuário não pode ser nulo.");
    local = local ?? throw new ArgumentNullException(nameof(local), "O local não pode ser nulo.");
  }

  public void AdicionarAnotacao(string textoAnotacao)
  {
    if (string.IsNullOrWhiteSpace(textoAnotacao))
    {
      throw new ArgumentException("O texto da anotação não pode ser nulo.");
    }

    _anotacoes.Add(new Anotacao(textoAnotacao));
  }

  public void AdicionarParticipante(Participante participante)
  {
    if (_participantes.Contains(participante))
    {
      return;
    }
    _participantes.Add(participante);
  }

  public override string ToString()
  {
    var participantes = _participantes.Any() ? string.Join(", ", _participantes.Select(p => p.Nome)) : "Nenhum";
    var anotacoes = _anotacoes.Any() ? string.Join("; ", _anotacoes.Select(a => a.TextoAnotacao)) : "Nenhuma";

    return $"Compromisso dia {Data:dd/MM/yyyy} às {Hora:hh\\:mm} horas - {Descricao}" +
            $"\nUsuário: {usuario?.NomeCompleto ?? "Não informado"}" +
            $"\nLocal: {local?.Nome ?? "Não informado"}" +
            $"\nParticipantes: {participantes}" +
            $"\nAnotações: {anotacoes}";
  }

}