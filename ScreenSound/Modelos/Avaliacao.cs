using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Modelos
{
    internal class Avaliacao
    {
        public Avaliacao(int nota) {

            if (nota >=0 && nota <= 10)
            {
                Nota = nota;

            } else
            {

                Console.WriteLine($"Nota {nota} não é valor valido.");
               
            }
        
            

        }

        public int Nota { get; set; }

        public static Avaliacao Converter(string texto)
        {
            int nota = int.Parse(texto);
            return new Avaliacao(nota);
        }




    }
}
