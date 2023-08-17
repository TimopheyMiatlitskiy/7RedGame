using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7RedGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод данных
            Console.WriteLine("Введите размер первой комбинации (от 1 до 7):");
            int n1 = Convert.ToInt32(Console.ReadLine());

            int[] a1 = new int[n1];
            char[] c1 = new char[n1];

            Console.WriteLine("Введите карты первой комбинации:");

            for (int i = 0; i < n1; i++)
            {
                Console.WriteLine("Введите номинал (от 1 до 7) c цветом (R/O/Y/G/C/B/P) карты:");
                string[] str = Console.ReadLine().Split();
                for (int j = 0; j < 1; j++)
                {
                    a1[i] = Convert.ToInt32(str[0]);
                    c1[i] = Convert.ToChar(str[1]);
                }
            }

            Console.WriteLine("Введите размер второй комбинации (от 1 до 7):");
            int n2 = Convert.ToInt32(Console.ReadLine());

            int[] a2 = new int[n2];
            char[] c2 = new char[n2];

            Console.WriteLine("Введите карты второй комбинации:");

            for (int i = 0; i < n2; i++)
            {
                Console.WriteLine("Введите номинал (от 1 до 7) c цветом (R/O/Y/G/C/B/P) карты:");
                string[] str = Console.ReadLine().Split();
                for (int j = 0; j < 1; j++)
                {
                    a2[i] = Convert.ToInt32(str[0]);
                    c2[i] = Convert.ToChar(str[1]);
                }
            }

            // Проверка выигрышной комбинации
            Tuple<int, char> maxCard1 = FindMaxCard(a1, c1);
            Tuple<int, char> maxCard2 = FindMaxCard(a2, c2);

            if (maxCard1.Item1 > maxCard2.Item1)
            {
                if (GetColorNumber(maxCard1.Item2) < GetColorNumber(maxCard2.Item2))
                {
                    Console.WriteLine("Первая комбинация выигрывает!");
                }
                else
                {
                    Console.WriteLine("Вторая комбинация выигрывает!");
                }
            }
            else if (maxCard1.Item1 < maxCard2.Item1)
            {
                if (GetColorNumber(maxCard1.Item2) < GetColorNumber(maxCard2.Item2))
                {
                    Console.WriteLine("Первая комбинация выигрывает!");
                }
                else
                {
                    Console.WriteLine("Вторая комбинация выигрывает!");
                }
            }
            else
            {
                if (GetColorNumber(maxCard1.Item2) < GetColorNumber(maxCard2.Item2))
                {
                    Console.WriteLine("Первая комбинация выигрывает!");
                }
                else
                {
                    Console.WriteLine("Вторая комбинация выигрывает!");
                }
            }

        }

        static Tuple<int, char> FindMaxCard(int[] a, char[] c)
        {
            int maxCardNumber = 0;
            char maxCardColor = ' ';

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > maxCardNumber)
                {
                    maxCardNumber = a[i];
                    maxCardColor = c[i];
                }
                else if (a[i] == maxCardNumber)
                {
                    if (GetColorNumber(c[i]) < GetColorNumber(maxCardColor)) // Проверка цветов по индексам
                    {
                        maxCardNumber = a[i];
                    }
                }
            }

            return Tuple.Create(maxCardNumber, maxCardColor);
        }

        static int GetColorNumber(char lett)
        {
            string colors = "ROYGCBP";
            return colors.IndexOf(lett);
        }
    }



}
