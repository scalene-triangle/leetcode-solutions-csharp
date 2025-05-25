namespace leetcode_solutions_csharp.SlidingWindow.Hard;

public class BestTimeToBuyAndSellStockIII
{
    /*
     * 123. Best Time to Buy and Sell Stock III
     * You are given an array prices where prices[i] is the price of a given stock on the ith day.
     * Find the maximum profit you can achieve. You may complete at most two transactions.
     * Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).
     */
    public void Run()
    {
        Console.WriteLine(Solution(new int[] { 3, 3, 5, 0, 0, 3, 1, 4 })); // 6
        Console.WriteLine(Solution(new int[] { 1, 2, 3, 4, 5 })); // 4
        Console.WriteLine(Solution(new int[] { 7, 6, 4, 3, 1 })); // 0
    }
    public int Solution(int[] prices)
    {
        int n = prices.Length;
        if (n < 2) return 0;
        int maxProfit = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    for (int l = k + 1; l < n; l++)
                    {
                        maxProfit = Math.Max(maxProfit, prices[l] - prices[k] + prices[j] - prices[i]);
                    }
                }
            }
        }
        return maxProfit;
    }

    public int Solution2(int k, int[] prices)
    {
        return Recursive(prices, 0, true, k);
    }

    private int Recursive(int[] p, int ind, bool b, int k)
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
