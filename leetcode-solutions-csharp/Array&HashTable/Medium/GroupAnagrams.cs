﻿using leetcode_solutions_csharp.Utils.Helpers;

namespace leetcode_solutions_csharp.Array_HashTable.Medium;

public class GroupAnagrams
{
    /*
     * 49. Group Anagrams
     * Given an array of strings strs, group all anagrams together into sublists. You may return the output in any order. An anagram is a string that contains the exact same characters as another string, but the order of the characters can be different.
     */
    public void Run()
    {
        var result1 = Solution(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
        var result2 = Solution(new string[] { "" });
        var result3 = Solution(new string[] { "a" });
        Console.WriteLine(PrintHelper.PrintNestedList(result1)); // [["bat"],["nat","tan"],["ate","eat","tea"]]
        Console.WriteLine(PrintHelper.PrintNestedList(result2)); // [[""]]
        Console.WriteLine(PrintHelper.PrintNestedList(result3)); // [["a"]]
    }

    public IList<IList<string>> Solution(string[] strs)
    {
        Dictionary<string, IList<string>> anagrams = new Dictionary<string, IList<string>>();
        for (int i = 0; i < strs.Length; i++)
        {
            char[] arr = strs[i].ToCharArray();
            Array.Sort(arr);
            string sorted = new string(arr);
            if (anagrams.ContainsKey(sorted))
            {
                anagrams[sorted].Add(strs[i]);
            }
            else
            {
                anagrams.Add(sorted, new List<string>() { strs[i] });
            }
        }
        var result = anagrams.Values.ToList();
        return result;
    }
}
