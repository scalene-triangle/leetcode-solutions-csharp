using leetcode_solutions_csharp.Utils.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_solutions_csharp.Array_HashTable.Medium
{
    /*
     * 49. Group Anagrams
     */
    public class GroupAnagrams
    {
        public void Run()
        {
            var result1 = Solution(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
            var result2 = Solution(new string[] { "" });
            var result3 = Solution(new string[] { "a" });
            Console.WriteLine(ToStringHelper.NestedListToString(result1)); // [["bat"],["nat","tan"],["ate","eat","tea"]]
            Console.WriteLine(ToStringHelper.NestedListToString(result2)); // [[""]]
            Console.WriteLine(ToStringHelper.NestedListToString(result3)); // [["a"]]
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
}
