using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it. If n <= 0, just return 0.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case
        if (n <= 0)
            return 0;

        // Recursive case
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length 'size' from a list of 'letters' into results.
    /// For example, letters=[A,B,C], size=2 → AB, AC, BA, BC, CA, CB
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: when the desired size is reached, add the built word
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: choose each letter and recurse with remaining
        foreach (char c in letters)
        {
            string remaining = new string(letters.Where(ch => ch != c || word.Contains(ch) == false).ToArray());
            PermutationsChoose(results, remaining, size, word + c);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count the number of ways to climb 's' stairs using 1, 2, or 3 steps at a time.
    /// Uses memoization for efficiency.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize memoization dictionary
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base cases
        if (s < 0)
            return 0;
        if (s == 0)
            return 1;

        // Check memoized value
        if (remember.ContainsKey(s))
            return remember[s];

        // Recursive relation
        decimal ways = CountWaysToClimb(s - 1, remember)
                     + CountWaysToClimb(s - 2, remember)
                     + CountWaysToClimb(s - 3, remember);

        // Store in memo and return
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Using recursion, expand a binary string pattern containing * into all possible 0/1 combinations.
    /// Example: "1*0" → "100", "110"
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        // Base case: no wildcards left
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace * with 0 and recurse
        WildcardBinary(pattern[..index] + "0" + pattern[(index + 1)..], results);
        // Replace * with 1 and recurse
        WildcardBinary(pattern[..index] + "1" + pattern[(index + 1)..], results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Use recursion to insert all paths that start at (0,0) and end at the 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize current path if needed
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        // Check if move is valid — note the argument order matches Maze.IsValidMove()
        if (!maze.IsValidMove(currPath, x, y))
            return;

        // Add current position to path
        currPath.Add((x, y));

        // Base case: reached the end
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            // Explore all four directions (recursive DFS)
            SolveMaze(results, maze, x + 1, y, currPath); // Right
            SolveMaze(results, maze, x - 1, y, currPath); // Left
            SolveMaze(results, maze, x, y + 1, currPath); // Down
            SolveMaze(results, maze, x, y - 1, currPath); // Up
        }

        // Backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }
}