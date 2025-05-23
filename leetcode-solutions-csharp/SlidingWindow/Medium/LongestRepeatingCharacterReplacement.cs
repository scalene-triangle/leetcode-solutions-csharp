namespace leetcode_solutions_csharp.SlidingWindow.Medium;

public class LongestRepeatingCharacterReplacement
{
    /*
     * 424. Longest Repeating Character Replacement
     * You are given a string s and an integer k. You can replace any character in s with any other character
     * up to k times in total. Find the length of the longest substring containing the same letter you can get
     * after performing at most k replacements.
     */

    public void Run()
    {
        Console.WriteLine(Solution("AABABBA", 1)); // 4
        Console.WriteLine(Solution("AABABBA", 2)); // 5
        Console.WriteLine(Solution("AABABBA", 0)); // 2
    }

    public int Solution(string s, int k)
    {
        var letters = new Dictionary<char, int>();
        int maxCount = 0, left = 0, right;
        for (right = 0; right < s?.Length; right++)
        {
            char letter = s[right];
            letters[letter] = letters.GetValueOrDefault(letter) + 1;
            maxCount = Math.Max(maxCount, letters[letter]);
            if (right - left + 1 - maxCount > k)
            {
                letters[s[left]]--;
                left++;
            }
        }
        return right - left;
    }
}
