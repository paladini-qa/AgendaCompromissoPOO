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

// FALTA CADASTRAR O COMPROMISSO

// FALTA VALIDAR A QUANTIDADE DE PARTICIPANTES NO LOCAL

// FALTA EXIBIR TODOS OS COMPROMISSOS DO USUÁRIO