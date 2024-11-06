using CodingChallenges.DataStructures;
using CodingChallenges.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodingChallenges.Problems.BinaryTreeProblems.Dfs;
internal class LowestCommonAncestorOfABinaryTree
{
    private static TreeNode<int> CreateRootNode()
    {
        TreeNode<int> node8 = new(8);
        TreeNode<int> node7 = new(7);
        TreeNode<int> node6 = new(6);
        TreeNode<int> node5 = new(5);
        TreeNode<int> node4 = new(4, node7, node8);
        TreeNode<int> node3 = new(3, node6);
        TreeNode<int> node2 = new(2, null, node5);
        TreeNode<int> node1 = new(1, node3, node4);
        TreeNode<int> root = new(0, node1, node2);

        return root;
    }

    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { 
            TreeRootNode = CreateRootNode(),
            TreeNode1 = new(4),
            TreeNode2 = new(6)
        },
    ];

    public static TreeNode<int>? LowestCommonAncestor(TreeNode<int>? root, TreeNode<int> nodeA, TreeNode<int> nodeB)
    {
        if (root == null)
        {
            return null;
        }

        // First case: The root node is p or q. The answer cannot be below the root node, because then it would be missing the root (which is either p or q) as a descendant.
        if (root.val == nodeA.val || root.val == nodeB.val)
        {
            return root;
        }

        TreeNode<int>? leftNode = LowestCommonAncestor(root.left, nodeA, nodeB);
        TreeNode<int>? rightNode = LowestCommonAncestor(root.right, nodeA, nodeB);

        // Second case
        if (leftNode != null && rightNode != null)
        {
            return root;
        }

        // Third case
        return leftNode ?? rightNode;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            var a = LowestCommonAncestor(
                    testCase.TreeRootNode!,
                    testCase.TreeNode1!,
                    testCase.TreeNode2!
                )?.val;
        }
    }
}
