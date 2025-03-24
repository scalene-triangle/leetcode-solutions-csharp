namespace leetcode_solutions_csharp.Stack.Medium;

public class CarFleet
{
    /*
	* 853. Car Fleet
	* There are n cars at given miles away from the starting mile 0, traveling to reach the mile target.

		You are given two integer array position and speed, both of length n, where position[i] is the starting mile of the ith car and speed[i] is the speed of the ith car in miles per hour.

		A car cannot pass another car, but it can catch up and then travel next to it at the speed of the slower car.

		A car fleet is a car or cars driving next to each other. The speed of the car fleet is the minimum speed of any car in the fleet.

		If a car catches up to a car fleet at the mile target, it will still be considered as part of the car fleet.

		Return the number of car fleets that will arrive at the destination.
	*/

    public void Run()
    {
        Console.WriteLine(Solution(10, new int[] { 3 }, new int[] { 3 })); // 1
        Console.WriteLine(Solution(12, new int[] { 10, 8, 0, 5, 3 }, new int[] { 2, 4, 1, 1, 3 })); // 3
        Console.WriteLine(Solution(10, new int[] { 6, 8 }, new int[] { 3, 2 })); // 2
        Console.WriteLine(Solution(100, new int[] { 0, 2, 4 }, new int[] { 4, 2, 1 })); // 1
    }

    public int Solution(int target, int[] position, int[] speed)
    {
        int n = speed.Length;
        List<(int, int)> v = new List<(int, int)>();

        for (int i = 0; i < n; i++)
        {
            v.Add((position[i], speed[i]));
        }

        v.Sort();
        List<double> time = new List<double>();

        for (int i = 0; i < n; i++)
        {
            time.Add((target * 1.0 - v[i].Item1 * 1.0) / v[i].Item2 * 1.0);
        }

        double curr = double.MinValue;
        int res = 0;

        for (int i = n - 1; i >= 0; i--)
        {
            if (time[i] > curr)
            {
                curr = time[i];
                res++;
            }
        }

        return res;
    }
}
