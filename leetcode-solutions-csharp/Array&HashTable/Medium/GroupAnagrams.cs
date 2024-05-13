using System;
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
            Console.WriteLine(NestedListToString(result1)); // [["bat"],["nat","tan"],["ate","eat","tea"]]
            Console.WriteLine(NestedListToString(result2)); // [[""]]
            Console.WriteLine(NestedListToString(result3)); // [["a"]]
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

        static string NestedListToString(IList<IList<string>> nestedList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (var innerList in nestedList)
            {
                sb.Append("[");
                foreach (var item in innerList)
                {
                    sb.AppendFormat("\"{0}\",", item);
                }
                sb.Length--;
                sb.Append("],");
            }
            sb.Length--;
            sb.Append("]");

            return sb.ToString();
        }
    }
}
