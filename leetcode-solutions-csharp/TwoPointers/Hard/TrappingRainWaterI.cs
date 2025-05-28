using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_solutions_csharp.TwoPointers.Hard;

public class TrappingRainWaterI
{
    /*
	* 42. Trapping Rain Water
	* Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.
	*/

    public void Run()
    {
        Console.WriteLine(Solution(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 })); // 6
        Console.WriteLine(Solution(new int[] { 4, 2, 0, 3, 2, 5 })); // 9
    }

    public int Solution(int[] height)
    {
        int total = 0, l = 0, r = height.Length - 1;
        int lmax = 0, rmax = height[r];

        while (l < r)
        {
            if (height[l] <= height[r])
            {
                if (height[l] < lmax)
                {
                    total += lmax - height[l];
                }
                else
                {
                    lmax = height[l];
                }
                l++;
            }
            else
            {
                if (height[r] < rmax)
                {
                    total += rmax - height[r];
                }
                else
                {
                    rmax = height[r];
                }
                r--;
            }
        }
        return total;
    }
}
