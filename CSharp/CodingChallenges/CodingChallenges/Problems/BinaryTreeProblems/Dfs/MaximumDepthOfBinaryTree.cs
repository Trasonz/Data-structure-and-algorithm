using CodingChallenges.DataStructures;

namespace CodingChallenges.Problems.LinkedListProblems.Dfs;
internal class MaximumDepthOfBinaryTree
{
    private static TreeNode<int> CreateRootNode()
    {
        TreeNode<int> node4 = new(7);
        TreeNode<int> node3 = new(15);
        TreeNode<int> node2 = new(20, node3, node4);
        TreeNode<int> node1 = new(9);
        TreeNode<int> root = new(3, node1, node2);

        return root;
    }

    private static readonly List<TreeNode<int>> _testCases =
    [
        CreateRootNode()
    ];

    public static int MaxDepth(TreeNode<int>? root)
    {
        if (root == null)
        {
            Console.WriteLine("Found a leaf");
            return 0;
        }

        Console.WriteLine("Node value: " + root.val);
        int leftHeight = MaxDepth(root?.left);
        Console.WriteLine("left height: " + leftHeight);
        int rightHeight = MaxDepth(root?.right);
        Console.WriteLine("right height: " + rightHeight);

        return 1 + Math.Max(leftHeight, rightHeight);
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(MaxDepth(testCase));
        }
    }
}
