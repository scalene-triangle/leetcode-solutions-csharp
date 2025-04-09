namespace leetcode_solutions_csharp.Array_HashTable.Medium;

public class LongestConsecutive
{

    /*
	* 128. Longest Consecutive Sequence
	* Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.
      You must write an algorithm that runs in O(n) time.
	*/

    public void Run()
    {
        Console.WriteLine(Solution(new int[] { 100, 4, 200, 1, 3, 2 })); // 4
        Console.WriteLine(Solution(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 })); // 9
        Console.WriteLine(Solution(new int[] { 1, 0, 1, 2 })); // 3
        Console.WriteLine(Solution(new int[] { 2, 20, 4, 10, 3, 4, 5 })); // 4
        Console.WriteLine(Solution(new int[] { 0, 3, 2, 5, 4, 6, 1, 1 })); // 7
    }

    public int Solution(int[] nums)
    {
        HashSet<int> set = new HashSet<int>(nums);
        int maxLength = 0;

        foreach (int num in nums)
        {
            if (set.Contains(num - 1)) continue;

            int length = 0;
            while (set.Contains(num + length)) length++;

            maxLength = Math.Max(maxLength, length);
        }

        return maxLength;
    }

    public int Solution2(int[] nums)
    {
        int res = 0;
        HashSet<int> store = new HashSet<int>(nums);

        foreach (int num in nums)
        {
            int streak = 0, curr = num;
            while (store.Contains(curr))
            {
                streak++;
                curr++;
            }
            res = Math.Max(res, streak);
        }
        return res;
    }
}
