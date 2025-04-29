namespace leetcode_solutions_csharp.BinarySearch.Easy;

public class Search2DMatrixI
{
    /*
	* 74. Search a 2D Matrix
	* You are given an m x n integer matrix matrix with the following two properties:
        - Each row is sorted in non-decreasing order.
        - The first integer of each row is greater than the last integer of the previous row.
      Given an integer target, return true if target is in matrix or false otherwise.

      You must write a solution in O(log(m * n)) time complexity.
	*/

    public void Run()
    {
        int[][] matrix = new int[][]
        {
            new int[] { 1,3,5,7 },
            new int[] { 10,11,16,20 },
            new int[] { 23,30,34,60 }
        };

        Console.WriteLine(Solution(matrix, 3)); // true
        Console.WriteLine(Solution(matrix, 13)); // false
    }

    public bool Solution(int[][] matrix, int target)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        int left = 0, right = m * n - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int mid_val = matrix[mid / n][mid % n];

            if (mid_val == target)
                return true;
            else if (mid_val < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return false;
    }
}
