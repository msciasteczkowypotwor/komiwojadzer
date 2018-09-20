using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Komiwojadżer
{
    class Para2
    {
        public int[] listaa;
        public int suma;
        public Para2(int a, int b)
        {
            listaa = new int[a];
            suma = b;
        }
    }
    class Permutacje2
    {
        int pom;
        public Matrix matrix1;
        public int[] lista;
        public int[] lista1;
        public Para para;
        int thread;
        int lista_leng;
        public Permutacje2(Matrix matrix)
        {
            thread= int.Parse(Thread.CurrentThread.Name);
            matrix1 = matrix;
            lista = new int[matrix.matrix.GetLength(1)];
            lista1 = new int[(matrix.matrix.GetLength(1) - 2)];
            para = new Para(lista.Length, int.MaxValue);
            lista_leng = lista1.Length;
            Fill_list();

        }
        private void Fill_list()
        {
            for (int i = 0; i < lista.Length; i++)
            {
                lista[i] = i + 1;
            }
            for (int j = 0, i = 1; j < lista1.Length; i++)
            {
                if (lista[i] != thread + 2)
                {
                    lista1[j] = lista[i];
                    j++;

                }
            }
            //for (int i = 0; i < lista1.Length; i++)
            //    Console.Write(lista1[i] + " ");
        }
        public void SwapTwoNumber(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        
        public void PrnPermut(int k)
        {
            
            if (k == lista_leng)
            {
                pom = Suma();
                if (para.suma > pom)
                {
                    para.listaa[0] = 1;
                    para.listaa[1] = thread + 2;
                    for (int aa = 0; aa < lista_leng; aa++)
                        para.listaa[aa + 2] = lista1[aa];
                    para.suma = pom;
                }
            }
            else
                for (int i = k; i < lista_leng; i++)
                {
                    SwapTwoNumber(ref lista1[k], ref lista1[i]);
                    PrnPermut(k + 1);
                    SwapTwoNumber(ref lista1[k], ref lista1[i]);
                }

        }
        public int Suma()
        {
            int suma = matrix1.matrix[0, thread + 1];
            suma=suma + matrix1.matrix[thread + 1, lista1[0] - 1];



            for (int p = 0; p < lista_leng - 1; p++)
            {
                suma = suma + matrix1.matrix[lista1[p] - 1, lista1[p + 1] - 1];
            }
            suma = suma + matrix1.matrix[lista1[lista_leng - 1] - 1, 0];

            return suma;
        }
    }
}
