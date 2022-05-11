using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParalelComputing
{
    internal class BuildArray
    {
        public int[] InitializeMatrix(int rows)
        {
            int[] matrix = new int[rows];

            Random r = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    matrix[i] = r.Next(100);
                }
            }
            return matrix;
        }
    }
}
