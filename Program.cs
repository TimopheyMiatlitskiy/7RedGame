internal class Program
{
    static void Main()
    {
        // First combination data input 
        int firstCombinationLength = 0;

        Console.WriteLine("Enter the size of the first combination (from 1 to 7):");

        firstCombinationLength = CheckNumberInput(firstCombinationLength);

        int[] firstCombinationNumbers = new int[firstCombinationLength];
        char[] firstCombinationColors = new char[firstCombinationLength];

        Console.WriteLine("Enter the cards of the first combination:");

        Tuple <int[], char[]> timeTuple = CheckNumLet(firstCombinationLength, firstCombinationNumbers, firstCombinationColors);

        firstCombinationNumbers = timeTuple.Item1;
        firstCombinationColors = timeTuple.Item2;

        // Second combination data input 
        int secondCombinationLength = 0;

        Console.WriteLine("Enter the size of the second combination (from 1 to 7):");

        secondCombinationLength = CheckNumberInput(secondCombinationLength);

        int[] secondCombinationNumbers = new int[secondCombinationLength];
        char[] secondCombinationColors = new char[secondCombinationLength];

        Console.WriteLine("Enter the cards of the second combination:");

        timeTuple = CheckNumLet(secondCombinationLength, secondCombinationNumbers, secondCombinationColors);

        secondCombinationNumbers = timeTuple.Item1;
        secondCombinationColors = timeTuple.Item2;

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

    static int CheckNumberInput(int number)
    {
        for (int i = 0; i < 1; i++)
        {
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("uncorrect input");
                i--;
                continue;
            }
            if (number > 7 || number < 1)
            {
                Console.WriteLine("uncorrect input");
                i--;
                continue;
            }
        }
        return number;
    }

    static Tuple<int[], char[]> CheckNumLet(int length, int[] number, char[] color)
    {
        for (int i = 0; i < length; i++)
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
                    number[i] = Convert.ToInt32(str[0]);
                    color[i] = Convert.ToChar(str[1].ToUpper());
                }
            }
            else
            {
                Console.WriteLine("uncorrect input");
                i--;
                continue;
            }
        }
        return new Tuple<int[], char[]>(number, color);
    }
}