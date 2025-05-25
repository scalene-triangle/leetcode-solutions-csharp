namespace leetcode_solutions_csharp.BinarySearch.Hard;

public class MedianOfTwoSortedArrays
{
    /*
	* 4. Median of Two Sorted Arrays
	* Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
        The overall run time complexity should be O(log (m+n)).
	*/

    public void Run()
    {
        Console.WriteLine(Solution2(new int[] { 1, 3 }, new int[] { 2 })); // 2.00000
        Console.WriteLine(Solution2(new int[] { 1, 2 }, new int[] { 2, 4 })); // 2.50000
    }

    public double Solution(int[] nums1, int[] nums2)
    {
        List<int> merged = new List<int>();
        int i = 0, j = 0;

        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] < nums2[j])
            {
                merged.Add(nums1[i++]);
            }
            else
            {
                merged.Add(nums2[j++]);
            }
        }

        while (i < nums1.Length) merged.Add(nums1[i++]);
        while (j < nums2.Length) merged.Add(nums2[j++]);

        int mid = merged.Count / 2;
        if (merged.Count % 2 == 0)
        {
            return (merged[mid - 1] + merged[mid]) / 2.0;
        }
        else
        {
            return merged[mid];
        }
    }

    public double Solution2(int[] nums1, int[] nums2)
    {
        int[] ans = nums1.Concat(nums2).OrderBy(x => x).ToArray();
        int n = ans.Length;
        decimal medianSorted;
        if (n % 2 != 0) medianSorted = ans[n / 2];
        else medianSorted = Decimal.Divide((ans[n / 2] + ans[(n - 1) / 2]), 2);
        return Convert.ToDouble(medianSorted);
    }
}
