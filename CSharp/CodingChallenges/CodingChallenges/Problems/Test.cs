using CodingChallenges.DataStructures;
using CodingChallenges.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;

namespace CodingChallenges.Problems;

public class Test
{
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { 
            Array1 = [1,4,2], Array2 = [1,1,5,2,3], Array3 = [2,3,4,5,6]
        },
    ];

    public IList<int> FindSmallestSetOfVertices(int numberOfNodes, IList<IList<int>> edges)
    {
        // List to signify if the vertex has an incoming edge or not.
        bool[] hasNodeBs = new bool[numberOfNodes];

        foreach (var edge in edges)
        {
            // edge[1]: nodeB
            hasNodeBs[edge[1]] = true;
        }

        List<int> nodeAIndices = [];

        // Find nodeAs that doesn't connect to the list of nodeBs
        for (int index = 0; index < numberOfNodes; index++)
        {
            if (!hasNodeBs[index])
            {
                nodeAIndices.Add(index);
            }
        }

        return nodeAIndices;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine();
        }
    }
}

public class Completed
{

    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        bool[] hasKeyList = new bool[rooms.Count];
        Stack<int> visitedRooms = [];

        // First room needs no key
        hasKeyList[0] = true;

        // First room is allowed to visit without a key
        visitedRooms.Push(0);

        //At the beginning, we have a todo list "keys" of keys to use.
        //'seen' represents at some point we have entered this room.
        while (visitedRooms.Count > 0)
        {
            int currentRoom = visitedRooms.Pop();

            foreach (int key in rooms[currentRoom])
            {
                // If the key doesn't exist in the list, collect it
                // Also mark the room with that key is available to visit
                if (!hasKeyList[key])
                {
                    hasKeyList[key] = true;
                    visitedRooms.Push(key);
                }
            }
        }

        // If any key was not collected, return false
        return !hasKeyList.Any(hasKey => !hasKey);
    }

    public int ClosestValue(TreeNode<int>? treeNode, double target)
    {
        int closestNodeValue = treeNode?.val ?? 0;

        while (treeNode != null)
        {
            int currentNodeValue = treeNode.val;

            bool isCurrentNodeValueCloseToTargetThanRoot = Math.Abs(currentNodeValue - target) <
                Math.Abs(closestNodeValue - target);
            bool isCurrentNodeValueToTargetEqualRoot = Math.Abs(currentNodeValue - target) ==
                Math.Abs(closestNodeValue - target);
            bool isCurrentNodeValueSmallerThanEqualRoot = currentNodeValue < closestNodeValue;

            closestNodeValue = isCurrentNodeValueCloseToTargetThanRoot ||
                (isCurrentNodeValueToTargetEqualRoot && isCurrentNodeValueSmallerThanEqualRoot)
                    ? currentNodeValue : closestNodeValue;

            treeNode = target < currentNodeValue ? treeNode.left : treeNode.right;
        }

        return closestNodeValue;
    }

    public TreeNode<int> InsertIntoBST(TreeNode<int>? treeNode, int val)
    {
        if (treeNode == null)
        {
            return new TreeNode<int>(val);
        }

        // insert into the right subtree
        if (val > treeNode.val)
        {
            treeNode.right = InsertIntoBST(treeNode.right, val);
        }
        // insert into the left subtree
        else
        {
            treeNode.left = InsertIntoBST(treeNode.left, val);
        }

        return treeNode;
    }

    public IList<IList<int>> ZigzagLevelOrder(TreeNode<int> treeNode)
    {
        var result = new List<IList<int>>();

        if (treeNode == null)
        {
            return result;
        }

        var queue = new Queue<TreeNode<int>?>();
        queue.Enqueue(treeNode);
        queue.Enqueue(null);

        // A linked list to store all nodes on the same row
        var row = new LinkedList<int>();
        bool isFromLeftToRight = true;

        while (queue.Count > 0)
        {
            TreeNode<int>? currentTreeNode = queue.Dequeue();

            if (currentTreeNode != null)
            {
                // If from left to right, add at the end
                // Else, add at begin
                if (isFromLeftToRight)
                {
                    row.AddLast(currentTreeNode.val);
                }
                else
                {
                    row.AddFirst(currentTreeNode.val);
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
            // After fully checked a row
            else
            {
                result.Add([.. row]);
                row.Clear();

                // If there are nodes in the next row added
                // Add a null at the end
                if (queue.Count > 0)
                {
                    queue.Enqueue(null);
                }

                // Switch the direction
                isFromLeftToRight = !isFromLeftToRight;
            }
        }

        return result;
    }

    public static int DeepestLeavesSum(TreeNode<int> treeNode)
    {
        if (treeNode == null)
        {
            return 0;
        }

        int sum = 0;
        var queue = new Queue<TreeNode<int>>();
        queue.Enqueue(treeNode);

        while (queue.Count > 0)
        {
            // Store the original length before more nodes are added
            int numberOfTreeNodesInQueue = queue.Count;
            sum = 0;
            // Go until meeting the tree currentTreeNode on the right
            for (int index = 0; index < numberOfTreeNodesInQueue; index++)
            {
                TreeNode<int> currentTreeNode = queue.Dequeue();
                sum += currentTreeNode.val;

                if (currentTreeNode.left != null)
                {
                    queue.Enqueue(currentTreeNode.left);
                }

                if (currentTreeNode.right != null)
                {
                    queue.Enqueue(currentTreeNode.right);
                }
            }
        }

        return sum;
    }

    public static int[] NextGreaterElement(int[] numbers1, int[] numbers2)
    {
        // A keys to store previous unchecked number
        Stack<int> uncheckedNumbers = [];

        // Map numbers and their next greater number on their rightIndex
        Dictionary<int, int> numberMap = [];

        // Loop through numbers2 to build a hash map
        foreach (int number in numbers2)
        {
            // While the keys is not empty and the latest element is
            // smaller than the current number in numbers2
            while (uncheckedNumbers.Count > 0 &&
                uncheckedNumbers.Peek() < number)
            {
                // Pop the latest element from the keys and
                // put it to the hash map
                numberMap.Add(uncheckedNumbers.Pop(), number);
            }

            // Put the number in the keys
            uncheckedNumbers.Push(number);
        }

        int[] result = new int[numbers1.Length];

        for (int index = 0; index < numbers1.Length; index++)
        {
            // If the hash map contains the number, return the
            // value. Else, return -1
            result[index] = numberMap.TryGetValue(numbers1[index], out int value)
                ? value
                : -1;
        }

        return result;
    }

    public int MinSwaps(string _string)
    {
        int openBrackets = 0;
        int minAddsRequired = 0;

        foreach (char character in _string)
        {
            if (character == '(')
            {
                openBrackets++;
            }
            else
            {
                // If an open bracket exists, match it with the closing one
                // If not, we need to add an open bracket.
                if (openBrackets > 0)
                {
                    openBrackets--;
                }
                else
                {
                    minAddsRequired++;
                }
            }
        }

        // Add the remaining open brackets as closing brackets would be required.
        return minAddsRequired + openBrackets;
    }

    private static long GetCoins(int heroPower, long[][] monsterCoinMap)
    {
        int leftIndex = 0;
        int rightIndex = monsterCoinMap.Length - 1;

        while (leftIndex <= rightIndex)
        {
            int mid = (leftIndex + rightIndex) / 2;

            if (heroPower < monsterCoinMap[mid][0])
            {
                rightIndex = mid - 1;
            }
            else
            {
                leftIndex = mid + 1;
            }
        }

        if (leftIndex == 0 && heroPower < monsterCoinMap[leftIndex][0])
        {
            // The hero can't defeat any monsters
            return 0;
        }

        // Return the prefix sum at the rightIndex index

        return monsterCoinMap[rightIndex][1];
    }

    public static long[] MaximumCoins(int[] heroPowers, int[] monsterPowers, int[] coins)
    {
        // Create an array of arrays for mapping monster power and coin
        long[][] monsterCoinMap = new long[monsterPowers.Length][];

        // Mapping monsters and coins 
        for (int index = 0; index < monsterPowers.Length; index++)
        {
            monsterCoinMap[index] =
            [
                monsterPowers[index],
                coins[index]
            ];
        }

        // Sort the mapping in ascending order of monsters' power
        // to apply binary search
        Array.Sort(
            monsterCoinMap,
            (firstElement, secondElement) =>
                firstElement[0].CompareTo(secondElement[0])
        );

        // Calculate the prefix sum of the monsters' power.
        long prefixSum = monsterCoinMap[0][1];

        for (int index = 1; index < monsterCoinMap.Length; index++)
        {
            prefixSum += monsterCoinMap[index][1];
            monsterCoinMap[index][1] = prefixSum;
        }

        // Create an array to store the heroTotalCoins
        long[] heroTotalCoins = new long[heroPowers.Length];

        // For each hero, find the strongest monster he can defeat. When a hero
        // can defeat a monster, he can also defeat all the weaker monsters and
        // get sum of all the coins from them.
        for (int index = 0; index < heroPowers.Length; index++)
        {
            heroTotalCoins[index] = GetCoins(heroPowers[index], monsterCoinMap);
        }

        return heroTotalCoins;
    }
}

public class StockPrice
{
    static Stack<int[]> stockPrices = [];

    public static int Next(int price)
    {
        int count = 1;

        // If the keys has value and the last element of the keys is smaller
        // than the price, increase the count with the previous count.
        // Also pop that element out of the keys.
        while (stockPrices.Count > 0 && stockPrices.Peek()[0] < price)
        {
            count += stockPrices.Pop()[1];
        }

        stockPrices.Push([price, count]);

        // Return the count of current price
        return count;
    }
}

public class FindifPathExistsinGraph
{    
    private bool CheckPathBetweenNodes(
        Dictionary<int, List<int>> graph,
        bool[] visitedNodes,
        int scanNode,
        int destinationNode)
    {
        // There is a path to the destination node
        if (scanNode == destinationNode)
        {
            return true;
        }

        if (!visitedNodes[scanNode])
        {
            visitedNodes[scanNode] = true;

            for (int index = 0; index < graph[scanNode].Count; index++)
            {
                // graph[scanNode][index]: list of neighbors
                if (CheckPathBetweenNodes(
                    graph, 
                    visitedNodes, 
                    graph[scanNode][index], 
                    destinationNode))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool ValidPath(
        int numberOfNodes, 
        int[][] edges, 
        int sourceNode, 
        int destinationNode)
    {
        Dictionary<int, List<int>> graph = [];

        bool[] visitedNodes = new bool[numberOfNodes];

        for (int index = 0; index < edges.Length; index++)
        {
            // edges[index][0]: nodeA, edges[index][1]: nodeB
            if (!graph.TryGetValue(
                    edges[index][0],
                    out List<int>? nodeANeighbors))
            {
                nodeANeighbors =[];
                graph.Add(edges[index][0], nodeANeighbors);
            }

            nodeANeighbors.Add(edges[index][1]);


            if (!graph.TryGetValue(
                    edges[index][1],
                    out List<int>? nodeBNeighbors))
            {
                nodeBNeighbors = ([]);
                graph.Add(edges[index][1], nodeBNeighbors);
            }

            nodeBNeighbors.Add(edges[index][0]);
        }

        return CheckPathBetweenNodes(graph, visitedNodes, sourceNode, destinationNode);
    }
}

public class ReachableNodesWithRestrictions
{
    private int count = 0;

    private void CountNodes(int nodeValue, Dictionary<int, List<int>> graph, HashSet<int> visitedNodes)
    {
        // Mark 'currNode' as visited and increment 'ans' by 1.
        count++;
        visitedNodes.Add(nodeValue);

        // Go for unvisited neighbors of 'currNode'.
        foreach (int neighborNodeValue in graph[nodeValue])
        {
            if (!visitedNodes.Contains(neighborNodeValue))
            {
                CountNodes(neighborNodeValue, graph, visitedNodes);
            }
        }
    }

    public int ReachableNodes(int numberOfNodes, int[][] edges, int[] restrictedNodes)
    {
        //Store all edges according to nodes in 'neighbors'.
        Dictionary<int, List<int>> graph = [];

        for (int index = 0; index < edges.Length; index++)
        {
            // edges[index][0]: nodeA, edges[index][1]: nodeB
            if (!graph.TryGetValue(
                    edges[index][0],
                    out List<int>? nodeANeighbors))
            {
                nodeANeighbors = [];
                graph.Add(edges[index][0], nodeANeighbors);
            }

            nodeANeighbors.Add(edges[index][1]);


            if (!graph.TryGetValue(
                    edges[index][1],
                    out List<int>? nodeBNeighbors))
            {
                nodeBNeighbors = ([]);
                graph.Add(edges[index][1], nodeBNeighbors);
            }

            nodeBNeighbors.Add(edges[index][0]);

        }

        // Mark the nodes in 'restricted' as visited.
        HashSet<int> visitedNodes = [];

        foreach (int node in restrictedNodes)
        {
            visitedNodes.Add(node);
        }

        CountNodes(0, graph, visitedNodes);
        return count;
    }
}

