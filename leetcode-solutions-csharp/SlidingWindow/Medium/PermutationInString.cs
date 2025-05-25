namespace leetcode_solutions_csharp.SlidingWindow.Medium;

public class PermutationInString
{
    /*
     * 567. Permutation in String
     * Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.
     * In other words, return true if one of s1's permutations is the substring of s2.
     */
    public void Run()
    {
        Console.WriteLine(CheckInclusion("ab", "eidbaooo")); // true
        Console.WriteLine(CheckInclusion("ab", "eidboaoo")); // false
    }
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;

        int[] bucket = new int[26];

        for (int i = 0; i < s1.Length; i++)
        {
            bucket[s1[i] - 'a']++;
            bucket[s2[i] - 'a']--;
        }

        if (IsValid(bucket))
            return true;

        for (int i = s1.Length; i < s2.Length; i++)
        {

            bucket[s2[i] - 'a']--;
            bucket[s2[i - s1.Length] - 'a']++;

            if (IsValid(bucket))
                return true;
        }

        return false;
    }

    public bool IsValid(int[] bucket)
    {

        for (int i = 0; i < 26; i++)
        {
            if (bucket[i] != 0)
            {
                return false;
            }
        }

        return true;
    }
}
