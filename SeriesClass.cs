using System;

namespace ProjectLogSeries
{
    public class Series : EntityList
    {
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private Genero Genero { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Series(string titulo, string descricao, Genero genero, int ano, int id)
        {
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Genero = genero;
            this.Ano = ano;
            this.ID = id;
            this.Excluido = false;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public void Restaurar()
        {
            this.Excluido = false;
        }

        public override string ToString()
        {
            string info = "";
            info += "Título: " + this.Titulo + Environment.NewLine;
            info += "Ano de estreia: " + this.Ano + Environment.NewLine;
            info += "Descrição: " + this.Descricao + Environment.NewLine;
            info += "Genero: " + this.Genero + Environment.NewLine;
            return info;
        }
        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.ID;
		}

        public bool retornaExcluido()
		{
			return this.Excluido;
		}

        public Genero retornaGenero()
		{
			return this.Genero;
		}
    }
}