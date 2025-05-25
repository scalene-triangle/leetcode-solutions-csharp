namespace leetcode_solutions_csharp.SlidingWindow.Hard;

public class BestTimeToBuyAndSellStockIV
{
    /*
    * 188. Best Time to Buy and Sell Stock IV
    * You are given an integer k and an array of integers prices where prices[i] is the price of a given stock on the ith day.
    * Find the maximum profit you can achieve. You may complete at most k transactions.
    * Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).
    */

    public void Run()
    {
        Console.WriteLine(Solution(2, new int[] { 2, 4, 1 })); // 2
        Console.WriteLine(Solution(2, new int[] { 3, 2, 6, 5, 0, 3 })); // 7
    }

    public int Solution(int k, int[] prices)
    {
        if (prices.Length == 0 || k == 0) return 0;
        if (k > prices.Length / 2) return MaxProfit(prices);
        int[,] dp = new int[prices.Length + 1, k + 1];
        for (int i = 1; i <= prices.Length; i++)
        {
            for (int j = 1; j <= k; j++)
            {
                int maxDiff = int.MinValue;
                for (int m = 0; m < i; m++)
                {
                    maxDiff = Math.Max(maxDiff, dp[m, j - 1] - prices[m]);
                }
                dp[i, j] = Math.Max(dp[i - 1, j], prices[i - 1] + maxDiff);
            }
        }
        return dp[prices.Length, k];
    }

    private int MaxProfit(int[] prices)
    {
        int maxProfit = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] > prices[i - 1])
            {
                maxProfit += prices[i] - prices[i - 1];
            }
        }
        return maxProfit;
    }

    public int Solution2(int k, int[] prices)
    {
        return Recursive(prices, 0, true, k);
    }

    public int Recursive(int[] p, int ind, bool b, int k)
    {
        if (ind >= p.Length || k <= 0)
            return 0;

        int ans = 0;

        if (b)
        {
            return Math.Max(-p[ind] + Recursive(p, ind + 1, !b, k), Recursive(p, ind + 1, b, k));
        }
        else
        {
            return Math.Max(p[ind] + Recursive(p, ind + 1, !b, k - 1), Recursive(p, ind + 1, b, k));
        }
    }
}
