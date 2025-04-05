namespace leetcode_solutions_csharp.Array_HashTable.Easy;

public class ContainsDuplicate
{
    /**
    * 217. Contains Duplicate
    * Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
    */

    public void Run()
    {
      Console.WriteLine(Solution(new int[] { 1, 2, 3, 1 })); // true
      Console.WriteLine(Solution(new int[] { 1, 2, 3, 4 })); // false
      Console.WriteLine(Solution(new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 })); // true
    }

    public bool Solution(int[] nums)
    {
      HashSet<int> hashSet = new HashSet<int>();

      foreach (int item in hashSet)
      {
        if (hashSet.Contains(item))
        {
          return true;
        }

        hashSet.Add(item);
      }

      return false;
    }
}
