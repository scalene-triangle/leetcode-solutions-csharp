namespace leetcode_solutions_csharp.BinarySearch.Easy;

public class Search2DMatrixII
{
    /*
	* 240. Search a 2D Matrix II
	* Write an efficient algorithm that searches for a value target in an m x n integer matrix matrix. This matrix has the following properties:
        - Integers in each row are sorted in ascending from left to right.
        - Integers in each column are sorted in ascending from top to bottom.
	*/

    public void Run()
    {
        int[][] matrix = new int[][]
        {
            new int[] { 1,4,7,11,15 },
            new int[] { 2,5,8,12,19 },
            new int[] { 3, 6, 9, 16, 22 },
            new int[] { 10,13,14,17,24 },
            new int[] { 18, 21, 23, 26, 30 }
        };

        Console.WriteLine(Solution(matrix, 5)); // true
        Console.WriteLine(Solution(matrix, 20)); // false
    }

    // Brute force with time complexity O(M x N)
    public bool Solution(int[][] matrix, int target)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (matrix[i][j] == target)
                    return true;
            }
        }
        return false;
    }

    // Optimized the bruteforce approach to have O(M x N) time complexity where M can be less than actual row length depending on the target's location in matrix
    public bool Solution2(int[][] matrix, int target)
    {
        int rowEnd = matrix[0].Length;
        int columnEnd = matrix.Length;
        for (int j = 0; j < rowEnd; j++)
        {
            if (matrix[0][j] == target)
                return true;
            if (matrix[0][j] > target)
            {
                rowEnd = j;
                break;
            }
        }
        for (int j = 0; j < columnEnd; j++)
        {
            if (matrix[j][0] == target)
                return true;
            if (matrix[j][0] > target)
            {
                columnEnd = j;
                break;
            }
        }
        for (int i = 1; i < columnEnd; i++)
        {
            for (int j = 1; j < rowEnd; j++)
            {
                if (matrix[i][j] == target)
                    return true;
            }
        }
        return false;
    }

    // Optimized Code with the best time complexity of O(M + N) (thanks to discussion tab here)
    public bool Solution3(int[][] matrix, int target)
    {
        int column = matrix[0].Length - 1;
        int row = 0;
        while (column >= 0 && row < matrix.Length)
        {
            if (matrix[row][column] == target)
                return true;
            else if (matrix[row][column] > target)
                column--;
            else if (matrix[row][column] < target)
                row++;
        }
        return false;
    }
}