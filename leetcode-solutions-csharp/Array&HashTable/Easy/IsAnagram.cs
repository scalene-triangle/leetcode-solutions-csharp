using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace leetcode_solutions_csharp.Array_HashTable.Easy
{
	/**
	 * 242。 Valid Anagram
	 */

	/**
	 * "b" is string but 'b' is char
	 * so "b" - "a" returns error CS0019: Operator '-' cannot be applied to operands of type 'string' and 'string'
	 * but 'b' - 'a' returns 1
	 */

	public class IsAnagram
	{
		public void Run()
		{
			Console.WriteLine(Solution("anagram", "nagaram")); // true
			Console.WriteLine(Solution("rat", "car")); // false
		}

		public bool Solution(string s, string t)
		{
			if (s.Length != t.Length)
			{
				return false;
			}

			int[] saphabet = new int[26];
			foreach (char c in s)
				saphabet[c - 'a']++;
			

			foreach (char c in t)
			{
				if (saphabet[c - 'a'] > 0)
					saphabet[c - 'a']--;
				
				else
					return false;
			}

			return true;
		}
	}
}
