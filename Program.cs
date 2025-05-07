using AgendaCompromissoPOO.Modelos;

Console.WriteLine("\nDigite o nome do Usuario:");
string nome = Console.ReadLine()!;
while (string.IsNullOrEmpty(nome))
{
  Console.WriteLine("\nNome inválido, digite novamente:");
  nome = Console.ReadLine()!;
}
try
{
  Usuario usuario = new()
  {
    NomeCompleto = nome
  };
  Console.WriteLine($"\nUsuario {usuario.NomeCompleto} criado com sucesso!");
}
catch (Exception ex)
{
  Console.WriteLine($"\nErro: {ex.Message}");
}

Console.WriteLine("\nDigite o nome do local:");
string nomeLocal = Console.ReadLine()!;
while (string.IsNullOrEmpty(nomeLocal))
{
  Console.WriteLine("\nNome do local inválido, digite novamente:");
  nomeLocal = Console.ReadLine()!;
}
Console.WriteLine("\nDigite a capacidade máxima do local:");
string capacidadeMaximaStr = Console.ReadLine()!;
int capacidadeMaxima;
while (!int.TryParse(capacidadeMaximaStr, out capacidadeMaxima) || capacidadeMaxima <= 0)
{
  Console.WriteLine("\nCapacidade inválida, digite novamente:");
  capacidadeMaximaStr = Console.ReadLine()!;
}
while (capacidadeMaxima <= 0)
{
  Console.WriteLine("\nCapacidade inválida, digite novamente:");
  capacidadeMaximaStr = Console.ReadLine()!;
  int.TryParse(capacidadeMaximaStr, out capacidadeMaxima);
}
capacidadeMaxima = Math.Max(capacidadeMaxima, 1);
try
{
  Local local = new()
  {
    Nome = nomeLocal,
    CapacidadeMaxima = capacidadeMaxima
  };
  Console.WriteLine($"\nLocal {local.Nome} com capacidade {local.CapacidadeMaxima} criado com sucesso!");
}
catch (Exception ex)
{
  Console.WriteLine($"\nErro: {ex.Message}");
}

Console.WriteLine("\nVamos cadastrar um compromisso!");

// FALTA CADASTRAR DATA, HORA, DESCRICAO E ANOTAÇÕES DO COMPROMISSO

Console.WriteLine("\nDigite o nome do local do compromisso:");
string localCompromisso = Console.ReadLine()!;
while (string.IsNullOrEmpty(localCompromisso))
{
  Console.WriteLine("\nLocal inválido, digite novamente:");
  localCompromisso = Console.ReadLine()!;
}
while (localCompromisso != nomeLocal)
{
  Console.WriteLine("\nErro: O local do compromisso não corresponde ao local cadastrado.");
  Console.WriteLine("\nDigite o nome do local do compromisso:");
  localCompromisso = Console.ReadLine()!;
}
try
{
  Console.WriteLine($"\nLocal do compromisso confirmado: {localCompromisso}");
}
catch (Exception ex)
{
  Console.WriteLine($"\nErro: {ex.Message}");
}

Console.WriteLine("\nQuer adicionar participantes ao compromisso? (s/n)");
string resposta = Console.ReadLine()!;
int quantidadeParticipantes = 0;
if (quantidadeParticipantes >= capacidadeMaxima)
{
  Console.WriteLine("\nErro: A quantidade de participantes excede a capacidade máxima do local.");
  Console.WriteLine("\nNenhum participante adicionado ao compromisso.");
}
else
{
  while (resposta.ToLower() != "s" && resposta.ToLower() != "n")
  {
    Console.WriteLine("\nResposta inválida, digite 's' para sim ou 'n' para não:");
    resposta = Console.ReadLine()!;
  }
  if (resposta.ToLower() == "s")
  {
    Console.WriteLine("\nDigite o nome do participante:");
    string nomeParticipante = Console.ReadLine()!;
    while (string.IsNullOrEmpty(nomeParticipante))
    {
      Console.WriteLine("\nNome do participante inválido, digite novamente:");
      nomeParticipante = Console.ReadLine()!;
    }
    try
    {
      Participante participante = new(nomeParticipante);
      quantidadeParticipantes++;
      //participante.AdicionarCompromisso(compromisso);
      Console.WriteLine($"\nParticipante {participante.Nome} adicionado com sucesso! Total de participantes: {quantidadeParticipantes}.");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"\nErro: {ex.Message}");
    }
  }
  else
  {
    Console.WriteLine("\nNenhum participante adicionado ao compromisso.");
  }
}

// FALTA EXIBIR TODOS OS COMPROMISSOS DO USUÁRIO