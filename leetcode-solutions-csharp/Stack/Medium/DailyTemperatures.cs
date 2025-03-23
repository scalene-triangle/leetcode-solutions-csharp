using leetcode_solutions_csharp.Utils.Helpers;

namespace leetcode_solutions_csharp.Stack.Medium;

public class DailyTemperatures
{
	/*
	 * 739. Daily Temperatures
	 * Given an array of integers temperatures represents the daily temperatures, return an array answer such that answer[i] is the number of days you have to wait after the ith day to get a warmer temperature. If there is no future day for which this is possible, keep answer[i] == 0 instead.
	 */

	public void Run()
	{
		var input1 = new int[] { 73, 74, 75, 71, 69, 72, 76, 73 };
		var input2 = new int[] { 30, 40, 50, 60 };
		var input3 = new int[] { 30, 60, 90 };
		Console.WriteLine(ToStringHelper.NestedListToString(Solution(input1))); // [1,1,4,2,1,1,0,0]
		Console.WriteLine(ToStringHelper.NestedListToString(Solution(input2))); // [1,1,1,0]
		Console.WriteLine(ToStringHelper.NestedListToString(Solution(input3))); // [1,1,0]
	}

	public int[] Solution(int[] temps)
	{
		int[] results = new int[temps.Length];
		Stack<int> stack = new Stack<int>();

		for (int i = 0; i < temps.Length; i++)
		{
			while (stack.Count > 0 && temps[stack.Peek()] < temps[i])
			{
				int index = stack.Pop();
				results[index] = i - index;
			}
			stack.Push(i);
		}

		return results;
	}
}
