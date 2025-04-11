namespace leetcode_solutions_csharp.BinarySearch.Easy;

internal class BinarySearchBinarySearch
{
    /*
	* 704. Binary Search
	* Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.
      You must write an algorithm with O(log n) runtime complexity.
	*/

    public void Run()
    {
        Console.WriteLine(Solution(new int[] { -1, 0, 3, 5, 9, 12 }, 9)); // 4
        Console.WriteLine(Solution(new int[] { -1, 0, 3, 5, 9, 12 }, 2)); // -1
    }

    public int Solution(int[] nums, int target)
    {
        int i = Array.BinarySearch(nums, target);
        return (i < 0) ? -1 : i; // or use Math.Clamp
    }

    public int Solution2(int[] nums, int target)
    {
        int lo = 0;
        int hi = nums.Length - 1;

        while (lo <= hi)
        {
            int mid = lo + (hi - lo) / 2;

            if (nums[mid] == target)
                return mid;

            if (nums[mid] > target)
                hi = mid - 1;
            else
                lo = mid + 1;
        }

        return -1;
    }
}
