namespace leetcode_solutions_csharp.BinarySearch.Medium;

internal class KokoEatingBananas
{
    /*
	* 875. Koko Eating Bananas
	* Koko loves to eat bananas. There are n piles of bananas, the ith pile has piles[i] bananas. The guards have gone and will come back in h hours.
      Koko can decide her bananas-per-hour eating speed of k. Each hour, she chooses some pile of bananas and eats k bananas from that pile. If the pile has less than k bananas, she eats all of them instead and will not eat any more bananas during this hour.

      Koko likes to eat slowly but still wants to finish eating all the bananas before the guards return.

      Return the minimum integer k such that she can eat all the bananas within h hours.
	*/

    public void Run()
    {
        Console.WriteLine(Solution(new int[] { 3, 6, 7, 11 }, 8)); // 4
        Console.WriteLine(Solution(new int[] { 30, 11, 23, 4, 20 }, 5)); // 30
        Console.WriteLine(Solution(new int[] { 30, 11, 23, 4, 20 }, 6)); // 23
    }

    public int Solution(int[] piles, int h)
    {
        int left = 1,
            right = piles.Max();
        int result = right;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;

            int hours = 0;
            foreach (int pile in piles)
            {
                hours += (int)Math.Ceiling((double)pile / (double)middle);
            }

            if (hours < 0) break;

            if (hours <= h)
            {
                result = Math.Min(result, middle);
                Console.WriteLine($"{hours} and {middle}: {result}");
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }

        return result;
    }

    public int Solution2(int[] piles, int h)
    {
        int left = 1;
        int right = piles.Max();

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (CanEatAll(piles, h, mid))
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }

    private bool CanEatAll(int[] piles, int h, int k)
    {
        long hours = 0;
        foreach (int pile in piles)
        {
            hours += (pile + k - 1) / k;
            if (hours > h)
            {
                return false;
            }
        }
        return true;
    }
}
