using DIO.Series.Classes;

namespace DIO.Series
{

    class Program
    {
        private static SerieRepository seriesRepository = new SerieRepository();

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
                RedirectMenuOption(menuOption);
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

        private static void RedirectMenuOption(string option)
        {
            if (option == null)
                option = "0";

            if (int.TryParse(option, out int parsedOption))
            {
                switch (parsedOption)
                {
                    case (int)MenuOption.ListarSeries:
                        ListSeries();
                        break;

                    case (int)MenuOption.InserirSerie:
                        InsertSeries();
                        break;

                    case (int)MenuOption.ModificarSerie:
                        ModifySeriesDescription();
                        break;

                    case (int)MenuOption.RemoverSerie:
                        EraseSeries();
                        break;

                    case 5:
                        GetSeriesInfo();
                        break;

                    case 6:
                        Console.Clear();
                        return;

                    default:
                        InvalidInput();
                        break;
                }
            }
            else
            {
                InvalidInput();
            }

        }

        private static void ListSeries()
        {
            Console.Clear();
            Dictionary<Guid, Serie> dictionary = seriesRepository.Dictionary();
            if (dictionary.Count == 0)
            {
                Console.WriteLine("Nenhuma Série Cadastrada");
                EndQuery();
                return;
            }

            foreach (KeyValuePair<Guid, Serie> serie in dictionary)
            {
                Console.WriteLine($"Série: {serie.Value.Title}{Environment.NewLine}CODE: {serie.Value.GetID()}{Environment.NewLine}");
            }
            EndQuery();
        }

        private static void InsertSeries()
        {
            Console.Clear();
            Genero genero;
            Console.WriteLine("Escolha o Gênero da Série:");
            for (int i = 1; i < 15; i++)
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");

            if (int.TryParse(Console.ReadLine(), out int inputGenero))
            {
                if (inputGenero > 0 && inputGenero < 15)
                {
                    genero = (Genero)inputGenero;
                }
                else
                {
                    InvalidInput();
                    return;
                }
            }
            else
            {
                InvalidInput();
                return;
            }


            string titulo;
            Console.Clear();
            Console.WriteLine("Insira o Título da Série:");
            titulo = Console.ReadLine().Trim();
            if (titulo == null)
            {
                InvalidInput();
                return;
            }

            string descricao;
            Console.Clear();
            Console.WriteLine("Insira uma Descrição para a Série:");
            descricao = Console.ReadLine().Trim();
            if (descricao == null)
            {
                InvalidInput();
                return;
            }

            int ano;
            Console.Clear();
            Console.WriteLine("Insira o Ano de Lançamento da Série:");
            if (!int.TryParse(Console.ReadLine(), out ano))
            {
                InvalidInput();
                return;
            }

            Serie serie = new Serie(genero, titulo, descricao, ano);
            seriesRepository.Insert(serie);
            EndQuery();
        }

        private static void ModifySeriesDescription()
        {
            Console.Clear();
            Console.WriteLine("Digite o código ou título da série que deseja modificar");
            string input = Console.ReadLine();

            if (CheckID(input, out Serie serie))
            {
                Console.WriteLine("Digite a Nova Descrição Para a Série:");
                string descricao = Console.ReadLine();
                if (descricao != null)
                {
                    serie.Description = descricao;
                }
                else
                {
                    InvalidInput();
                    return;
                }
            }
            EndQuery();

        }

        private static void EraseSeries()
        {
            Console.Clear();
            Console.WriteLine("Insira o Nome ou Código da Série a Ser Excluída:");
            string input = Console.ReadLine();
            if (CheckID(input, out Serie serie))
            {
                serie.Excluir();
            }
            else
            {
                InvalidInput();
                return;
            }
            EndQuery();
        }

        private static void GetSeriesInfo()
        {
            Console.Clear();
            Console.WriteLine("Insira o Nome ou Código da Série a Ser Exibida:");
            string input = Console.ReadLine();
            if (CheckID(input, out Serie serie))
            {
                Console.WriteLine(serie.ToString());
            }
            else
            {
                InvalidInput();
                return;
            }
            EndQuery();
        }

        private static bool CheckID(string input, out Serie serie)
        {
            if (input == null)
            {
                InvalidInput();
                serie = null;
                return false;
            }

            Dictionary<Guid, Serie> dictionary = seriesRepository.Dictionary();

            foreach (KeyValuePair<Guid, Serie> entry in dictionary)
            {
                if (input.Trim() == entry.Value.GetID().Trim() || input.Trim() == entry.Value.Title.Trim())
                {
                    serie = entry.Value;
                    return true;
                }
            }

            Console.WriteLine("Série não encontrada. Procure pelo código ou título da série na lista de séries.");
            serie = null;
            return false;
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
