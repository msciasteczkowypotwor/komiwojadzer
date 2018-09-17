using System;

namespace Komiwojadżer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            Permutacje permutacje = new Permutacje();
            permutacje.matrix.Fill();
            permutacje.matrix.Display();

            Console.WriteLine("-----------------------------------------------------");

            foreach(var i in permutacje.lista)
            {
                Console.Write(i + " ");
            }
            Console.Write("\n");
            permutacje.PrnPermut(0);
     


            for (int i =0;i<permutacje.para.listaa[permutacje.para.listaa.Length-1];i++)
                Console.Write(permutacje.para.listaa[i] + " ");
            Console.Write(permutacje.para.suma + "\n");
            //Console.WriteLine(permutacje.liczba_miast);
            //foreach(var a in permutacje.lista)
            //{		[5]	6	int

            //    Console.WriteLine(a);
            //}
            //permutacje.PrnPermut(0,matrix);
            


            

            Console.ReadKey();
        }
          
    }
}

