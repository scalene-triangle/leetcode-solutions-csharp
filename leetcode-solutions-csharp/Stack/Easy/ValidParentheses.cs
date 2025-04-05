namespace leetcode_solutions_csharp.Stack.Easy;

public class ValidParentheses
{
    /*
     * 20. Valid Parentheses
     * Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
        1. Open brackets must be closed by the same type of brackets.
        2. Open brackets must be closed in the correct order.
        3. Every close bracket has a corresponding open bracket of the same type.
     */

    public void Run()
    {
        var result1 = Solution("()");
        var result2 = Solution("()[]{}");
        var result3 = Solution("(]");
        var result4 = Solution("([])");

        Console.WriteLine($"(): {result1}"); // true
        Console.WriteLine($"()[]{{}}: {result2}"); // true
        Console.WriteLine($"(]: {result3}"); // false
        Console.WriteLine($"([]): {result4}"); // true

    }

    public bool Solution(string s)
    {
        // Get ready initial state (enforce element type)
        var k = new Stack<char>();
        // Evaluate each character for potential mismatch 
        foreach (char c in s)
        {
            // Push closing round bracket onto the stack
            if (c == '(') { k.Push(')'); continue; }
            // Push closing curly bracket onto the stack
            if (c == '{') { k.Push('}'); continue; }
            // Push closing square bracket onto the stack
            if (c == '[') { k.Push(']'); continue; }
            // Look out for imbalanced strings or mismatches
            if (k.Count == 0 || c != k.Pop()) return false;
        }
        // Empty stack means string is valid and invalid otherwise
        return k.Count == 0;
    }

    public bool Solution2(string s)
    {
        while (s.Contains("()") || s.Contains("[]") || s.Contains("{}"))
        {
            s = s.Replace("()", "").Replace("[]", "").Replace("{}", "");
        }

        return s.Length == 0;
    }

    // Stack O(n)
    public bool Solution3(string s)
    {
        Dictionary<char, char> bracketsMap = new Dictionary<char, char>{
            {'{',  '}'},
            {'(',  ')'},
            {'[',  ']'},
        };
        Stack<char> openBrackets = new Stack<char>();

        foreach (char bracket in s)
        {
            if (bracketsMap.ContainsKey(bracket))
            {
                openBrackets.Push(bracket);
            }
            else
            {
                if (openBrackets.Count == 0)
                {
                    return false;
                }
                if (bracketsMap[openBrackets.Pop()] == bracket)
                {
                    continue;
                };
                return false;
            }
        }
        return openBrackets.Count == 0;
    }
}
