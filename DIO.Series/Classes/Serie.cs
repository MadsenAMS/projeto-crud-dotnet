using System;

namespace DIO.Series.Classes
{
    public class Serie : BaseEntity
    {
        public Genero Genre { get; private set; }
        public string Title { get; private set; }
        public string Description { get; set; }
        public int Year { get; private set; }

        public bool Excluded { get; private set; }

        public Serie(Genero genre, string title, string description, int year)
        {
            this.Id = Guid.NewGuid();
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Excluded = false;
        }

        public override string ToString()
        {
            string output = $"{Environment.NewLine}";
            output += $"Titulo: {Title}{Environment.NewLine}";
            output += $"Genero: {Genre}{Environment.NewLine}";
            output += $"Descricao: {Description}{Environment.NewLine}";
            output += $"Ano: {Year}{Environment.NewLine}";

            return output;
        }

        public string GetTitulo()
        {
            return this.Title;
        }

        public string GetID()
        {
            return this.Id.ToString();
        }

        public void Excluir()
        {
            Excluded = true;
        }

    }
}