using leetcode_solutions_csharp.Utils.Helpers;

namespace leetcode_solutions_csharp.Stack.Medium;

public class GenerateParentheses
{
    /*
     * 22. Generate Parentheses
     * Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
     */

    public void Run()
    {
        Console.WriteLine(PrintHelper.PrintNestedList(Solution(3))); // ["((()))","(()())","(())()","()(())","()()()"]
        Console.WriteLine(PrintHelper.PrintNestedList(Solution(1))); // ["()"]
    }

    public IList<string> Solution(int n)
    {
        var result = new List<string>();
        GenerateCombinations(result, "", 0, 0, n);
        return result;
    }

    private void GenerateCombinations(IList<string> result, string current, int open, int close, int max)
    {
        if (current.Length == max * 2)
        {
            result.Add(current);
            return;
        }

        if (open < max)
        {
            GenerateCombinations(result, current + "(", open + 1, close, max);
        }

        if (close < open)
        {
            GenerateCombinations(result, current + ")", open, close + 1, max);
        }
    }
}
