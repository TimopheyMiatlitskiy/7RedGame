internal class Program
{
    static void Main()
    {
        // Data input
        int firstCombinationLength = 0;
        for (int i = 0; i < 1; i++)
        {
            Console.WriteLine("Enter the size of the first combination (from 1 to 7):");
            try
            {
                firstCombinationLength = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("uncorrect input");
                i--;
                continue;
            }
            if (firstCombinationLength > 7 || firstCombinationLength < 1)
            {
                Console.WriteLine("uncorrect input");
                i--;
                continue;
            }
        }

        int[] firstCombinationNumbers = new int[firstCombinationLength];
        char[] firstCombinationColors = new char[firstCombinationLength];

        Console.WriteLine("Enter the cards of the first combination:");

        for (int i = 0; i < firstCombinationLength; i++)
        {
            Console.WriteLine("Enter the denomination (from 1 to 7) with color (R/O/Y/G/C/B/P) of the card:");
            Hint();
            string[] str = Console.ReadLine().Split();

            if (str.Length != 2 || !int.TryParse(str[0], out _) || !char.TryParse(str[1], out _))
            {
                Console.WriteLine("uncorrect input");
                i--;
                continue;
            }

            if (Convert.ToInt32(str[0]) <= 7 && Convert.ToInt32(str[0]) > 0 && CheckLetter(Convert.ToChar(str[1].ToUpper())))
            {
                for (int j = 0; j < 1; j++)
                {
                    firstCombinationNumbers[i] = Convert.ToInt32(str[0]);
                    firstCombinationColors[i] = Convert.ToChar(str[1].ToUpper());
                }
            }
            else
            {
                Console.WriteLine("uncorrect input");
                i--;
                continue;
            }
        }

        Console.WriteLine("Enter the size of the second combination (from 1 to 7):");
        int secondCombinationLength = 0;
        for (int i = 0; i < 1; i++)
        {
            Console.WriteLine("Enter the size of the first combination (from 1 to 7):");
            try
            {
                secondCombinationLength = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("uncorrect input");
                i--;
                continue;
            }
            if (secondCombinationLength > 7 || secondCombinationLength < 1)
            {
                Console.WriteLine("uncorrect input");
                i--;
                continue;
            }
        }

        int[] secondCombinationNumbers = new int[secondCombinationLength];
        char[] secondCombinationColors = new char[secondCombinationLength];

        Console.WriteLine("Enter the cards of the second combination:");

        for (int i = 0; i < secondCombinationLength; i++)
        {
            Console.WriteLine("Enter the denomination (from 1 to 7) with color (R/O/Y/G/C/B/P) of the card:");
            Hint();
            string[] str = Console.ReadLine().Split();

            if (str.Length != 2 || !int.TryParse(str[0], out _) || !char.TryParse(str[1], out _))
            {
                Console.WriteLine("uncorrect input");
                i--;
                continue;
            }

            if (Convert.ToInt32(str[0]) <= 7 && Convert.ToInt32(str[0]) > 0 && CheckLetter(Convert.ToChar(str[1].ToUpper())))
            {
                for (int j = 0; j < 1; j++)
                {
                    secondCombinationNumbers[i] = Convert.ToInt32(str[0]);
                    secondCombinationColors[i] = Convert.ToChar(str[1].ToUpper());
                }
            }
            else
            {
                Console.WriteLine("uncorrect input");
                i--;
                continue;
            }
        }

        // Checking the winning combination
        Tuple<int, char> maxCard1 = FindMaxCard(firstCombinationNumbers, firstCombinationColors);
        Tuple<int, char> maxCard2 = FindMaxCard(secondCombinationNumbers, secondCombinationColors);

        if (maxCard1.Item1 > maxCard2.Item1)
        {
            Console.WriteLine("The first combination wins!");
        }
        else if (maxCard1.Item1 < maxCard2.Item1)
        {
            Console.WriteLine("The second combination wins!");
        }
        else
        {
            if (GetColorNumber(maxCard1.Item2) < GetColorNumber(maxCard2.Item2))
            {
                Console.WriteLine("The first combination wins!");
            }
            else if (GetColorNumber(maxCard1.Item2) > GetColorNumber(maxCard2.Item2))
            {
                Console.WriteLine("The second combination wins!");
            }
            else { Console.WriteLine("Unreal"); }
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
                if (GetColorNumber(c[i]) < GetColorNumber(maxCardColor)) // Checking colors by indexes
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

    static bool CheckLetter(char Letter)
    {
        string colors = "ROYGCBP";
        int pulpe = colors.IndexOf(Letter);

        if (pulpe >= 0)
            return true;
        else
            return false;
    }

    static void Hint()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("1 R");
        Console.ResetColor();
        Console.SetCursorPosition(0, Console.CursorTop);
    }
}