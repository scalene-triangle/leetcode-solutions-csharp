namespace leetcode_solutions_csharp.Array_HashTable.Medium;

public class ValidSudoku
{
    /*
	* 36. Valid Sudoku
	* Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:
        Each row must contain the digits 1-9 without repetition.
        Each column must contain the digits 1-9 without repetition.
        Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
        Note:

        A Sudoku board (partially filled) could be valid but is not necessarily solvable.
        Only the filled cells need to be validated according to the mentioned rules.
	*/

    public void Run()
    {
        char[][] board1 = new char[][]
        {
            new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
            new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
            new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
            new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
            new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
            new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
            new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
            new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
            new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
        };

        char[][] board2 = new char[][]
        {
            new char[] { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
            new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
            new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
            new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
            new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
            new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
            new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
            new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
            new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
        };

        Console.WriteLine(Solution(board1)); // true
        Console.WriteLine(Solution(board2)); // false
    }

    // Time: O(1) Space: O(1)
    public bool Solution(char[][] board)
    {
        HashSet<char>[] row = new HashSet<char>[9];
        HashSet<char>[] col = new HashSet<char>[9];
        HashSet<char>[] box = new HashSet<char>[9];
        for (int i = 0; i < 9; i++)
        {
            row[i] = new HashSet<char>();
            col[i] = new HashSet<char>();
            box[i] = new HashSet<char>();
        }

        for (int r = 0; r < board.Length; r++)
        {
            for (int c = 0; c < board[r].Length; c++)
            {
                char elem = board[r][c];
                if (elem == '.')
                {
                    continue;
                }

                if (!row[r].Add(elem))
                {
                    return false;
                }

                if (!col[c].Add(elem))
                {
                    return false;
                }

                int b = (3 * (r / 3)) + (c / 3);
                if (!box[b].Add(elem))
                {
                    return false;
                }
            }
        }

        return true;
    }

    // Solution2
    public bool Solution2(char[][] board)
    {
        var rows = new HashSet<(int, int)>();
        var columns = new HashSet<(int, int)>();
        var subBoxes = new HashSet<(int, int, int)>();

        for (var ri = 0; ri < 9; ri++)
        {
            for (var ci = 0; ci < 9; ci++)
            {
                if (board[ri][ci] == '.')
                    continue;

                if (!rows.Add((ri, board[ri][ci])) ||
                   !columns.Add((ci, board[ri][ci])) ||
                   !subBoxes.Add((ri / 3, ci / 3, board[ri][ci])))
                    return false;
            }
        }

        return true;
    }
}
