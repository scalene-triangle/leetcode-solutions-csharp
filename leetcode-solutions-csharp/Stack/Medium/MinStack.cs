using leetcode_solutions_csharp.Utils.Helpers;

namespace leetcode_solutions_csharp.Stack.Medium;

public class MinStack
{
    /*
     155. Min Stack
     Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
        Implement the MinStack class:
        - MinStack() initializes the stack object.
        - void push(int val) pushes the element val onto the stack.
        - void pop() removes the element on the top of the stack.
        - int top() gets the top element of the stack.
        - int getMin() retrieves the minimum element in the stack.
        - You must implement a solution with O(1) time complexity for each function.
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

        Console.WriteLine(PrintHelper.PrintNestedList(minStack));
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
