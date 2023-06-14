using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Матрица
            int sum1 = 0;
            int sum2 = 0;
            Console.WriteLine("Введите размерность массива по строкам:");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите размерность массива по столбцам:");
            int m = Convert.ToInt32(Console.ReadLine());
            int[,] rp = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine("Введите " + '[' + i + ", " + j + ']' + " элемент: ");
                    rp[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0}\t", rp[i, j]);
                }
                Console.WriteLine();
            }

            //Первый массив
            Console.WriteLine(" ");
            int v = n;
            int[] M = new int[v];
            for (int i = 0; i < v; i++)
            {
                Console.WriteLine("Введите " + '[' + i + ']' + " элемент: ");
                M[i] = Convert.ToInt32(Console.ReadLine());
                sum1 = sum1 + M[i];
            }
            Console.WriteLine("");
            for (int i = 0; i < v; i++)
            {
                Console.Write("{0} ", M[i]);
            }

            //Второй массив
            Console.WriteLine("\n");
            int x = m;
            int[] N = new int[x];
            for (int i = 0; i < x; i++)
            {
                Console.WriteLine("Введите " + '[' + i + ']' + " элемент: ");
                N[i] = Convert.ToInt32(Console.ReadLine());
                sum2 = sum2 + N[i];
            }
            Console.WriteLine(" ");
            for (int i = 0; i < x; i++)
            {
                Console.Write("{0} ", N[i]);
            }
            Console.WriteLine("");
            //Проверка суммы
            if (sum1 == sum2)
            {
                Console.WriteLine("\nСуммы спроса и предложения совпадают");
            }
            else
            {
                Console.WriteLine("\nСуммы спроса и предложения не совпадают, задача не решаема");
                return;
            }
            int f = 0;
            int[,] nm = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    nm[i, j] = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (M[i] > N[j])
                    {
                        nm[i, j] = N[j];
                        M[i] -= N[j];
                        N[j] -= N[j];
                    }
                    else if (M[i] < N[j])
                    {
                        nm[i, j] = M[i];
                        N[j] -= M[i];
                        M[i] -= M[i];
                    }
                    else if (M[i] == N[j])
                    {
                        nm[i, j] = M[i];
                        M[i] -= M[i];
                        N[j] -= N[j];
                    }
                    f = nm[i, j] * rp[i, j] + f;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0}\t", nm[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("");
            Console.Write("Общая сумма - " + f);
        }
    }
}
