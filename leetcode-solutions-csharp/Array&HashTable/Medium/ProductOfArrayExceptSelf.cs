using leetcode_solutions_csharp.Utils.Helpers;

namespace leetcode_solutions_csharp.Array_HashTable.Medium;

public class ProductOfArrayExceptSelf
{
    /*
	* 238. Product of Array Except Self
	* Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
		The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
		You must write an algorithm that runs in O(n) time and without using the division operation.
	*/

    public void Run()
    {
        Console.WriteLine(PrintHelper.PrintNestedList(Solution(new int[] { 1, 2, 3, 4 }))); // [24,12,8,6]
        Console.WriteLine(PrintHelper.PrintNestedList(Solution(new int[] { -1, 1, 0, -3, 3 }))); // [0,0,9,0,0]
        Console.WriteLine(PrintHelper.PrintNestedList(Solution(new int[] { -1, 0, 1, 2, 3 }))); // [0,-6,0,0,0]
        Console.WriteLine(PrintHelper.PrintNestedList(Solution(new int[] { 1, 2, 4, 6 }))); // [48,24,12,8]
    }

    public int[] Solution(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n];
        Array.Fill(ans, 0);
        int product = 1;
        int zeros = 0;

        foreach (var num in nums)
        {
            if (num == 0)
            {
                zeros++;
                continue;
            }
            product *= num;
        }

        if (zeros == 1)
        {
            for (int i = 0; i < n; i++)
            {
                ans[i] = nums[i] == 0 ? product : 0;
            }
        }
        else if (zeros == 0)
        {
            for (int i = 0; i < n; i++)
            {
                ans[i] = product / nums[i];
            }
        }

        return ans;
    }

    // solution 2
    public int[] Solution2(int[] nums)
    {
        int[] product = new int[nums.Length];
        int num = 1, i;

        for (i = 0; i < nums.Length; i++)
        {
            product[i] = num;
            num *= nums[i];
        }
        num = 1;

        for (i = nums.Length - 1; i >= 0; i--)
        {
            product[i] *= num;
            num *= nums[i];
        }
        return product;
    }
}
