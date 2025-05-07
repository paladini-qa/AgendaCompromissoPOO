using System;
using System.Collections.Generic;

namespace AgendaCompromissoPOO.Modelos 
{
    public class Participante
    {
        public string Nome { get; private set; }
        private List<Compromisso> compromissos;
        public IReadOnlyCollection<Compromisso> Compromissos => compromissos.AsReadOnly();
        public Participante(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("o nome do participante e obrigatorio");

            Nome = nome;
            compromissos = new List<Compromisso>();
        }
        public void AdicionarCompromisso(Compromisso compromisso)
        {
            if (compromisso == null)
                throw new ArgumentNullException(nameof(compromisso));

            if (!compromissos.Contains(compromisso))
            {
                compromissos.Add(compromisso);
                compromisso.AdicionarParticipante(this); 
            }
        }
                public override string ToString()
        {
            return Nome;
        }
    }
}