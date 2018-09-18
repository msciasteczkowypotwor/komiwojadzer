using System;
using System.Diagnostics;
using System.Threading;

namespace Komiwojadżer
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            Matrix matrix = new Matrix(12);

            Permutacje permutacje = new Permutacje(matrix);
            permutacje.matrix1.Display();


            Console.WriteLine("-----------------------------------------------------");

            Console.WriteLine("Sekwencyjnie:");
            stopWatch.Start();
            permutacje.PrnPermut(0);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",ts.Hours, ts.Minutes, ts.Seconds,ts.Milliseconds);



            for (int i = 0; i < permutacje.para.listaa.Length; i++)
                Console.Write(permutacje.para.listaa[i] + " ");
            Console.Write("\t\t" + permutacje.para.suma + "\n");
            Console.WriteLine("RunTime " + elapsedTime);
            stopWatch.Restart();
            //-------------------------------------------------------------------------------------------------
            Para_1 para_1 = new Para_1(matrix.matrix.GetLength(1));


            Console.WriteLine("Wielowątkowo:");
            stopWatch.Start();
            Licz_watki(matrix, para_1);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            foreach (int aa in para_1.lista)
                Console.Write(aa + " ");
            Console.WriteLine("\t\t" + para_1.droga);
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",ts.Hours, ts.Minutes, ts.Seconds,ts.Milliseconds);
            Console.WriteLine("RunTime " + elapsedTime);


            Console.ReadKey();
        }
        public static void Licz_watki(Matrix matrix, Para_1 para_1)
        {

            Thread[] threads = new Thread[matrix.matrix.GetLength(1) - 2];
            for (int i = 0; i < matrix.matrix.GetLength(1) - 2; i++)
            {

                Thread t = new Thread(() => Pe(matrix, para_1));
                t.Name = i.ToString();
                threads[i] = t;
                threads[i].Start();
            }
            for (int i = 0; i < matrix.matrix.GetLength(1) - 2; i++)
            {
                threads[i].Join();
            }


        }

        private static void Pe(Matrix matrix, Para_1 para_1)
        {
            Permutacje2 permutacje2 = new Permutacje2(matrix);

            // Console.WriteLine(Thread.CurrentThread.Name);
            permutacje2.PrnPermut(0);

            //for (int i = 0; i < permutacje2.para.listaa.Length; i++)
            //    Console.Write(permutacje2.para.listaa[i] + " ");
            //Console.Write(permutacje2.para.suma + "\n");

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            para_1.Dodaj(permutacje2.para.suma, permutacje2.para.listaa);

        }
    }
    public class Para_1
    {
        private Object sumLock = new object();
        public int droga { set; get; }
        public int[] lista;
        public Para_1(int a)
        {
            droga = int.MaxValue;
            lista = new int[a];
        }

        public int Dodaj(int a, int[] b)
        {
            lock (sumLock)
            {
                if (droga > a)
                {
                    droga = a;
                    for (int i = 0; i < lista.Length; i++)
                    {
                        lista[i] = b[i];
                    }
                }


            }
            return droga;
        }



    }
}
