using DIO.Series.Classes;

namespace DIO.Series
{

    class Program
    {
        private static Dictionary<Guid, Serie> SeriesDictionary = new Dictionary<Guid, Serie>();

        enum MenuOption
        {
            ListarSeries = 1,
            InserirSerie = 2,
            ModificarSerie = 3,
            RemoverSerie = 4,
            VisualizarSerie = 5,
            Sair = 6
        }

        public static void Main()
        {
            string menuOption;

            do
            {
                menuOption = RequestMenuOption();
                ManageSeries(menuOption);
            }
            while (int.Parse(menuOption) != (int)MenuOption.Sair);

        }

        private static string RequestMenuOption()
        {
            Console.Clear();
            Console.WriteLine($" =====  // SISTEMA DE CADASTRO // =====");
            Console.WriteLine($"");
            Console.WriteLine($" 1 - Listar Séries");
            Console.WriteLine($" 2 - Inserir Série");
            Console.WriteLine($" 3 - Modificar Série");
            Console.WriteLine($" 4 - Remover Série");
            Console.WriteLine($" 5 - Visualizar Série");
            Console.WriteLine($" 6 - Sair");
            Console.WriteLine($"");
            Console.WriteLine($" ======================================");

            return Console.ReadLine();
        }

        private static void ManageSeries(string option)
        {
            if (option == null)
                option = "0";

            if (int.TryParse(option, out int parsedOption))
            {
                switch (parsedOption)
                {
                    case (int)MenuOption.ListarSeries:
                        Console.Clear();
                        ListarSeries();
                        EndQuery();
                        break;

                    case (int)MenuOption.InserirSerie:
                        Console.Clear();
                        InserirSerie();
                        EndQuery();
                        break;

                    case (int)MenuOption.ModificarSerie:
                        Console.Clear();
                        //ModificarSerie();
                        EndQuery();
                        break;

                    case (int)MenuOption.RemoverSerie:
                        Console.Clear();
                        //ApagarSerie();
                        EndQuery();
                        break;

                    case 5:
                        Console.Clear();
                        //VerSerie();
                        EndQuery();
                        break;

                    case 6:
                        Console.Clear();
                        return;

                    default:

                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção Inválida.");
                EndQuery();
            }

        }

        private static void ListarSeries()
        {
            if (SeriesDictionary.Count == 0)
            {
                Console.WriteLine("Nenhuma Série Cadastrada");
                return;
            }

            foreach (KeyValuePair<Guid, Serie> serie in SeriesDictionary)
            {
                serie.ToString();
            }
        }

        private static void InserirSerie()
        {
            Genero genero = (Genero)5;

            Console.WriteLine("Escolha o Gênero da Série:");
            for (int i = 1; i < 15; i++)
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");


            if (int.TryParse(Console.ReadLine(), out int inputGenero))
                if (inputGenero > 0 && inputGenero < 15)
                    genero = (Genero)inputGenero;
                else
                {
                    InvalidInput();
                    return;
                }

            Console.Clear();
            Console.WriteLine("Insira o Título da Série:");
            string titulo = Console.ReadLine();
            if (titulo == null)
            {
                InvalidInput();
                return;
            }

            Console.Clear();
            Console.WriteLine("Insira uma Descrição para a Série:");
            string descricao = Console.ReadLine();
            if (descricao == null)
            {
                InvalidInput();
                return;
            }

            Console.Clear();
            Console.WriteLine("Insira a Data de Lançamento da Série:");
            if (!int.TryParse(Console.ReadLine(), out int ano)
            {
                InvalidInput();
                return;
            }


            Serie serie = new Serie(genero, titulo, descricao, ano);
        }

        private static void ModificarSerie()
        {
            Console.WriteLine("Digite o código ou título da série que deseja modificar");
            
        }


        private static void InvalidInput()
        {
            Console.Clear();
            Console.WriteLine("Opção Inválida");
            EndQuery();
        }

        private static void EndQuery()
        {
            Console.WriteLine("Aperte Qualquer Tecla Para Retornar");
            Console.ReadLine();
        }
    }
}
