using CodingChallenges.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodingChallenges.Problems.BinaryTreeProblems.Dfs;
public class CountGoodNodesInBinaryTree
{
    private static TreeNode<int> CreateRootNode()
    {
        TreeNode<int> root = new(0);

        return root;
    }

    private static readonly List<TreeNode<int>> _testCases =
    [
    ];

    private int DepthFirstSearch(TreeNode<int> treeNode, int max)
    {
        if (treeNode == null)
        {
            return 0;
        }

        int numberOfGoodNodesOnLeft = DepthFirstSearch(treeNode.left!, Math.Max(treeNode.val, max));
        int numberOfGoodNodesOnRight = DepthFirstSearch(treeNode.right!, Math.Max(treeNode.val, max));

        int numberOfGoodNodes = numberOfGoodNodesOnLeft + numberOfGoodNodesOnRight;

        // If the node itself bigger than max, also count it
        if (treeNode.val >= max)
        {
            numberOfGoodNodes++;
        }

        return numberOfGoodNodes;
    }

    public int GoodNodes(TreeNode<int> treeNode)
    {
        return DepthFirstSearch(treeNode, treeNode.val);
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
        }
    }
}
