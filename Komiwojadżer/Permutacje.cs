using System;

namespace Komiwojadżer
{
    class Para
    {
        public int[] listaa;
        public int suma;
        public Para(int[] a, int b)
        {
            this.listaa = a;
            suma = b;
        }
    }
    class Permutacje
    {
        
       
        public int liczba_miast;
        public int[] lista;
        public Para para;
        public Matrix matrix;
        public Permutacje()
        {
            matrix = new Matrix(10);
            liczba_miast = matrix.matrix.GetLength(0);
            lista = new int[liczba_miast];
            Fill_list();
            para = new Para(lista, int.MaxValue);
        }
        private void Fill_list()
        {
            for(int i = 0; i < liczba_miast; i++)
            {
                lista[i] = i + 1;
            }
        }
        public void SwapTwoNumber(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public void PrnPermut(int k)
        {
            int pom;
            int m = lista.Length;
            if (k == m)
            {
                //for (int i = 0; i < m; i++)
                //    Console.Write("{0}", lista[i]);
                //Console.Write(" ");

                pom = Suma();
                if (para.suma>pom)
                {
                    //-----------------------------------------------------------------------------------
                    //-----------------------------------------------------------------------------------

                    para.listaa = lista;//----------TO NIE DZIAŁA
                    para.suma = pom;    //----------TO DZIAŁA

                    //-----------------------------------------------------------------------------------
                    //-----------------------------------------------------------------------------------
                }
            }
            else
                for (int i = k; i < m; i++)
                {
                    SwapTwoNumber(ref lista[k], ref lista[i]);
                    PrnPermut(k + 1);
                    SwapTwoNumber(ref lista[k], ref lista[i]);
                }

        }
        public int Suma()
        {
            int suma = 0;
            for (int p = 0; p < lista.Length-1; p++)
            {
                suma = suma + matrix.matrix[lista[p] - 1, lista[p + 1] - 1];
            }
            suma = suma + matrix.matrix[lista[lista.Length - 1] - 1, lista[0] - 1];

            return suma;
        }
    }
}
