﻿using System;
using System.Linq;

namespace Komiwojadżer
{
    class Para
    {
        public int[] listaa;
        public int suma;
        public Para(int a, int b)
        {
            listaa = new int[a];
            suma = b;
        }
    }
    class Permutacje
    {

        public Matrix matrix1;
        public int[] lista;
        public int[] lista1;
        public Para para;
        public Permutacje(Matrix matrix)
        {
            matrix1 = matrix;
            lista = new int[matrix.matrix.GetLength(1)];
            lista1 = new int[(matrix.matrix.GetLength(1) - 1)];
            para = new Para(lista.Length, int.MaxValue);
            Fill_list();
           
        }
        private void Fill_list()
        {
            for(int i = 0; i < lista.Length; i++)
            {
                lista[i] = i + 1;
            }
            for (int j = 0;j < lista1.Length; j++)
            {
                lista1[j] = j + 2;
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
            int m = lista1.Length;
            if (k == m)
            {
                pom = Suma();
                if (para.suma > pom)
                {
                    para.listaa[0] = 1;
                    for (int aa = 0; aa < lista1.Length; aa++)
                        para.listaa[aa+1] = lista1[aa];
                    para.suma = pom;
                }
            }
            else
                for (int i = k; i < m; i++)
                {
                    SwapTwoNumber(ref lista1[k], ref lista1[i]);
                    PrnPermut(k + 1);
                    SwapTwoNumber(ref lista1[k], ref lista1[i]);
                }

        }
        public int Suma()
        {
            int suma = matrix1.matrix[0, lista1[0] - 1];

            for (int p = 0; p < lista1.Length-1; p++)
            {
                suma = suma + matrix1.matrix[lista1[p] - 1, lista1[p + 1] - 1];
            }
            suma = suma + matrix1.matrix[lista1[lista1.Length - 1] - 1, 0];

            return suma;
        }
    }
}
