// See https://aka.ms/new-console-template for more information

class Program
{
    static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args)
    {

        string opcaoUsuario = ObterOpcaoUsuario();

        while (opcaoUsuario != "X")
        {
            switch (opcaoUsuario)
            {
                case "1":
                    ListarSeries();
                    break;
                case "2":
                    InserirSerie();
                    break;
                case "3":
                    AtualizarSerie();
                    break;
                case "4":
                    ExcluirSerie();
                    break;
                case "5":
                    VisualizarSerie();
                    break;
                case "C":
                    Console.Clear();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            opcaoUsuario = ObterOpcaoUsuario();
        }
        Console.WriteLine("Finalizando.");
    }

    private static void ListarSeries()
    {
        Console.WriteLine("Listar séries");
        var lista = repositorio.Lista();
        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhuma série cadastrada.");
            return;
        }
        foreach (var serie in lista)
        {
            if (!serie.Excluido)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.Id, serie.Titulo);
            }
        }
    }

    private static Serie DadosSerie(int id)
    {
        //O método vai ser utilizado para criar a serie e atualizar a serie
        int gen, ano;
        string titulo, descricao;
        bool ok;
        Console.WriteLine("Digite o título da serie :");
        titulo = Console.ReadLine();

        Console.WriteLine("Gêneros:");
        foreach (int item in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0} - {1}", item, Enum.GetName(typeof(Genero), item));
        }
        Console.WriteLine("Digite o gênero da serie conforme a lista acima:");
        do
        {
            ok = Int32.TryParse(Console.ReadLine(), out gen);
            if (!ok)
            {
                Console.WriteLine("O valor precisa ser um número conforme a lista acima:");
            }
        } while (!ok);

        Console.WriteLine("Digite uma breve descrição da serie :");
        descricao = Console.ReadLine();

        Console.WriteLine("Digite o ano da serie :");
        do
        {
            ok = Int32.TryParse(Console.ReadLine(), out ano);
            if (!ok)
            {
                Console.WriteLine("O valor precisa ser um número para o ano da serie:");
            }
        } while (!ok);
        Serie novaSerie = new Serie(id, (Genero)gen, titulo, descricao, ano);
        return novaSerie;
    }
    private static void InserirSerie()
    {
        Console.WriteLine("Inserir série");
        Console.WriteLine("");
        Serie novaSerie = DadosSerie(repositorio.ProximoId());
        repositorio.Insere(novaSerie);
    }

    private static void AtualizarSerie()
    {
        bool ok;
        int id;
        Console.WriteLine("Atualizar série");
        Console.WriteLine("");
        Console.WriteLine("Digite o id da série :");
        do
        {
            ok = Int32.TryParse(Console.ReadLine(), out id);
            if (!ok)
            {
                Console.WriteLine("O valor precisa ser um número para o ID:");
            }
            else
            {
                //o id nao pode ser maior que o tamanho do vetor repositorio 
                if (id >= repositorio.ProximoId())
                {
                    Console.WriteLine("O ID não é válido:");
                    ok = false;
                }
            }
        } while (!ok);

        Serie novosDados = DadosSerie(id);
        repositorio.Atualiza(id, novosDados);
    }

    private static void ExcluirSerie()
    {
        bool ok;
        int id;
        Console.WriteLine("Excluir série");
        Console.WriteLine("");
        Console.WriteLine("Digite o id do série :");
        do
        {
            ok = Int32.TryParse(Console.ReadLine(), out id);
            if (!ok)
            {
                Console.WriteLine("O valor precisa ser um número para o ID:");
            }
            else
            {
                //o id nao pode ser maior que o tamanho do vetor repositorio 
                if (id >= repositorio.ProximoId())
                {
                    Console.WriteLine("O ID não é válido:");
                    ok = false;
                }
            }
        } while (!ok);

        Console.WriteLine(repositorio.RetornaPorId(id));

        Console.WriteLine("Deseja mesmo excluir a série acima: (S/N)");
        String confirma = Console.ReadLine().ToUpper();
        if (String.Equals(confirma.ToString(), "S"))
        {
            repositorio.Exclui(id);
            Console.WriteLine("Série excluida.");
        }
        else
        {
            Console.WriteLine("Operação cancelada");
        }

    }

    private static void VisualizarSerie()
    {
        bool ok;
        int id;
        Console.WriteLine("Visualizar série");
        Console.WriteLine("");
        Console.WriteLine("Digite o id do série :");
        do
        {
            ok = Int32.TryParse(Console.ReadLine(), out id);
            if (!ok)
            {
                Console.WriteLine("O valor precisa ser um número para o ID:");
            }
            else
            {
                //o id nao pode ser maior que o tamanho do vetor repositorio 
                if (id >= repositorio.ProximoId())
                {
                    Console.WriteLine("O ID não é válido:");
                    ok = false;
                }
            }
        } while (!ok);
        Console.WriteLine(repositorio.RetornaPorId(id));
    }

    private static string ObterOpcaoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("Series DIO");
        Console.WriteLine("Informe a opção desejada:");

        Console.WriteLine("1 - Listar séries");
        Console.WriteLine("2 - Inserir nova série");
        Console.WriteLine("3 - Atualizar série");
        Console.WriteLine("4 - Excluir série");
        Console.WriteLine("5 - Visualizar série");
        Console.WriteLine("C - Limpar Tela");
        Console.WriteLine("X - Sair");
        Console.WriteLine();

        String opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;
    }
}

