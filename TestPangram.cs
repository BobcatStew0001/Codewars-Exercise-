using System;
using System.Linq;
using CodeWarsExercise;

public class TestPangram
{
    public static void Main()
    {
        string pangram = "The quick brown fox jumps over the lazy dog";
        string notPangram = "The quick brown fox jumps over the dog";

        bool result1 = Program.IsPangram(pangram);
        bool result2 = Program.IsPangram(notPangram);

        Console.WriteLine($"[DEBUG_LOG] IsPangram(\"{pangram}\"): {result1}");
        Console.WriteLine($"[DEBUG_LOG] IsPangram(\"{notPangram}\"): {result2}");

        if (result1 == true && result2 == false)
        {
            Console.WriteLine("[DEBUG_LOG] Test Passed!");
        }
        else
        {
            Console.WriteLine("[DEBUG_LOG] Test Failed!");
        }
    }
}
