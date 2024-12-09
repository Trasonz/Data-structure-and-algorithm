using CodingChallenges.DataStructures;
using CodingChallenges.Dtos;
using CodingChallenges.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.GraphProblems;
internal class AllNodesDistanceKinBinaryTree
{
    private static TreeNode<int> CreateRootNode()
    {
        TreeNode<int> node8 = new(4);
        TreeNode<int> node7 = new(7);
        TreeNode<int> node6 = new(8);
        TreeNode<int> node5 = new(0);
        TreeNode<int> node4 = new(2, node7, node8);
        TreeNode<int> node3 = new(6);
        TreeNode<int> node2 = new(1, node5, node6);
        TreeNode<int> node1 = new(5, node3, node4);
        TreeNode<int> root = new(3, node1, node2);

        return root;
    }

    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { 
            TreeRootNode = CreateRootNode(),
            TreeNode1 = new TreeNode<int>(5),
            Integer2 = 2,
        },
    ];

    // Recursively build the undirected graph from the binary tree.
    private static void BuildGraph(
        TreeNode<int> treeNode,
        TreeNode<int>? treeParentNode,
        Dictionary<int, List<int>> graph)
    {
        if (treeNode != null)
        {
            if (treeParentNode != null)
            {
                if (!graph.TryGetValue(
                        treeNode.val,
                        out List<int>? treeNodeNeighbors))
                {
                    treeNodeNeighbors = [];
                    graph.Add(treeNode.val, treeNodeNeighbors);
                }

                treeNodeNeighbors.Add(treeParentNode.val);


                if (!graph.TryGetValue(
                        treeParentNode.val,
                        out List<int>? parentNodeNeighbors))
                {
                    parentNodeNeighbors = ([]);
                    graph.Add(treeParentNode.val, parentNodeNeighbors);
                }

                parentNodeNeighbors.Add(treeNode.val);
            }

            if (treeNode.left != null)
            {
                BuildGraph(treeNode.left, treeNode, graph);
            }

            if (treeNode.right != null)
            {
                BuildGraph(treeNode.right, treeNode, graph);
            }
        }
    }

    public static IList<int> DistanceK(
        TreeNode<int> treeNode, 
        TreeNode<int> targetNode, 
        int kEdgesFromTarget)
    {
        Dictionary<int, List<int>> nodesAndNeighbors = [];
        BuildGraph(treeNode, null, nodesAndNeighbors);

        List<int> result = [];
        HashSet<int> visitedNodes = [];
        Queue<int[]> nodeAndNumberOfEdgesFromTargetQueue = [];

        // Add the target node to the queue with a distance of 0
        nodeAndNumberOfEdgesFromTargetQueue.Enqueue([targetNode.val, 0]);
        visitedNodes.Add(targetNode.val);

        while (nodeAndNumberOfEdgesFromTargetQueue.Count > 0)
        {
            int[] nodeAndNumberOfEdgesFromTarget = nodeAndNumberOfEdgesFromTargetQueue.Dequeue();
            int nodeValue = nodeAndNumberOfEdgesFromTarget[0];
            int numberOfEdgesFromTarget = nodeAndNumberOfEdgesFromTarget[1];

            // If the current node is at distance k from target,
            // add it to the answer list and continue to the next node.
            if (numberOfEdgesFromTarget == kEdgesFromTarget)
            {
                result.Add(nodeValue);
                continue;
            }

            // Add all unvisited neighbors of the current node to the queue.
            foreach (var neighborNode in nodesAndNeighbors.GetValueOrDefault(nodeValue) ?? [])
            {
                if (!visitedNodes.Contains(neighborNode))
                {
                    visitedNodes.Add(neighborNode);
                    nodeAndNumberOfEdgesFromTargetQueue.Enqueue([neighborNode, numberOfEdgesFromTarget + 1]);
                }
            }
        }

        return result;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            PrintUtility.PrintPrimitiveList(DistanceK(testCase.TreeRootNode!, testCase.TreeNode1!, testCase.Integer2));
        }
    }
}
