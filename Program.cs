using AgendaCompromissoPOO.Modelos;

Console.WriteLine("Digite o nome do Usuario:");
string nome = Console.ReadLine()!;
while (string.IsNullOrEmpty(nome))
{
  Console.WriteLine("Nome inválido, digite novamente:");
  nome = Console.ReadLine()!;
}
try
{
  Usuario usuario = new()
  {
    NomeCompleto = nome
  };
  Console.WriteLine($"Usuario {usuario.NomeCompleto} criado com sucesso!");
}
catch (Exception ex)
{
  Console.WriteLine($"Erro: {ex.Message}");
}
