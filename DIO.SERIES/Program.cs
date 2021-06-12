using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {            
            String opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
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

            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
            
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");
            var Lista = repositorio.Lista();

            if(Lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada");
                return;
            }

            foreach (var serie in Lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : "" ));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Serie");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano do inicio da Serie");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Série");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         ano: entradaAno,
                                         descricao: entradaDescricao);

            repositorio.Insere(novaSerie);

        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Serie");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano do inicio da Serie");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Série");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         ano: entradaAno,
                                         descricao: entradaDescricao);
            
            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);

        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornoPorId(indiceSerie);

            Console.WriteLine(serie);

        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Serie a seu dispor!");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;

        }
    }
}
