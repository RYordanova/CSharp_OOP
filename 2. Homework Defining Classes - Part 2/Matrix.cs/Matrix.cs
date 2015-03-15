using System;
using System.Globalization;
using System.Text;

namespace Matrix
{
    public class Matrix<T> where T : struct, IConvertible
    {
        private T[,] matrix;

        public int Rows
        {
            get
            {
                return this.matrix.GetLength(0);
            }
        }

        public int Columns
        {
            get
            {
                return this.matrix.GetLength(1);
            }
        }

        public Matrix(int rows, int columns)
        {
            if (rows < 1 || columns < 1)
            {
                throw new ArgumentException("The sizes of the matrix must be positive integers.");
            }
            this.matrix = new T[rows, columns];
        }

        public T this[int row, int column]
        {
            get
            {
                return this.matrix[row, column];
            }
            set
            {
                this.matrix[row, column] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows != second.Rows || first.Columns != second.Columns)
            {
                throw new ArgumentException("Dimentions mismatch.");
            }

            Matrix<T> result = new Matrix<T>(first.Rows, first.Columns);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    result[i, j] = sum(first[i, j], second[i, j]);
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows != second.Rows || first.Columns != second.Columns)
            {
                throw new ArgumentException("Dimentions mismatch.");
            }

            Matrix<T> result = new Matrix<T>(first.Rows, first.Columns);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    result[i, j] = substract(first[i, j], second[i, j]);
                }
            }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first.Columns != second.Rows)
            {
                throw new ArgumentException("Dimentions mismatch.");
            }

            Matrix<T> result = new Matrix<T>(first.Rows, second.Columns);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    result[i, j] = default(T);
                    for (int k = 0; k < first.Columns; k++)
                    {
                        result[i, j] = sum(result[i, j], multiply(first.matrix[i, k], second[k, j]));
                    }
                }
            }
            return result;
        }

        public static bool operator true(Matrix<T> m)
        {
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Columns; j++)
                {
                    if ((decimal)Convert.ChangeType(m.matrix[i, j], typeof(decimal)) != 0.0m)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator false(Matrix<T> m)
        {
            return m ? false : true;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            string separator = " ";
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    result.Append(this.matrix[i, j]).Append(separator);
                }

                result.Length -= separator.Length;
                result.Append(Environment.NewLine);
            }
            result.Length -= Environment.NewLine.Length;

            return result.ToString();
        }

        private static T sum(T first, T second)
        {
            return (T)((dynamic)first + second);
            // Both work :)
            //return (T)((IConvertible)(first.ToDecimal(CultureInfo.InvariantCulture) + second.ToDecimal(CultureInfo.InvariantCulture))).ToType(typeof(T), CultureInfo.InvariantCulture);
        }

        private static T substract(T first, T second)
        {
            return (T)((dynamic)first - second);
            // Both work :)
            //return (T)((IConvertible)(first.ToDecimal(CultureInfo.InvariantCulture) - second.ToDecimal(CultureInfo.InvariantCulture))).ToType(typeof(T), CultureInfo.InvariantCulture);
        }

        private static T multiply(T first, T second)
        {
            return (T)((dynamic)first * second);
            // Both work :)
            //return (T)((IConvertible)(first.ToDecimal(CultureInfo.InvariantCulture) * second.ToDecimal(CultureInfo.InvariantCulture))).ToType(typeof(T), CultureInfo.InvariantCulture);
        }

        private void ValidateIndexes(int row, int column)
        {
            if (row < 0 || row >= matrix.GetLength(0) || column < 0 || column >= matrix.GetLength(1))
            {
                throw new ArgumentException("Invalid indexes.");
            }
        }
    }
}
