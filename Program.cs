using AgendaCompromissoPOO.Modelos;

Console.WriteLine("\nPor favor, digite o nome do usuário para cadastro:");
string nome = Console.ReadLine()!;
while (string.IsNullOrEmpty(nome))
{
    Console.WriteLine("\nO nome do usuário não pode estar vazio. Por favor, digite novamente:");
    nome = Console.ReadLine()!;
}

Usuario usuario;
try
{
    usuario = new Usuario(nome);
    Console.WriteLine($"\nUsuário '{usuario.NomeCompleto}' foi criado com sucesso!");
}
catch (Exception ex)
{
    Console.WriteLine($"\nErro ao criar o usuário: {ex.Message}");
    usuario = new Usuario(nome);
    Console.WriteLine($"\nUsuário '{usuario.NomeCompleto}' foi criado com sucesso usando método alternativo!");
}

Console.WriteLine("\nAgora, digite o nome do local para cadastro:");
string nomeLocal = Console.ReadLine()!;
while (string.IsNullOrEmpty(nomeLocal))
{
    Console.WriteLine("\nO nome do local não pode estar vazio. Por favor, digite novamente:");
    nomeLocal = Console.ReadLine()!;
}
Console.WriteLine("\nDigite a capacidade máxima do local (apenas números inteiros positivos):");
string capacidadeMaximaStr = Console.ReadLine()!;
int capacidadeMaxima;
while (!int.TryParse(capacidadeMaximaStr, out capacidadeMaxima) || capacidadeMaxima <= 0)
{
    Console.WriteLine("\nValor inválido para capacidade máxima. Por favor, digite um número inteiro positivo:");
    capacidadeMaximaStr = Console.ReadLine()!;
}
Local local;
try
{
    local = new Local(nomeLocal, capacidadeMaxima);
    Console.WriteLine($"\nLocal '{local.Nome}' com capacidade máxima de {local.CapacidadeMaxima} pessoas foi criado com sucesso!");
}
catch (Exception ex)
{
    Console.WriteLine($"\nErro ao criar o local: {ex.Message}");
    local = new Local
    {
        Nome = nomeLocal,
        CapacidadeMaxima = capacidadeMaxima
    };
    Console.WriteLine($"\nLocal '{local.Nome}' com capacidade máxima de {local.CapacidadeMaxima} pessoas foi criado com sucesso usando método alternativo!");
}

Console.WriteLine("\nVamos cadastrar um compromisso! Por favor, siga as instruções abaixo.");

Console.WriteLine("\nDigite a descrição do compromisso:");
string descricaoCompromisso = Console.ReadLine()!;
while (string.IsNullOrEmpty(descricaoCompromisso))
{
    Console.WriteLine("\nA descrição do compromisso não pode estar vazia. Por favor, digite novamente:");
    descricaoCompromisso = Console.ReadLine()!;
}

Console.WriteLine("\nDigite a data do compromisso no formato 'dd/MM/yyyy':");
string dataCompromissoStr = Console.ReadLine()!;
DateTime dataCompromisso;
while (!DateTime.TryParseExact(dataCompromissoStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataCompromisso))
{
    Console.WriteLine("\nFormato de data inválido. Por favor, digite novamente no formato 'dd/MM/yyyy':");
    dataCompromissoStr = Console.ReadLine()!;
}
while (dataCompromisso < DateTime.Now.Date)
{
    Console.WriteLine("\nA data do compromisso não pode ser anterior à data atual. Por favor, digite novamente:");
    dataCompromissoStr = Console.ReadLine()!;
    DateTime.TryParseExact(dataCompromissoStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataCompromisso);
}
bool eHoje = dataCompromisso.Date == DateTime.Now.Date;

Console.WriteLine("\nDigite a hora do compromisso no formato 'HH:mm':");
string horaCompromissoStr = Console.ReadLine()!;
TimeSpan horaCompromisso;
while (!TimeSpan.TryParse(horaCompromissoStr, out horaCompromisso))
{
    Console.WriteLine("\nFormato de hora inválido. Por favor, digite novamente no formato 'HH:mm':");
    horaCompromissoStr = Console.ReadLine()!;
}
while (eHoje && horaCompromisso < DateTime.Now.TimeOfDay)
{
    Console.WriteLine("\nA hora do compromisso não pode ser anterior à hora atual. Por favor, digite novamente:");
    horaCompromissoStr = Console.ReadLine()!;
    if (!TimeSpan.TryParse(horaCompromissoStr, out horaCompromisso))
    {
        Console.WriteLine("\nFormato de hora inválido. Por favor, digite novamente:");
    }
}

Console.WriteLine("\nDigite o nome do local onde o compromisso será realizado:");
string localCompromisso = Console.ReadLine()!;
while (string.IsNullOrEmpty(localCompromisso))
{
    Console.WriteLine("\nO nome do local do compromisso não pode estar vazio. Por favor, digite novamente:");
    localCompromisso = Console.ReadLine()!;
}
while (localCompromisso != nomeLocal)
{
    Console.WriteLine($"\nErro: O local do compromisso ('{localCompromisso}') não corresponde ao local cadastrado ('{nomeLocal}').");
    Console.WriteLine("\nPor favor, digite novamente o nome do local do compromisso:");
    localCompromisso = Console.ReadLine()!;
}
try
{
    Console.WriteLine($"\nLocal do compromisso confirmado: '{localCompromisso}'.");
}
catch (Exception ex)
{
    Console.WriteLine($"\nErro ao confirmar o local do compromisso: {ex.Message}");
}

Compromisso? compromisso = null;
try
{
    compromisso = new Compromisso(dataCompromisso, horaCompromisso, descricaoCompromisso);
    compromisso.usuario = usuario;
    compromisso.local = local;
    local.AdicionarCompromisso(compromisso);
    Console.WriteLine($"\nCompromisso criado com data {dataCompromisso:dd/MM/yyyy} às {horaCompromisso:hh\\:mm}.");
}
catch (Exception ex)
{
    Console.WriteLine($"\nErro ao criar o compromisso: {ex.Message}");
    return;
}

Console.WriteLine("\nDeseja adicionar participantes ao compromisso? Digite 's' para sim ou 'n' para não:");
string resposta = Console.ReadLine()!;
int quantidadeParticipantes = 0;

while (resposta.ToLower() != "n")
{
    if (quantidadeParticipantes >= capacidadeMaxima)
    {
        Console.WriteLine("\nErro: A quantidade de participantes excede a capacidade máxima do local. Nenhum participante adicional pode ser adicionado.");
        break;
    }

    while (resposta.ToLower() != "s" && resposta.ToLower() != "n")
    {
        Console.WriteLine("\nResposta inválida. Por favor, digite 's' para sim ou 'n' para não:");
        resposta = Console.ReadLine()!;
    }

    if (resposta.ToLower() == "s")
    {
        Console.WriteLine("\nDigite o nome do participante para adicionar ao compromisso:");
        string nomeParticipante = Console.ReadLine()!;
        while (string.IsNullOrEmpty(nomeParticipante))
        {
            Console.WriteLine("\nO nome do participante não pode estar vazio. Por favor, digite novamente:");
            nomeParticipante = Console.ReadLine()!;
        }

        try
        {
            Participante participante = new(nomeParticipante);
            compromisso.AdicionarParticipante(participante);
            participante.AdicionarCompromisso(compromisso);
            quantidadeParticipantes++;
            Console.WriteLine($"\nParticipante '{participante.Nome}' foi adicionado com sucesso! Total de participantes: {quantidadeParticipantes}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro ao adicionar o participante: {ex.Message}");
        }

        if (quantidadeParticipantes < capacidadeMaxima)
        {
            Console.WriteLine("\nDeseja adicionar outro participante? Digite 's' para sim ou 'n' para não:");
            resposta = Console.ReadLine()!;
        }
        else
        {
            Console.WriteLine("\nA capacidade máxima do local foi atingida. Não é possível adicionar mais participantes.");
            break;
        }
    }
    else
    {
        Console.WriteLine("\nNenhum participante foi adicionado ao compromisso.");
        break;
    }
}

Console.WriteLine("\nDeseja adicionar uma anotação ao compromisso? Digite 's' para sim ou 'n' para não:");
resposta = Console.ReadLine()!;
while (resposta.ToLower() != "s" && resposta.ToLower() != "n")
{
    Console.WriteLine("\nResposta inválida. Por favor, digite 's' para sim ou 'n' para não:");
    resposta = Console.ReadLine()!;
}
if (resposta.ToLower() == "s")
{
    Console.WriteLine("\nDigite o texto da anotação:");
    string textoAnotacao = Console.ReadLine()!;
    while (string.IsNullOrEmpty(textoAnotacao))
    {
        Console.WriteLine("\nO texto da anotação não pode estar vazio. Por favor, digite novamente:");
        textoAnotacao = Console.ReadLine()!;
    }
    try
    {
        compromisso.AdicionarAnotacao(textoAnotacao);
        Console.WriteLine($"\nAnotação '{textoAnotacao}' foi adicionada com sucesso ao compromisso!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nErro ao adicionar a anotação: {ex.Message}");
    }
}
else
{
    Console.WriteLine("\nNenhuma anotação foi adicionada ao compromisso.");
}

try
{
    usuario.AdicionarCompromisso(compromisso);
    Console.WriteLine("\nCompromisso cadastrado com sucesso na agenda do usuário!");

    Console.WriteLine("\n--- RESUMO DO COMPROMISSO ---");
    Console.WriteLine(compromisso.ToString());
}
catch (Exception ex)
{
    Console.WriteLine($"\nErro ao adicionar o compromisso à agenda do usuário: {ex.Message}");
}
