namespace leetcode_solutions_csharp.SlidingWindow.Medium;

public class LongestSubstringWithoutRepeatingCharacters
{
    /*
     * 3. Longest Substring Without Repeating Characters
     * Given a string s, find the length of the longest substring without duplicate characters.
     */
    public void Run()
    {
        Console.WriteLine(Solution("abcabcbb")); // 3
        Console.WriteLine(Solution("bbbbb")); // 1
        Console.WriteLine(Solution("pwwkew")); // 3
    }
    public int Solution(string s)
    {
        var letters = new Dictionary<char, int>();
        int maxCount = 0, left = 0, right;

        for (right = 0; right < s?.Length; right++)
        {
            char letter = s[right];

            if (letters.ContainsKey(letter))
            {
                left = Math.Max(left, letters[letter] + 1);
            }

            letters[letter] = right;

            maxCount = Math.Max(maxCount, right - left + 1);
        }

        return maxCount;
    }
}
