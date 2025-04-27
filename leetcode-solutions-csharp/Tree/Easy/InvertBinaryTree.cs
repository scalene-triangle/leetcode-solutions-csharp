using leetcode_solutions_csharp.Utils.Helpers;

namespace leetcode_solutions_csharp.Tree.Easy;

public class InvertBinaryTree
{
	/*
	* 226. Invert Binary Tree
	* Given the root of a binary tree, invert the tree, and return its root.
	* Definition for a binary tree node.
	 * public class TreeNode {
	 *     public int val;
	 *     public TreeNode left;
	 *     public TreeNode right;
	 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
	 *         this.val = val;
	 *         this.left = left;
	 *         this.right = right;
	 *     }
	 * }
	*/

	public void Run()
	{
		/*
		 * root = [4,2,7,1,3,6,9]
		 *          4
		 *         / \
		 *        2   7
		 *       / \ / \
		 *      1  3 6 9
		 */
		var root1 = new TreeNode(4,
			new TreeNode(2,
				new TreeNode(1),
				new TreeNode(3)
			),
			new TreeNode(7,
				new TreeNode(6),
				new TreeNode(9)
			)
		);

		var result1 = Solution(root1);

		Console.WriteLine(ToStringHelper.TreeNodeToString(result1)); // [4,7,2,9,6,3,1]
	}

	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
		{
			this.val = val;
			this.left = left;
			this.right = right;
		}
	}

	public TreeNode Solution(TreeNode root)
	{
		if (root == null) return root;

		PostOrder(root);

		return root;
	}

	private void PostOrder(TreeNode root)
	{
		if (root == null) return;

		PostOrder(root.left);
		PostOrder(root.right);

		TreeNode temp = root.left;
		root.left = root.right;
		root.right = temp;
	}
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
	{
		this.val = val;
		this.left = left;
		this.right = right;
	}
}
