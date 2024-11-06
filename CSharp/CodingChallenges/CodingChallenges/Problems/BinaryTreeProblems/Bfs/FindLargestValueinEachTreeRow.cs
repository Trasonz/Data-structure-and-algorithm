using CodingChallenges.DataStructures;
using CodingChallenges.Dtos;
using CodingChallenges.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.BinaryTreeProblems.Bfs;
internal class FindLargestValueinEachTreeRow
{
    private static TreeNode<int> CreateRootNode()
    {
        TreeNode<int> node4 = new(4);
        TreeNode<int> node3 = new(5);
        TreeNode<int> node2 = new(3, null, node4);
        TreeNode<int> node1 = new(2, null, node3);
        TreeNode<int> root = new(1, node1, node2);

        return root;
    }

    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { TreeRootNode = CreateRootNode() },
    ];

    public static IList<int> LargestValues(TreeNode<int> treeNode)
    {
        if (treeNode == null)
        {
            return [];
        }

        var result = new List<int>();
        var queue = new Queue<TreeNode<int>>();

        queue.Enqueue(treeNode);

        while (queue.Count > 0)
        {
            // Store the original length before more nodes are added
            int numberOfTreeNodesInQueue = queue.Count;
            int max = queue.Peek().val;

            // Go until meeting the tree currentTreeNode on the right
            for (int index = 0; index < numberOfTreeNodesInQueue; index++)
            {
                TreeNode<int> currentTreeNode = queue.Dequeue();

                if (currentTreeNode.val > max)
                {
                    max = currentTreeNode.val;
                }

                if (currentTreeNode.left != null)
                {
                    queue.Enqueue(currentTreeNode.left);
                }

                if (currentTreeNode.right != null)
                {
                    queue.Enqueue(currentTreeNode.right);
                }
            }

            result.Add(max);
        }

        return result;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            PrintUtility.PrintPrimitiveList(LargestValues(testCase.TreeRootNode!));
        }
    }
}
