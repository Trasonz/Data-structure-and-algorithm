using CodingChallenges.DataStructures;
using CodingChallenges.Dtos;
using CodingChallenges.Utilities;

namespace CodingChallenges.Problems.BinaryTreeProblems.Bfs;
internal class BinaryTreeRightSideView
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

    public static IList<int> RightSideView(TreeNode<int> treeNode)
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
            int lastTreeNodeValue = 0;

            // Go until meeting the tree currentTreeNode on the right
            for (int index = 0; index < numberOfTreeNodesInQueue; index++)
            {
                TreeNode<int> currentTreeNode = queue.Dequeue();

                // lastTreeNodeValue will always keep track
                // of the tree currentTreeNode value when looping
                lastTreeNodeValue = currentTreeNode.val;

                if (currentTreeNode.left != null)
                {
                    queue.Enqueue(currentTreeNode.left);
                }

                if (currentTreeNode.right != null)
                {
                    queue.Enqueue(currentTreeNode.right);
                }
            }

            result.Add(lastTreeNodeValue);
        }

        return result;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            PrintUtility.PrintPrimitiveList(RightSideView(testCase.TreeRootNode!));
        }
    }
}
