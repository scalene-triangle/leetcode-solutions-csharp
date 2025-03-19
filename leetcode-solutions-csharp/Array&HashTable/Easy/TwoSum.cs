using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_solutions_csharp.Array_HashTable.Easy
{
    /**
	 1. Two Sum
	 Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target. You may assume that each input would have exactly one solution, and you may not use the same element twice. You can return the answer in any order.
	 */

    public class TwoSum
	{
		public void Run()
		{
			Console.WriteLine(Solution(new int[] { 2, 7, 11, 15 }, 9)); // [0,
		}

		public int[] Solution(int[] nums, int target)
		{

			var numMap = new Dictionary<int, int>();
			var result = new int[2];

			for (var i = 0; i < nums.Length; i++)
			{
				var rightNum = target - nums[i];
				if (!numMap.ContainsKey(rightNum))
				{
					numMap[nums[i]] = i;
					rightNum = 0;
				}
				else
				{
					result[0] = numMap[rightNum];
					result[1] = i;
					return result;
				}
			}

			return result;
		}
	}
}
