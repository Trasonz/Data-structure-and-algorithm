using CodingChallenges.DataStructures;
using CodingChallenges.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodingChallenges.Problems.BinaryTreeProblems.Dfs;
internal class TestTraversalOrder
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
        new() { TreeRootNode = CreateRootNode() },
    ];

    public static void PreorderDfs(TreeNode<int>? node)
    {
        if (node == null)
        {
            return;
        }

        Console.WriteLine("Node value: " + node.val + "\n");

        Console.WriteLine("Go left");
        PreorderDfs(node.left);

        Console.WriteLine("Go right");
        PreorderDfs(node.right);

        return;
    }

    public static void InOrderDfs(TreeNode<int>? node)
    {
        if (node == null)
        {
            return;
        }

        Console.WriteLine("Go left");
        InOrderDfs(node.left);

        Console.WriteLine("Node value: " + node.val + "\n");

        Console.WriteLine("Go right");
        InOrderDfs(node.right);

        return;
    }

    public static void PostOrderDfs(TreeNode<int>? node)
    {
        if (node == null)
        {
            return;
        }

        Console.WriteLine("Go left");
        PostOrderDfs(node.left);

        Console.WriteLine("Go right");
        PostOrderDfs(node.right);

        Console.WriteLine("Node value: " + node.val + "\n");

        return;
    }


    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            PostOrderDfs(testCase.TreeRootNode!);
        }
    }
}
