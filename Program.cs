using System;

namespace ProjectLogSeries
{
    class Program
    {
        static SerieRepositorio Repo = new SerieRepositorio();
        static void Main(string[] args)
        {
            string Selecao = Menu();
            while (Selecao != "Q")
            {
                switch(Selecao)
                {
                    case "1":
                        Inserir();
                        break;
                    case "2":
                        Remover();
                        break;
                    case "3":
                        Listar();
                        break;
                    case "4":
                        Atualizar();
                        break;
                    case "5":
                        Visualizar();
                        break;
                    case "6":
                        Lixeira();
                        break;
                    case "7":
                        Restaura();
                        break;
                    case "8":
                        Filtra();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Selecione uma opção válida!");
                        break;
                }
                Selecao = Menu();
            }
        }
        private static string Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("[1] - Inserir uma série à lista");
            Console.WriteLine("[2] - Remover uma série da lista");
            Console.WriteLine("[3] - Visualizar a lista de séries atual");
            Console.WriteLine("[4] - Atualizar lista");
            Console.WriteLine("[5] - Visualizar uma série específica");
            Console.WriteLine("[6] - Listar a lixeira");
            Console.WriteLine("[7] - Restaura uma série da lixeira");
            Console.WriteLine("[8] - Filtras séries por gênero");
            Console.WriteLine();
            Console.WriteLine("[C] - Limpar a tela");
            Console.WriteLine("[Q] - Sair");
            string Selecao = Console.ReadLine().ToUpper();
            return Selecao;
        }
        private static void Inserir()
        {
            Console.WriteLine("Digite o título da série:");
            string title = Console.ReadLine();
            Console.WriteLine("Digite o ano da série:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a descrição da série:");
            string sinopse = Console.ReadLine();
            Console.WriteLine("Digite o gênero dentre as opções:");
            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
            int genre = int.Parse(Console.ReadLine());
            Series Serie = new Series(titulo : title, descricao : sinopse, 
                                        genero : (Genero)genre, ano : year, 
                                        id : Repo.ProximoId());
            Repo.Insere(Serie);
        }
        private static void Remover()
        {
            Console.Write("Digite o ID da série:");
            int IndiceSerie = int.Parse(Console.ReadLine());
            Repo.Exclui(IndiceSerie);
        }
        private static void Atualizar()
        {
            Console.Write("Digite o ID da série: ");
			int IndiceSerie = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Series atualizaSerie = new Series(id: IndiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			Repo.Atualiza(IndiceSerie, atualizaSerie);
        }
        private static void Listar()
        {
            Console.WriteLine("Listando Séries...");
            var lista = Repo.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                if (excluido != true) 
                { 
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo()); 
                }
			}
        }

        private static void Visualizar()
		{
			Console.Write("Digite o ID da série: ");
			int IndiceSerie = int.Parse(Console.ReadLine());

			var Serie = Repo.RetornaPorId(IndiceSerie);
            Console.WriteLine();
            Console.WriteLine("######## Série ID {0} ########", IndiceSerie);
			Console.WriteLine(Serie);
		}

        private static void Lixeira()
        {
            var Lista = Repo.Lista();

            foreach(var serie in Lista)
            {
                var excluido = serie.retornaExcluido();
                if (excluido == true)
                {
                    Console.WriteLine("---------------Lixeira---------------");
                    Console.WriteLine("| #ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                    Console.WriteLine("-------------------------------------");
                }
            }
        }

        private static void Restaura()
        {
            var Lista = Repo.Lista();

            foreach(var series in Lista)
            {
                var excluido = series.retornaExcluido();
                if (excluido == true)
                {
                    Console.WriteLine("---------------Lixeira---------------");
                    Console.WriteLine("| #ID {0}: - {1}", series.retornaId(), series.retornaTitulo());
                    Console.WriteLine("-------------------------------------");
                }
            }

            Console.Write("Digite o ID da série que deseja restaurar: ");
            var ID = int.Parse(Console.ReadLine());

            Repo.Restaura(ID);

        }

        private static void Filtra()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

            Console.Write("Digite o nome do gênero que pretende filtrar: ");
            string genre = Console.ReadLine();

            var Lista = Repo.Lista();

            foreach(var series in Lista)
            {
                var genretype = series.retornaGenero().ToString();
                if (genretype == genre) 
                { 
                    Console.WriteLine("| #ID {0}: - {1}", series.retornaId(), series.retornaTitulo());
                }
            }
        }
    }
}
