namespace leetcode_solutions_csharp.BinarySearch.Hard;

public class FindMinimumInRotatedSortedArrayII
{
    /*
	* 154. Find Minimum in Rotated Sorted Array II
	* Suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, the array nums = [0,1,4,4,5,6,7] might become:
        - [4,5,6,7,0,1,4] if it was rotated 4 times.
        - [0,1,4,4,5,6,7] if it was rotated 7 times.
        Notice that rotating an array [nums[0], nums[1], nums[2], ..., nums[n-1]] 1 time results in the array [nums[n-1], nums[0], nums[1], nums[2], ..., nums[n-2]].

        Given the sorted rotated array nums that may contain duplicates, return the minimum element of this array.

        You must decrease the overall operation steps as much as possible.
	*/

    public void Run()
    {
        Console.WriteLine(Solution(new int[] { 1, 3, 5 })); // 1
        Console.WriteLine(Solution(new int[] { 2, 2, 2, 0, 1 })); // 0
    }

    public int Solution(int[] nums)
    {
        int left = 0, right = nums.Length - 1;
        int res = Int32.MaxValue;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            res = Math.Min(res, nums[mid]);
            if (nums[mid] > nums[right])
                left = mid + 1;
            else if (nums[mid] < nums[right])
                right = mid - 1;
            else if (nums[mid] == nums[right])
                right--;
        }
        return res;
    }

    public int Solution2(int[] nums)
    {
        return BST(nums, 0, nums.Length - 1);
    }
    private int BST(int[] nums, int left, int right)
    {
        int mid;
        if (nums[right] > nums[left])
            return nums[left];
        while (left < right)
        {
            mid = left + (right - left) / 2;
            if (nums[right] == nums[mid])
            {
                int v1 = BST(nums, left, mid), v2 = BST(nums, mid + 1, right);
                return Math.Min(v1, v2);
            }
            else if (nums[right] < nums[mid])
                left = mid + 1;
            else
                right = mid;
        }
        return nums[left];
    }
}
