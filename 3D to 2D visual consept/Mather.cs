using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ManagedCuda;
using ManagedCuda.BasicTypes;
using ManagedCuda.VectorTypes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _3D_to_2D_visual_consept
{
    internal class Matrix_Operations
    {
        public Matrix_Operations() { }

        public double[] Dot_Product(Matrix matrix_A, Matrix matrix_B)
        {
            int A_cols = matrix_A.Columns;
            int A_rows = matrix_A.Rows;
            int B_cols = matrix_B.Columns;
            int B_rows = matrix_B.Rows;

            double result = 0;
            List<double> matrix_C = new List<double>();

            if ((A_cols == B_cols && A_rows == B_rows) || (A_cols == B_rows && A_rows == B_cols))
            {
                Parallel.For(0, matrix_A.Length, i =>
                {
                    for (int j = 0; j < A_rows; j++)
                    {
                        for (int k = 0; k < A_cols; k++)
                        {
                            result += matrix_A[j, k] * matrix_B[k, j];
                        }
                        matrix_C.Add(result);
                        result = 0;
                    }
                });
            }
            else
                throw new Exception("Matrices are not of the same dimention.");

            return matrix_C.ToArray();
        }
    }
    internal class Mather_CUDA
    {
        public Mather_CUDA()
        {

        }
    }
    public class Matrix
    {
        private int rows;
        private int cols;
        private double[,] data;

        // Constructor
        public Matrix(int rows, int cols, double[] array)
        {
            this.rows = rows;
            this.cols = cols;
            this.data = new double[rows, cols];

            if (array == null || array.Length != rows * cols)
                throw new Exception("Array doesn't match the matrix.");

            Parallel.For(0, (rows * cols), i =>
            {
                int element = 0;
                for (int j = 0; j < rows; j++)
                {
                    for (int k = 0; k < cols; k++)
                    {
                        this.data[j, k] = Convert.ToDouble(array.GetValue(element));
                        element++;
                    }
                }
            });
        }

        // Property to access the number of rows
        public int Rows
        {
            get { return rows; }
        }

        // Property to access the number of columns
        public int Columns
        {
            get { return cols; }
        }

        public int Length
        { 
            get { return rows * cols; } 
        }

        // Indexer to access individual elements of the matrix
        public double this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }

        // Method to print the matrix
        public void Print()
        {
            for (int i = 0; i < rows; i++)
            {
                Console.Write("[");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(data[i, j] + " ");
                }
                Console.Write("]");
                Console.WriteLine();
            }
        }
    }
}
