using System;
using System.Diagnostics;
using System.Threading;

namespace Komiwojadżer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Process cmd1 = new Process();
            //cmd1.StartInfo.FileName = "cmd.exe";
            //cmd1.StartInfo.RedirectStandardInput = true;
            //cmd1.StartInfo.RedirectStandardOutput = true;
            //cmd1.StartInfo.CreateNoWindow = true;
            //cmd1.StartInfo.UseShellExecute = false;
            //cmd1.Start();

            //cmd1.StandardInput.WriteLine("del "+ "C:\\Users\\mscia\\Desktop\\czas.txt");
            //cmd1.StandardInput.Flush();
            //cmd1.StandardInput.Close();
            //cmd1.WaitForExit();
            //Console.WriteLine(cmd1.StandardOutput.ReadToEnd());
            //for (int h = 0; h < 10; h++)
            //{
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
                float time1 = (float)ts.TotalMilliseconds;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);



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
                float time2 = (float)ts.TotalMilliseconds;
                elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                Console.WriteLine("RunTime " + elapsedTime);
                Console.WriteLine(time1 / time2);

            //    Process cmd = new Process();
            //    cmd.StartInfo.FileName = "cmd.exe";
            //    cmd.StartInfo.RedirectStandardInput = true;
            //    cmd.StartInfo.RedirectStandardOutput = true;
            //    cmd.StartInfo.CreateNoWindow = true;
            //    cmd.StartInfo.UseShellExecute = false;
            //    cmd.Start();

            //    cmd.StandardInput.WriteLine("echo "+ time1 / time2+ " >> C:\\Users\\mscia\\Desktop\\czas.txt");
            //    cmd.StandardInput.Flush();
            //    cmd.StandardInput.Close();
            //    cmd.WaitForExit();
            //    Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            //}

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

        public void Dodaj(int a, int[] b)
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
        }



    }
}
