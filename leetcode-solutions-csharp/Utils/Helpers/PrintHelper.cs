using leetcode_solutions_csharp.Tree.Easy;
using System.Collections;
using System.Text;
using static leetcode_solutions_csharp.LinkedList.Easy.ReverseLinkedListI;
namespace leetcode_solutions_csharp.Utils.Helpers;

public class PrintHelper
{
	public static string PrintNestedList(object nestedList)
	{
		StringBuilder sb = new StringBuilder();
		BuildNestedString(nestedList, sb);
		return sb.ToString();
	}

	private static void BuildNestedString(object item, StringBuilder sb)
	{
		if (item is IList list)
		{
			sb.Append("[");
			foreach (var element in list)
			{
				BuildNestedString(element, sb);
				sb.Append(",");
			}
			if (list.Count > 0)
				sb.Length--;
			sb.Append("]");
		}
		else if (item is string s)
		{
			sb.Append($"\"{s}\"");
		}
		else if (item is char c)
		{
			sb.Append($"\"{c}\"");
		}
		else
		{
			sb.Append(item);
		}
	}

	public static string PrintTreeNode(TreeNode root)
	{
		if (root == null)
		{
			return "[]";
		}

		var queue = new Queue<TreeNode>();
		queue.Enqueue(root);

		var result = new List<int>();

		while (queue.Count > 0)
		{
			var node = queue.Dequeue();
			result.Add(node.val);

			if (node.left != null) queue.Enqueue(node.left);
			if (node.right != null) queue.Enqueue(node.right);
		}

		return "[" + string.Join(",", result) + "]";
	}

    public static string PrintList(ListNode head)
    {
        List<int> values = new List<int>();
        while (head != null)
        {
            values.Add(head.val);
            head = head.next;
        }
		return ("[" + string.Join(",", values) + "]");
    }
}
