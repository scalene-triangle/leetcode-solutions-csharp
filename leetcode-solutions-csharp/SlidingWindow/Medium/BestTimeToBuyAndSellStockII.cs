namespace leetcode_solutions_csharp.SlidingWindow.Medium;

public class BestTimeToBuyAndSellStockII
{
    /*
    * 122. Best Time to Buy and Sell Stock II
    * You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
    * You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times).
    * However, you may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).
    */

    public void Run()
    {
        Console.WriteLine(Solution(new int[] { 7, 1, 5, 3, 6, 4 })); // 7
        Console.WriteLine(Solution(new int[] { 1, 2, 3, 4, 5 })); // 4
        Console.WriteLine(Solution(new int[] { 7, 6, 4, 3, 1 })); // 0
    }

    public int Solution(int[] prices)
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

    public int Solution2(int[] prices)
    {
        int max = 0;
        int start = prices[0];
        int len = prices.Length;
        for (int i = 1; i < len; i++)
        {
            if (start < prices[i])
            {
                max += prices[i] - start;
            }
            start = prices[i];
        }
        return max;
    }
}
