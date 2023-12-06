using ScreenSound.Menus;
using ScreenSound.Modelos;

internal class Program
{
    private static void Main(string[] args)
    {
        Banda ira = new("Ira!");
        ira.AdicionarNota(new Avaliacao(10));
        ira.AdicionarNota(new Avaliacao(8));
        ira.AdicionarNota(new Avaliacao(6));

        Banda beatles = new("The Beatles");

        Dictionary<int, Menu> opcoes = new()
        {
            { 1, new MenuRegistrarBanda() },
            { 2, new MenuRegistrarAlbum() },
            { 3, new MenuMostrarBandasRegistradas() },
            { 4, new MenuAvaliarBanda() },
            { 5, new MenuAvaliarAlbum() },
            { 6, new MenuExibirDetalhes() },
            { -1, new MenuSair() }
        };

        Dictionary<string, Banda> bandasRegistradas = new()
        {
            { ira.Nome, ira },
            { beatles.Nome, beatles }
        };

        void ExibirLogo()
        {
            Console.WriteLine(@"
                ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
                ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
                ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
                ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
                ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
                ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
                ");
            Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
        }

        void ExibirOpcoesDoMenu()
        {
            ExibirLogo();
            Console.WriteLine("\nDigite 1 para registrar uma banda");
            Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
            Console.WriteLine("Digite 3 para mostrar todas as bandas");
            Console.WriteLine("Digite 4 para avaliar uma banda");
            Console.WriteLine("Digite 5 para avaliar um album");
            Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
            Console.WriteLine("Digite -1 para sair");

            Console.Write("\nDigite a sua opção: ");
            string opcaoEscolhida = Console.ReadLine()!;
            int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

            if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
            {
                Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
                menuASerExibido.Executar(bandasRegistradas);
                if(opcaoEscolhidaNumerica > 0) { ExibirOpcoesDoMenu(); }
            }else
            {
                Console.WriteLine("Opção inválida");
            }
        }

        ExibirOpcoesDoMenu();
    }
}