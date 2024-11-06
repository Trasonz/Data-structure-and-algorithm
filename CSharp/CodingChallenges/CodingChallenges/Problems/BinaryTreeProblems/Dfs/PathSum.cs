using CodingChallenges.DataStructures;
using CodingChallenges.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.BinaryTreeProblems.Dfs;
internal class PathSum
{
    private static TreeNode<int> CreateRootNode()
    {
        TreeNode<int> node8 = new(1);
        TreeNode<int> node7 = new(2);
        TreeNode<int> node6 = new(7);
        TreeNode<int> node5 = new(4, node8);
        TreeNode<int> node4 = new(13);
        TreeNode<int> node3 = new(11, node6, node7);
        TreeNode<int> node2 = new(8, node4, node5);
        TreeNode<int> node1 = new(4, node3);
        TreeNode<int> root = new(5, node1, node2);

        return root;
    }

    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { TreeRootNode = CreateRootNode(), Integer1 = 22 },
    ];

    public static bool HasPathSum(TreeNode<int> treeNode, int targetSum)
    {
        if (treeNode == null)
        {
            return false;
        }

        targetSum -= treeNode.val;

        // if node is a leaf
        return treeNode.left == null && treeNode.right == null
              // Check if target sum can be reduced to 0
            ? targetSum == 0
              // else, continue with another direction
            : HasPathSum(treeNode.left!, targetSum) || HasPathSum(treeNode.right!, targetSum);
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(HasPathSum(testCase.TreeRootNode!, testCase.Integer1));
        }
    }
}
