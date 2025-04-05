using leetcode_solutions_csharp.Utils.Helpers;

namespace leetcode_solutions_csharp.Array_HashTable.Medium;

public class TopKFrequentElements
{
    /*
     347. Top K Frequent Elements - https://leetcode.com/problems/top-k-frequent-elements/description/
     Given an integer array nums and an integer k, return the k most frequent elements within the array.
     The test cases are generated such that the answer is always unique.
     You may return the output in any order.
     */
    public void Run()
    {
        var result1 = Solution(new int[] { 1, 1, 1, 2, 2, 3 }, 2);
        var result2 = Solution(new int[] { 1 }, 1);

        Console.WriteLine(ToStringHelper.NestedListToString(result1)); // [1, 2]
        Console.WriteLine(ToStringHelper.NestedListToString(result2)); // [1]
    }

    public int[] Solution(int[] nums, int k)
    {
        return nums.GroupBy(num => num)
        .OrderByDescending(num => num.Count())
        .Take(k)
        .Select(c => c.Key)
        .ToArray();
    }
}
