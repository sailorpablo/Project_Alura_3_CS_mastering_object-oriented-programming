using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Menus
{
    internal class MenuRegistrarBanda : Menu
    {

        public override void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            base.Executar(bandasRegistradas);
            
            ExibirTituloDaOpcao("Registro de álbuns");
            Console.Write("Digite a banda que deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!;

            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                Console.WriteLine($"Essa banda: {nomeDaBanda} já existe no contexto, você será redirecionado para o menu principal");

                Thread.Sleep(2500);

            }
            else 
            {
                bandasRegistradas[nomeDaBanda] = new Banda(nomeDaBanda);

                Console.WriteLine($"A banda: {nomeDaBanda} foi registrada com sucesso!");
                Thread.Sleep(4000);
                Console.Clear();

            }

        }

    }
}
