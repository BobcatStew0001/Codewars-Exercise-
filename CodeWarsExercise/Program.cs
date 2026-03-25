using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System; 
using System.Collections.Generic;

namespace CodeWarsExercise;

class Program
{
    //Find the Average 
    public static int FindAverage(int[] nums)
    {
        return  nums.Sum() / nums.Length; 
    }
    
    
    //Is this a Pangram
    public static bool IsPangram(string str)
    {
        return str.ToLower().Where(char.IsLetter).Distinct().Count() == 26;
    }
    
    
    //Find array2 in array1
    public static string[] inArray(string[] array1, string[] array2)
    {
        return array1.Where(a => array2.Any(b => b.Contains(a)))
                     .Distinct()
                     .OrderBy(x => x)
                     .ToArray();
    }

  
    //Solutions Challenge 
    public static string[] Solutions(string str)
    {
        if (str.Length % 2 != 0)
        {
            str += "_";
        }

        var result = new string[str.Length / 2];
        for (int i = 0; i < str.Length; i += 2)
        {
            result[i / 2] = str.Substring(i, 2);
        }

        return result;
    }
    

    //Find the char position in the Alphabet 
    public static string AlphabetPosition(string text)
    {
        return string.Join(" ", text.ToLower()
                                    .Where(char.IsLetter)
                                    .Select(c => c - 'a' + 1));
    }
    
    
    //Print the Array 
    public static string PrintArray(System.Collections.IEnumerable array)
    {
        var elements = new List<string>();
        foreach (var item in array)
        {
            string formatted;
            if (item is string s) formatted = s;
            else if (item is System.Collections.IEnumerable inner && !(item is string))
            {
                formatted = PrintArray(inner);
            }
            else
            {
                formatted = item?.ToString()?.ToLower() ?? "null";
            }
            
            if (formatted.Length > 0)
            {
                formatted = char.ToUpper(formatted[0]) + formatted.Substring(1);
            }
            elements.Add(formatted);
        }
        return string.Join(",", elements);
    }
    
    
    //Get the bottom floor in US vs EU:No 13 in US 
    public static int GetRealFloor(int n)
    {
        if (n < 0) return n;
        if (n < 15) return n - 1;
        return n - 2;
    }
    
    
    //Number of Petals = Love message
    
    public static string HowMuchILoveYou(int nbPetals)
    {
        return ((nbPetals - 1) % 6) switch
        {
            0 => "I love you",
            1 => "a little",
            2 => "a lot",
            3 => "passionately",
            4 => "madly",
            5 => "not at all",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    
    //Who Likes this 
    public static string Likes(string[] name)
    {
        return name.Length switch
        {
            0 => "no one likes this",
            1 => $"{name[0]} likes this",
            2 => $"{name[0]} and {name[1]} like this",
            3 => $"{name[0]}, {name[1]} and {name[2]} like this",
            _ => $"{name[0]}, {name[1]} and {name.Length - 2} others like this"
        };
    }
    
    
    //Remove the smallest 
    public static List<int> RemoveSmallest(List<int> numbers)
    {
        if (numbers == null || numbers.Count == 0) return new List<int>();
        var result = new List<int>(numbers);
        int minIndex = 0;
        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] < numbers[minIndex])
            {
                minIndex = i;
            }
        }
        result.RemoveAt(minIndex);
        return result;
    }
    
    
    //Validate Sudoku board
    public static bool Validate(int[][] board)
    {
        Func<IEnumerable<int>, bool> isValidSection = s =>
            s.Count() == 9 && s.All(x => x >= 1 && x <= 9) && s.Distinct().Count() == 9;

        
       //Validate Rows
       var rowsValid = board.All(row => isValidSection(row));
       
       //Validate Columns
       var colsValid = Enumerable.Range(0 , 9).All(col => isValidSection(board.Select(row => row[col])));
       
       //Validate 3x3 Boxes 
       var boxesValid = Enumerable.Range(0, 9)
           .All(b => isValidSection(
               Enumerable.Range(0, 9).Select(i => board[3 * (b / 3) + i / 3][3 * (b % 3) + i % 3])
           ));
       
       return rowsValid && colsValid && boxesValid;

       
    //Sum of numbers above 0 
    }
    public static int[] CountPositivesSumNegatives(int[] input)
    {
        if (input == null || input.Length == 0)
        {
            return [];
        }

        int countPositives = input.Count(x => x > 0);
        int sumNegatives = input.Where(x => x < 0).Sum();

        return [countPositives, sumNegatives];
    }
    
    
    //Are you playing the banjo
    public static string AreYouPlayingBanjo(string name)
    {
        if (name.First() == 'R' || 'r' == name.First())
        {
            return "plays the banjo"; 
        }
        else
        {
            return "does not play banjo";
        }
    }
    
    
    //Object Check 
    public static bool Check(object[] a, object x)
    {
        var objCheck = a.Contains(x);
        return objCheck;
    }
     
    //String Counter 
    public static int StrCount(string str, char letter)
    {
        return str.Count(x => x == letter);
        
    }
    
    
    //Positive Sum above 0
    public static int PositiveSum(int[] arr)
    {
        return (arr ?? []).Where(x => x > 0).Sum();
    }
    
    
    //Return the expression
    public static int ExpressionsMatter(int a, int b, int c)
    {
        return new[]
        {
            a + b + c,
            a * b * c,
            a + b * c,
            (a + b) * c,
            a * b + c,
            a * (b + c)
        }.Max();
    }
    
    
    //Find the multiples 
    public static List<int> FindMultiples(int n, int limit)
    {
        var result = new List<int>();
        for (int i = n; i <= limit; i += n)
        {
            result.Add(i);
        }
        return result;
    }
    
    
    //High and Low 
    public static string HighandLow(string numbers)
    {
        var nums = numbers.Split(' ').Select(int.Parse).ToList();
        return $"{nums.Max()} {nums.Min()}";
    }
    
    
    //Find the Min and Max of an Array 
    public static int[] minMax(int[] lst)
    {
        return new[] { lst.Min(), lst.Max() };
    }
    
    
    //Merge Arrays 
    public static int[] MergeArrays(int[] arr1, int[] arr2)
    {
        return arr1.Concat(arr2).Order().ToArray();
    }

    
    //Get the size of the box
    public static int[] Get_size(int w, int h, int d)
    {
        return new[] { w, h, d };
    }
    
    
    //Main Method Starts Here: Test from Above Methods created and ran by Junie.
    static void Main(string[] args)
    {
        // Tests for HowMuchILoveYou
        Console.WriteLine("--- HowMuchILoveYou Tests ---");
        Console.WriteLine($"HowMuchILoveYou(1): {HowMuchILoveYou(1)} (Expected: I love you)");
        Console.WriteLine($"HowMuchILoveYou(2): {HowMuchILoveYou(2)} (Expected: a little)");
        Console.WriteLine($"HowMuchILoveYou(6): {HowMuchILoveYou(6)} (Expected: not at all)");
        Console.WriteLine($"HowMuchILoveYou(7): {HowMuchILoveYou(7)} (Expected: I love you)");
        Console.WriteLine();

        // Tests for PositiveSum
        int[] numbers = { 1, -4, 7, 12 };
        int sum = PositiveSum(numbers);
        Console.WriteLine($"PositiveSum - {{1, -4, 7, 12}}: {sum} (Expected: 20)");

        int[] emptyArr = { };
        Console.WriteLine($"PositiveSum - empty: {PositiveSum(emptyArr)} (Expected: 0)");

        int[] nullArr = null;
        Console.WriteLine($"PositiveSum - null: {PositiveSum(nullArr)} (Expected: 0)");

        Console.WriteLine();

        // Tests for ExpressionsMatter
        Console.WriteLine($"ExpressionsMatter(2, 1, 2): {ExpressionsMatter(2, 1, 2)} (Expected: 6)");
        Console.WriteLine($"ExpressionsMatter(2, 1, 1): {ExpressionsMatter(2, 1, 1)} (Expected: 4)");
        Console.WriteLine($"ExpressionsMatter(1, 1, 1): {ExpressionsMatter(1, 1, 1)} (Expected: 3)");
        Console.WriteLine($"ExpressionsMatter(1, 2, 3): {ExpressionsMatter(1, 2, 3)} (Expected: 9)");
        Console.WriteLine($"ExpressionsMatter(1, 3, 1): {ExpressionsMatter(1, 3, 1)} (Expected: 5)");
        Console.WriteLine($"ExpressionsMatter(2, 2, 2): {ExpressionsMatter(2, 2, 2)} (Expected: 8)");

        // Tests for minMax
        int[] minMaxArr = { 1, 2, 3, 4, 5 };
        int[] result = minMax(minMaxArr);
        Console.WriteLine($"minMax - {{1, 2, 3, 4, 5}}: {{{string.Join(", ", result)}}} (Expected: 1, 5)");

        // Demonstration of Concat
        int[] first = { 1, 2 };
        int[] second = { 3, 4 };
        int[] combined = first.Concat(second).ToArray();
        Console.WriteLine($"Concat - {{1, 2}} and {{3, 4}}: {{{string.Join(", ", combined)}}} (Expected: 1, 2, 3, 4)");

        // Modern C# 12 "Merge" using Spread Operator
        int[] merged = [..first, ..second];
        Console.WriteLine($"Spread Operator - {{1, 2}} and {{3, 4}}: {{{string.Join(", ", merged)}}} (Expected: 1, 2, 3, 4)");

        // Chaining Concat and Order
        int[] unsorted1 = { 5, 2 };
        int[] unsorted2 = { 1, 4, 3 };
        int[] sortedResult = unsorted1.Concat(unsorted2).Order().ToArray();
        Console.WriteLine($"Concat and Order - {{5, 2}} and {{1, 4, 3}}: {{{string.Join(", ", sortedResult)}}} (Expected: 1, 2, 3, 4, 5)");

        // Demonstration of Distinct
        int[] duplicates = { 1, 2, 2, 3, 3, 3, 4 };
        int[] unique = duplicates.Distinct().ToArray();
        Console.WriteLine($"Distinct - {{1, 2, 2, 3, 3, 3, 4}}: {{{string.Join(", ", unique)}}} (Expected: 1, 2, 3, 4)");

        // Combining Concat, Distinct, and Order
        int[] a = { 1, 3, 5 };
        int[] b = { 3, 4, 5, 6 };
        int[] final = a.Concat(b).Distinct().Order().ToArray();
        Console.WriteLine($"Concat, Distinct, Order - {{1, 3, 5}} + {{3, 4, 5, 6}}: {{{string.Join(", ", final)}}} (Expected: 1, 3, 4, 5, 6)");

        // Tests for FindMultiples
        int n = 2;
        int limit = 6;
        int[] multiples = FindMultiples(n, limit).ToArray();
        Console.WriteLine($"FindMultiples - n: 2, limit: 6: {{{string.Join(", ", multiples)}}} (Expected: 2, 4, 6)");

        // New PrintArray tests for nested arrays
        Console.WriteLine("\n--- PrintArray Tests ---");
        
        // Simple string array
        string[] hola = { "h", "o", "l", "a" };
        Console.WriteLine($"Hola array: {PrintArray(hola)} (Expected: H,O,L,A)");

        // Boolean array
        bool[] boolArr = { true, false, true };
        Console.WriteLine($"Bool array: {PrintArray(boolArr)} (Expected: True,False,True)");

        // Array of objects/string arrays
        object[] stringArrays = { new[] { "a", "b" }, new[] { "c", "d" } };
        Console.WriteLine($"String arrays: {PrintArray(stringArrays)} (Expected: A,B,C,D)");

        // Array of number arrays
        int[][] numberArrays = { new[] { 1, 2 }, new[] { 3, 4 } };
        Console.WriteLine($"Number arrays: {PrintArray(numberArrays)} (Expected: 1,2,3,4)");

        // Mixed arrays
        object[] mixedArrays = { new[] { 1, 2 }, new[] { "x", "y" }, true };
        Console.WriteLine($"Mixed arrays: {PrintArray(mixedArrays)} (Expected: 1,2,X,Y,True)");

        // Finding the smallest number
        int[] numbersForMin = { 34, 15, 88, 2 };
        int smallestNum = numbersForMin.Min();
        Console.WriteLine($"\nSmallest number in {{34, 15, 88, 2}} is: {smallestNum} (using Min())");

        // Demonstration of RemoveSmallest
        List<int> numbersList = new List<int> { 5, 3, 2, 1, 4 };
        List<int> resultList = RemoveSmallest(numbersList);
        Console.WriteLine($"RemoveSmallest - {{5, 3, 2, 1, 4}}: {{{string.Join(", ", resultList)}}} (Expected: 5, 3, 2, 4)");

        // Tests for GetRealFloor
        Console.WriteLine("\n--- GetRealFloor Tests ---");
        Console.WriteLine($"GetRealFloor(1): {GetRealFloor(1)} (Expected: 0)");
        Console.WriteLine($"GetRealFloor(0): {GetRealFloor(0)} (Expected: -1)");
        Console.WriteLine($"GetRealFloor(5): {GetRealFloor(5)} (Expected: 4)");
        Console.WriteLine($"GetRealFloor(15): {GetRealFloor(15)} (Expected: 13)");
        Console.WriteLine($"GetRealFloor(13): {GetRealFloor(13)} (Expected: 12)");
        Console.WriteLine($"GetRealFloor(-3): {GetRealFloor(-3)} (Expected: -3)");

        // Tests for Solutions
        Console.WriteLine("\n--- Solutions Tests (String split into pairs) ---");
        string test1 = "abc";
        string test2 = "abcdef";
        Console.WriteLine($"Solutions(\"abc\"): {string.Join(", ", Solutions(test1))} (Expected: ab, c_)");
        Console.WriteLine($"Solutions(\"abcdef\"): {string.Join(", ", Solutions(test2))} (Expected: ab, cd, ef)");

        // Tests for IsPangram
        Console.WriteLine("\n--- IsPangram Tests ---");
        string pangram = "The quick brown fox jumps over the lazy dog";
        string notPangram = "The quick brown fox jumps over the dog";
        Console.WriteLine($"IsPangram(\"{pangram}\"): {IsPangram(pangram)} (Expected: True)");
        Console.WriteLine($"IsPangram(\"{notPangram}\"): {IsPangram(notPangram)} (Expected: False)");
    }
}