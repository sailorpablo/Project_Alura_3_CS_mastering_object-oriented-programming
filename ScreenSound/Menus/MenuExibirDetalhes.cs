﻿
using ScreenSound.Modelos;

namespace ScreenSound.Menus
{
    internal class MenuExibirDetalhes : Menu
    {


        public override void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            base.Executar(bandasRegistradas);

            ExibirTituloDaOpcao("Exibir detalhes da banda");
            Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
            string nomeDaBanda = Console.ReadLine()!;
            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                Banda banda = bandasRegistradas[nomeDaBanda];

                Console.WriteLine($"\nA média da banda {nomeDaBanda} é {banda.Media}.");
                /**
                * ESPAÇO RESERVADO PARA COMPLETAR A FUNÇÃO
                */

                foreach (Album album in banda.Albuns)
                {
                    Console.WriteLine($"{album.Nome} -> {album.Media}");
                }
                HugginFaceAI hugginFaceAI = new HugginFaceAI();

                hugginFaceAI.Request($"Um resumo sobre a banda {nomeDaBanda}");


                Console.WriteLine("Aqui um resumo da banda: " + hugginFaceAI.Resultado);

                Console.WriteLine("Digite uma tecla para votar ao menu principal");
                Console.ReadKey();
                Console.Clear();


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
}
