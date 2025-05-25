using leetcode_solutions_csharp.Utils.Helpers;

namespace leetcode_solutions_csharp.SlidingWindow.Hard;

public class LongestSubstringOfOneRepeatingCharacter
{
    /*
     * 2213. Longest Substring of One Repeating Character
     * You are given a 0-indexed string s. You are also given a 0-indexed string queryCharacters of length k and a 0-indexed array of integer indices queryIndices of length k, both of which are used to describe k queries.

        The ith query updates the character in s at index queryIndices[i] to the character queryCharacters[i].

        Return an array lengths of length k where lengths[i] is the length of the longest substring of s consisting of only one repeating character after the ith query is performed.
     */

    public void Run()
    {
        Console.WriteLine(PrintHelper.PrintNestedList(Solution("babacc", "bcb", new int[] {1, 3, 3}))); // [3,3,4]
        Console.WriteLine(PrintHelper.PrintNestedList(Solution("abyzz", "aa", new int[] { 2, 1 }))); // [2, 3]
    }

    public int[] Solution(string s, string queryCharacters, int[] queryIndices)
    {
        var t = new ArraySegmentTree(s.ToCharArray());
        var result = new int[queryIndices.Length];
        for (var i = 0; i < queryIndices.Length; i++)
        {
            t.ReplaceChar(queryIndices[i], queryCharacters[i]);
            result[i] = t.GetLongestContinuousSegment();
        }
        return result;
    }

    private class ArraySegmentTree
    {
        private readonly char[] s;
        private readonly int[] prefixLength;
        private readonly int[] suffixLength;
        private readonly int[] longestContinuous;
        private readonly int n;

        public int GetLongestContinuousSegment()
        {
            return longestContinuous[1];
        }

        public void ReplaceChar(int pos, char value)
        {
            ReplaceChar(1, 0, n - 1, pos, value);
        }

        private void ReplaceChar(int v, int tl, int tr, int pos, char value)
        {
            if (tl == tr)
            {
                s[tl] = value;
            }
            else
            {
                var tm = tl + (tr - tl) / 2;
                if (pos <= tm)
                    ReplaceChar(v * 2, tl, tm, pos, value);
                else
                    ReplaceChar(v * 2 + 1, tm + 1, tr, pos, value);
                UpdateLength(v, tl, tr, tm);
            }
        }

        private void Build(int v, int tl, int tr)
        {
            if (tl < tr)
            {
                var tm = tl + (tr - tl) / 2;
                if (tl < tm)
                    Build(v * 2, tl, tm);
                if (tm + 1 < tr)
                    Build(v * 2 + 1, tm + 1, tr);
                UpdateLength(v, tl, tr, tm);
            }
        }

        private void UpdateLength(int v, int tl, int tr, int tm)
        {
            var vl = 2 * v;
            var vr = 2 * v + 1;
            longestContinuous[v] = int.Max(longestContinuous[vl], longestContinuous[vr]);
            prefixLength[v] = prefixLength[vl];
            suffixLength[v] = suffixLength[vr];
            if (s[tm] == s[tm + 1])
            {
                longestContinuous[v] = int.Max(longestContinuous[v], suffixLength[vl] + prefixLength[vr]);
                if (suffixLength[vl] == tm - tl + 1)
                    prefixLength[v] += prefixLength[vr];
                if (prefixLength[vr] == tr - tm)
                    suffixLength[v] += suffixLength[vl];
            }
        }

        public ArraySegmentTree(char[] data)
        {
            s = data;
            n = s.Length;
            prefixLength = new int[4 * n];
            suffixLength = new int[4 * n];
            longestContinuous = new int[4 * n];
            Array.Fill(prefixLength, 1);
            Array.Fill(suffixLength, 1);
            Array.Fill(longestContinuous, 1);
            Build(1, 0, n - 1);
        }
    }
}
