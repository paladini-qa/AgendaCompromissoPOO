using System;

namespace AgendaCompromissoPOO.Modelos;

public class Anotacao
{
    public string TextoAnotacao { get; set; } = string.Empty;
    public DateTime DataCriacao { get; } = DateTime.Now;

    public Anotacao(string textoAnotacao)
    {
        TextoAnotacao = textoAnotacao;
        DataCriacao = DateTime.Now;
    }

}
