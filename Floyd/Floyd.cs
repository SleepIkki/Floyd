using System;
using System.Collections.Generic;
using System.Text;

namespace Floyd
{
    class Floyd
    {
        private int[,] floydMatrix = new int[,] { };
        private int[,] adjancencyMatrix = new int[,] { };
        public int[,] FloydMatrix => floydMatrix;
        public int[,] AdjancencyMatrix
        {
            get
            {
                return adjancencyMatrix;
            }
            set
            {
                adjancencyMatrix = (int[,])value.Clone();
                floydMatrix = (int[,])value.Clone();
                MakeFloydShortestPathes();
            }
        } 
            

        public Floyd(int[,] matrix)
        {
            AdjancencyMatrix = matrix;
        }

        private void MakeFloydShortestPathes()
        {
            int size = FloydMatrix.GetUpperBound(0) + 1;

            // Применение алгоритма Флойда с использованием матрицы смежности
            for (int k = 0; k < size; k++)
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                        if (FloydMatrix[i, j] > FloydMatrix[i, k] + FloydMatrix[k, j])
                            FloydMatrix[i, j] = FloydMatrix[i, k] + FloydMatrix[k, j];
        }

        public void Show()
        {
            // Вывод измененной матрицы смежности на экран
            int size = FloydMatrix.GetUpperBound(0) + 1;

            Console.WriteLine("Floyd Algorithm : ");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write(FloydMatrix[i, j] + "\t");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
