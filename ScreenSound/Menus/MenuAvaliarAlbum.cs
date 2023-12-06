using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuAvaliarAlbum : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Avaliar album");
        Console.Write("Digite o nome do album que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];

            Console.Write("Agora digite o título do álbum: ");
            string tituloAlbum = Console.ReadLine()!;

            if(banda.Albuns.Any(album=>album.Nome.Equals(tituloAlbum)))
            {
                Album album = banda.Albuns.First(album => album.Nome.Equals(tituloAlbum));
                Console.Write($"Qual a nota que o album {tituloAlbum} merece: ");
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
                album.AdicionarNota(nota);
                Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para o album {tituloAlbum} da banda {nomeDaBanda}");
                Thread.Sleep(2000);
                Console.Clear();

            }
            else
            {
                
                Console.WriteLine($"\nO album {tituloAlbum} não foi encontrada!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                
            }

        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
