using DIO.Series.Classes;

namespace DIO.Series
{

    class Program
    {

        public static void Main()
        {

            Serie serie = new Serie(Genero.Acao, "Red Alert", "Um policial e um ladrão...", 2021);

            Console.WriteLine(serie.ToString());

        }

    }

}