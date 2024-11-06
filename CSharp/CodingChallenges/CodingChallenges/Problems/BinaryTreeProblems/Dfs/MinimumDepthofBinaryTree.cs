using CodingChallenges.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.BinaryTreeProblems.Dfs;
public class MinimumDepthofBinaryTree
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

    public static int MinDepth(TreeNode<int>? treeNode)
    {
        if (treeNode == null)
        {
            Console.WriteLine("Node is empty => return 0");
            return 0;
        }

        // If only one of child is non-null, then go into that recursion.
        if (treeNode.left == null)
        {
            Console.WriteLine("Node value: " + treeNode.val);
            Console.WriteLine("Go right");
            int minRightHeight = 1 + MinDepth(treeNode.right);
            Console.WriteLine("Min right height = " + minRightHeight);
            return minRightHeight;
        }

        if (treeNode.right == null)
        {
            Console.WriteLine("Node value: " + treeNode.val);
            Console.WriteLine("Go left");
            int minLeftHeight = 1 + MinDepth(treeNode.left);
            Console.WriteLine("Min left height = " + minLeftHeight);
            return minLeftHeight;
        }

        // Both children are non-null, hence call for both children.
        Console.WriteLine("Go left");
        int leftHeight = MinDepth(treeNode.left);

        Console.WriteLine("Go right");
        int rightHeight = MinDepth(treeNode.right);

        int minHeight = 1 + Math.Min(leftHeight, rightHeight);
        Console.WriteLine("Min height = " + minHeight);

        return minHeight;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(MinDepth(testCase));
        }
    }
}
