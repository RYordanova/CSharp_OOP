using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        private static Matrix<T> fillMatrix<T>(int rows, int columns, params T[] numbers) where T : struct, IConvertible
        {
            Matrix<T> result = new Matrix<T>(rows, columns);
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == numbers.Length)
                    {
                        return result;
                    }
                    result[i, j] = numbers[index++];
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            Matrix<int> matrix = fillMatrix(3, 3,
                0, 1, 2,
                3, 4, 5,
                6, 7, 8
            );

            Console.WriteLine(matrix + matrix);
            Console.WriteLine(matrix - matrix);
            Console.WriteLine(matrix * matrix);
        }
    }
}
