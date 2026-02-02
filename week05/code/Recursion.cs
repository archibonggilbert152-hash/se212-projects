using System;
using System.Collections.Generic;
using System.Linq;

public static class Recursion
{
    // --------------------------------------------------
    // PROBLEM 1: Recursive Squares Sum
    // --------------------------------------------------
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    // --------------------------------------------------
    // PROBLEM 2: Permutations Choose
    // --------------------------------------------------
    public static List<string> PermutationsChoose(char[] letters, int size)
    {
        List<string> results = new();
        Permute("", letters, size, results);
        return results;
    }

    private static void Permute(string prefix, char[] letters, int size, List<string> results)
    {
        if (prefix.Length == size)
        {
            results.Add(prefix);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            char[] remaining = letters
                .Where((c, index) => index != i)
                .ToArray();

            Permute(prefix + letters[i], remaining, size, results);
        }
    }

    // --------------------------------------------------
    // PROBLEM 3: Climbing Stairs (Memoization)
    // --------------------------------------------------
    public static int CountWaysToClimb(int s, Dictionary<int, int> remember)
    {
        if (s < 0)
            return 0;

        if (s == 0)
            return 1;

        if (remember.ContainsKey(s))
            return remember[s];

        int result =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        remember[s] = result;
        return result;
    }

    // --------------------------------------------------
    // PROBLEM 4: Wildcard Binary Patterns
    // --------------------------------------------------
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(pattern[..index] + "0" + pattern[(index + 1)..], results);
        WildcardBinary(pattern[..index] + "1" + pattern[(index + 1)..], results);
    }
}
