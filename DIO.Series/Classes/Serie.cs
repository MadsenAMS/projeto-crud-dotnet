using System;

namespace DIO.Series.Classes
{
    public class Serie : BaseEntity
    {
        public Genero Genero { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; set; }
        public int Ano { get; private set; }

        public bool Excluido { get; private set; }

        public Serie(Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = Guid.NewGuid();
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string output = "";
            output += $"ID: {Id}{Environment.NewLine}";
            output += $"Genero: {Genero}{Environment.NewLine}";
            output += $"Titulo: {Titulo}{Environment.NewLine}";
            output += $"Descricao: {Descricao}{Environment.NewLine}";
            output += $"Ano: {Ano}";
            return output;
        }

        public string GetTitulo()
        {
            return this.Titulo;
        }

        public string GetID()
        {
            return this.Id.ToString();
        }

        public void Excluir()
        {
            Excluido = true;
        }

    }
}