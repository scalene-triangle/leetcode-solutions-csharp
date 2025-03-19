using leetcode_solutions_csharp.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_solutions_csharp.Stack.Medium;

public class MinStack
{
    /*
     * 155. Min Stack
     */

    public void Run()
    {
        var input1 = new List<string> { "MinStack", "push", "push", "push", "getMin", "pop", "top", "getMin" };
        var input2 = new List<List<int>>
        {
            new List<int>(),          // []
            new List<int> { -2 },     // [-2]
            new List<int> { 0 },      // [0]
            new List<int> { -3 },     // [-3]
            new List<int>(),          // []
            new List<int>(),          // []
            new List<int>(),          // []
            new List<int>()           // []
        };

        MinStack minStack = new MinStack();
        minStack.Push(-2);
        minStack.Push(0);
        minStack.Push(-3);
        minStack.GetMin(); // return -3
        minStack.Pop();
        minStack.Top();    // return 0
        minStack.GetMin(); // return -2

        // todo: log the result of each step
        Console.WriteLine(ToStringHelper.NestedListToString(minStack));
    }

    Stack<(int val, int minVal)> stack;
    int minVal = int.MaxValue;
    public MinStack()
    {
        stack = new Stack<(int, int)>();
    }

    public void Push(int val)
    {
        if (minVal > val)
        {
            minVal = val;
        }
        stack.Push((val, minVal));
    }

    public void Pop()
    {
        stack.Pop();
        if (stack.Count > 0)
        {
            minVal = stack.Peek().minVal;
        }
        else
        {
            minVal = int.MaxValue;
        }
    }

    public int Top()
    {
        return stack.Peek().val;
    }

    public int GetMin()
    {
        return stack.Peek().minVal;
    }
}
