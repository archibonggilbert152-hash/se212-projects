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
    // PROBLEM 2: Permutations Choose (PUBLIC ENTRY)
    // --------------------------------------------------
    public static List<string> PermutationsChoose(char[] letters, int size)
    {
        List<string> results = new();
        PermutationsChoose("", letters, size, results);
        return results;
    }

    // 👇 THIS is the overload the tests expect (3 args)
    public static void PermutationsChoose(
        string prefix,
        char[] letters,
        int size,
        List<string> results)
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

            PermutationsChoose(prefix + letters[i], remaining, size, results);
        }
    }

    // --------------------------------------------------
    // PROBLEM 3: Climbing Stairs (DEFAULT PARAM FIX)
    // --------------------------------------------------
    public static int CountWaysToClimb(
        int s,
        Dictionary<int, int>? remember = null)
    {
        remember ??= new Dictionary<int, int>();

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

    // --------------------------------------------------
    // PROBLEM 5: Solve Maze (TEST EXPECTS THIS HERE)
    // --------------------------------------------------
    public static void SolveMaze(
        Maze maze,
        int x,
        int y,
        List<(int, int)> currPath,
        List<string> results)
    {
        if (!maze.IsValidMove(currPath, x, y))
            return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        SolveMaze(maze, x + 1, y, currPath, results);
        SolveMaze(maze, x - 1, y, currPath, results);
        SolveMaze(maze, x, y + 1, currPath, results);
        SolveMaze(maze, x, y - 1, currPath, results);

        currPath.RemoveAt(currPath.Count - 1);
    }
}
