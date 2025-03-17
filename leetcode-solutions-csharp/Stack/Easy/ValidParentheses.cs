using leetcode_solutions_csharp.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_solutions_csharp.Stack.Easy;

public class ValidParentheses
{
    /*
     * 20. Valid Parentheses
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
}
