using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_solutions_csharp.TwoPointers.Hard;

public class TrappingRainWaterII
{
    /*
	* 407. Trapping Rain Water II
	* Given an m x n integer matrix heightMap representing the height of each unit cell in a 2D elevation map, return the volume of water it can trap after raining.
	*/

    public void Run()
    {
        int[][] heightMap = new int[][]
        {
            new int[] { 1,4,3,1,3,2 },
            new int[] { 3,2,1,3,2,4 },
            new int[] { 2,3,3,2,3,1 }
        };

        int[][] heightMap2 = new int[][]
        {
            new int[] { 3,3,3,3,3 },
            new int[] { 3,2,2,2,3 },
            new int[] { 3,2,1,2,3 },
            new int[] { 3,2,2,2,3 },
            new int[] { 3, 3, 3, 3, 3 }
        };

        Console.WriteLine(Solution(heightMap)); // 4
        Console.WriteLine(Solution(heightMap2)); // 10
    }

    class Point
    {
        public int x;
        public int y;
        public int val;
        public Point(int _x, int _y, int _val)
        {
            x = _x;
            y = _y;
            val = _val;
        }
    }

    public int Solution(int[][] heightMap)
    {
        int m = heightMap.Length, n = heightMap[0].Length;
        PriorityQueue<Point, int> pq = new(Comparer<int>.Create((a, b) => a.CompareTo(b)));
        // add boundry
        for (int r = 0; r < m; r++)
        {
            pq.Enqueue(new Point(r, 0, heightMap[r][0]), heightMap[r][0]);
            pq.Enqueue(new Point(r, n - 1, heightMap[r][n - 1]), heightMap[r][n - 1]);
            heightMap[r][n - 1] = -1;
            heightMap[r][0] = -1;
        }
        for (int c = 1; c < n - 1; c++)
        {
            pq.Enqueue(new Point(0, c, heightMap[0][c]), heightMap[0][c]);
            pq.Enqueue(new Point(m - 1, c, heightMap[m - 1][c]), heightMap[m - 1][c]);
            heightMap[0][c] = -1;
            heightMap[m - 1][c] = -1;
        }

        Tuple<int, int>[] dir = new Tuple<int, int>[]
        {Tuple.Create(0,1), Tuple.Create(0,-1),Tuple.Create(1,0),Tuple.Create(-1,0)};
        int res = 0;
        while (pq.Count > 0)
        {
            var boundary = pq.Dequeue();
            for (int i = 0; i < dir.Length; i++)
            {
                int x = boundary.x + dir[i].Item1, y = boundary.y + dir[i].Item2;
                if (x < 0 || x >= m || y < 0 || y >= n || heightMap[x][y] == -1) continue;
                res += Math.Max(0, boundary.val - heightMap[x][y]);
                Point newBoundary = new Point(x, y, Math.Max(heightMap[x][y], boundary.val));
                pq.Enqueue(newBoundary, newBoundary.val);
                heightMap[x][y] = -1;
            }
        }

        return res;
    }
}
