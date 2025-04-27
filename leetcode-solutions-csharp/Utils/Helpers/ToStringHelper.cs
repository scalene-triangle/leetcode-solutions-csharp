using System.Collections;
using System.Text;
namespace leetcode_solutions_csharp.Utils.Helpers;

public class ToStringHelper
{
	public static string NestedListToString(object nestedList)
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
}
