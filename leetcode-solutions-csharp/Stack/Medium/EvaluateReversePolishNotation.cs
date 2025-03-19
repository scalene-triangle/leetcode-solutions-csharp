using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_solutions_csharp.Stack.Medium;

public class EvaluateReversePolishNotation
{
    /*
     150. Evaluate Reverse Polish Notation
      
     Note that:
        The valid operators are '+', '-', '*', and '/'.
        Each operand may be an integer or another expression.
        The division between two integers always truncates toward zero.
        There will not be any division by zero.
        The input represents a valid arithmetic expression in a reverse polish notation.
        The answer and all the intermediate calculations can be represented in a 32-bit integer.
     */
    public void Run()
    {
        var input1 = new string[] { "2", "1", "+", "3", "*" };
        var input2 = new string[] { "4", "13", "5", "/", "+" };
        var input3 = new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };

        Console.WriteLine(Solution(input1));  // 9
        Console.WriteLine(Solution(input2));  // 6
        Console.WriteLine(Solution(input3));  // 22
    }

    private static Dictionary<string, Func<int, int, int>> s_Funcs = new() {
      { "+", (a, b) => a + b },
      { "-", (a, b) => b - a },
      { "*", (a, b) => a * b },
      { "/", (a, b) => b / a },
    };

    public int Solution(string[] tokens)
    {
        Stack<int> data = new();

        foreach (string token in tokens)
            if (int.TryParse(token, out int value))
                data.Push(value);
            else
                data.Push(s_Funcs[token](data.Pop(), data.Pop()));

        return data.Pop();
    }

    public int Solution2(string[] tokens)
    {
        Stack<int> stack = new();

        foreach (string token in tokens)
        {
            if (token is "+" or "-" or "*" or "/")
            {
                int right = stack.Pop();
                int left = stack.Pop();
                int result = token switch
                {
                    "+" => left + right,
                    "-" => left - right,
                    "*" => left * right,
                    "/" => left / right,
                    _ => throw new ArgumentOutOfRangeException(nameof(token))
                };
                stack.Push(result);
            }
            else
            {
                stack.Push(int.Parse(token));
            }
        }

        return stack.Pop();
    }
}
