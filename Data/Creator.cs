using System;

namespace Data
{
    public class Creator
    {
        static Random Random = new Random();
        public static double[,] MatrixCreator(string name, int N)
        {
            double[,] matrix = new double[N,N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    while (true)
                    {
                        try
                        {
                            Console.Write("Enter the element of matrix {0}[{1},{2}]:", name, i, j);
                            matrix[i,j]= Convert.ToSingle(Console.ReadLine());
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid value entered");
                        }    
                    }
                }
            }
            return matrix;
        }

        public static double[,] RandomMatrixCreator(int N)
        {
            double[,] matrix = new double[N,N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    matrix[i,j] = Random.Next(-10,10);
                }
            }
            return matrix;
        }

        public static double[] VectorCreator(string name, int N)
        {
            double[] vector = new double[N];
            for (int i = 0; i < N; i++)
            {
                while (true)
                {
                    try
                    {
                        Console.Write("Enter the element of vector {0}[{1}]:", name, i);
                        vector[i] = Convert.ToSingle(Console.ReadLine());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid value entered");
                    }
                }
            }
            return vector;
        }
        
        public static double[] RandomVectorCreator(int N)
        {
            double[] vector = new double[N];
            for (int i = 0; i < N; i++)
            {
                vector[i] = Random.Next(-10, 10);
            }
            return vector;
        }
    }
}