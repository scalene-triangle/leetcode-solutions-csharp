﻿namespace leetcode_solutions_csharp.BinarySearch.Medium;

public class SearchInRotatedSortedArrayII
{
    /*
	* 81. Search in Rotated Sorted Array II
	* There is an integer array nums sorted in non-decreasing order (not necessarily with distinct values).
        Before being passed to your function, nums is rotated at an unknown pivot index k (0 <= k < nums.length) such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). For example, [0,1,2,4,4,4,5,6,6,7] might be rotated at pivot index 5 and become [4,5,6,6,7,0,1,2,4,4].

        Given the array nums after the rotation and an integer target, return true if target is in nums, or false if it is not in nums.

        You must decrease the overall operation steps as much as possible.
	*/

    public void Run()
    {
        Console.WriteLine(Solution(new int[] { 2, 5, 6, 0, 0, 1, 2 }, 0)); // true
        Console.WriteLine(Solution(new int[] { 2, 5, 6, 0, 0, 1, 2 }, 3)); // false
    }

    public bool Solution(int[] nums, int target)
    {
        int low = 0, high = nums.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (nums[mid] == target) return true;

            if (nums[low] == nums[mid])
            {
                low++;
                continue;
            }

            if (nums[low] <= nums[mid])
            {
                if (nums[low] <= target && target <= nums[mid]) high = mid - 1;
                else low = mid + 1;
            }
            else
            {
                if (nums[mid] <= target && target <= nums[high]) low = mid + 1;
                else high = mid - 1;
            }
        }
        return false;
    }
}
