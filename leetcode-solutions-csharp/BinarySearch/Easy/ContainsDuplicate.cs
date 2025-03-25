using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_solutions_csharp.BinarySearch.Easy;

public class ContainsDuplicate
{
    /*
	* 217. Contains Duplicate
	* Given an integer array nums, return true if any value appears more than once in the array, otherwise return false.
	*/

    public void Run()
    {
        Console.WriteLine(Solution(new int[] { 1, 2, 3, 1 })); // true
        Console.WriteLine(Solution(new int[] { 1, 2, 3, 4 })); // false
        Console.WriteLine(Solution(new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 })); // true
        Console.WriteLine(Solution(new int[] { 4, 2, 1 })); // 1
    }

    public bool Solution(int[] nums)
    {
        return new HashSet<int>(nums).Count < nums.Length;
    }
}
