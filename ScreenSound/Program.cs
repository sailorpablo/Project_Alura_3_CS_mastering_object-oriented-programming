using ScreenSound.Modelos;
using ScreenSound.Menus;
using OpenAI;
using OpenAI.Chat;
using System.ClientModel;
//sk-proj-oOeLVsQe7Q9k7VI4curnlG95D6nIe4fOtxr-tgnI8rmffmbnkrvzRLcrij__rXeAHQ20mKFEv3T3BlbkFJewj_IaxqlX9nJVn8o_AUaH51PkfVj3EsjuQ1PIGSNIGeSD8JGO8UCafoeOfaOyMOJoS-tFMw

internal class Program
{
    private static void Main(string[] args)
    {

        OpenAIClient client = new OpenAIClient("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");

        var openAiResponse =  client.GetChatClient("gpt-3.5-turbo");

        ChatCompletion completion = openAiResponse.CompleteChat(

                new UserChatMessage("Pode me ajudar?")

            );

        Console.WriteLine($"{completion.Role}: {completion.Content[0].Text}");

        Banda ira = new Banda("Ira!");
        ira.AdicionarNota(new Avaliacao(10));
        ira.AdicionarNota(new Avaliacao(8));
        ira.AdicionarNota(new Avaliacao(6));

        Banda beatles = new Banda("The Beatles!");


        Dictionary<int, Menu> opcoesMenu = new Dictionary<int, Menu>();
        opcoesMenu.Add(1, new MenuRegistrarBanda());
        opcoesMenu.Add(2, new MenuRegistrarAlbum());
        opcoesMenu.Add(3, new MenuBandasRegistradas());
        opcoesMenu.Add(4, new MenuAvaliarBanda());
        opcoesMenu.Add(5, new MenuExibirDetalhes());
        opcoesMenu.Add(6, new MenuAvaliarAlbum());
        opcoesMenu.Add(-1, new MenuSair());



        Dictionary<string, Banda> bandasRegistradas = new();

        bandasRegistradas.Add(ira.Nome, ira);
        bandasRegistradas.Add(beatles.Nome, beatles);

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
            Console.WriteLine("Digite 5 para exibir os detalhes de uma banda");
            Console.WriteLine("Digite 6 para avaliar um album");
            Console.WriteLine("Digite -1 para sair");

            Console.Write("\nDigite a sua opção: ");
            string opcaoEscolhida = Console.ReadLine()!;
            int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

            if (opcoesMenu.ContainsKey(opcaoEscolhidaNumerica))
            {
                Menu menuExibido = opcoesMenu[opcaoEscolhidaNumerica];
                menuExibido.Executar(bandasRegistradas);
                
                ExibirOpcoesDoMenu();

            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }

            
          

        }

        //ExibirOpcoesDoMenu();
    }
}