using System;

namespace AgendaCompromissoPOO.Modelos;

public class Compromisso
{
  public DateTime Data { get; set; }
  public TimeSpan Hora { get; set; }
  public string Descricao { get; set; } = string.Empty;

  public Usuario usuario { get; set; } = new Usuario();
  public Local local { get; set; } = new Local();

  private readonly List<Participante> _participantes = new();
  public IReadOnlyCollection<Participante> Participantes => _participantes.AsReadOnly();

  private readonly List<Anotacao> _anotacoes = new();
  public IReadOnlyCollection<Anotacao> Anotacoes => _anotacoes.AsReadOnly();

  public Compromisso(DateTime data, TimeSpan hora, string descricao){
    var dataHora = data.Date + hora;

    if (dataHora <=DateTime.Now)
    {
      throw new ArgumentException("A data do compromisso deve ser no futuro.");
    }
    
    if(string.IsNullOrWhiteSpace(descricao)){
      throw new ArgumentException("A descrição do compromisso não pode ser nula.");
    }

    Data = data.Date;
    Hora = hora;
    Descricao = descricao;

    usuario = usuario ?? throw new ArgumentNullException(nameof(usuario), "O usuário não pode ser nulo.");
    local = local ?? throw new ArgumentNullException(nameof(local), "O local não pode ser nulo.");
  }

    public Compromisso()
    {
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
    return $"Compromisso data{Data:dd/MM/yyyy} hora {Hora:hh:mm} - {Descricao}" +
            $"\nusuário: {usuario.NomeCompleto}" +
            $"\nLocal: {local.Nome}" +
            $"\nParticipantes: {string.Join(", ", _participantes.Select(p => p.Nome))}" +
            $"\nAnotações: {_anotacoes.Count}";
  }

}