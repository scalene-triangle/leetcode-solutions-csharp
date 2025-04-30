namespace leetcode_solutions_csharp.SlidingWindow.Easy;

public class BestTimeToBuyAndSellStockI
{
    /*
	* 121. Best Time to Buy and Sell Stock
	* You are given an array prices where prices[i] is the price of a given stock on the ith day.
        You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
        Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
	*/

    public void Run()
    {
        Console.WriteLine(Solution(new int[] { 7, 1, 5, 3, 6, 4 })); // 5
        Console.WriteLine(Solution(new int[] { 7, 6, 4, 3, 1 })); // 0
    }

    // Aproach 1: Dynamic Programming
    public int Solution(int[] prices)
    {
        int minPrice = int.MaxValue;
        int maxProfit = 0;

        foreach (int currentPrice in prices)
        {
            minPrice = Math.Min(currentPrice, minPrice);
            maxProfit = Math.Max(maxProfit, currentPrice - minPrice);
        }

        return maxProfit;
    }

    // Aproach 2: Two Pointers
    public int Solution2(int[] prices)
    {
        if (prices == null || prices.Length < 2)
        {
            return 0;
        }

        int maxProfit = 0;
        int leftBuy = 0;
        int rightSell = 1;

        while (rightSell < prices.Length)
        {
            int currentPrice = prices[rightSell];
            int buyPrice = prices[leftBuy];

            if (buyPrice < currentPrice)
            {
                int currentProfit = currentPrice - buyPrice;
                maxProfit = Math.Max(maxProfit, currentProfit);
            }
            else
            {
                leftBuy = rightSell;
            }

            rightSell++;
        }

        return maxProfit;
    }
}
