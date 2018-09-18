using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komiwojadżer
{
    class Matrix
    {
        public int[,] matrix;
        public Matrix(int n)
        {
            matrix = new int[n, n];
            Fill();
        }
        public void Fill()
        {
            Random rnd = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i+1; j < matrix.GetLength(0); j++)
                {
                    matrix[i, j] = matrix[j,i] = rnd.Next(1, 10);
                }
            }
        }
        public void Display()
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(matrix[i, j]+" ");
                }
                Console.Write("\n");
            }
        }

    }
}
