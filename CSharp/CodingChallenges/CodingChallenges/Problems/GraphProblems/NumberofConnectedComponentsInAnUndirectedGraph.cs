using CodingChallenges.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.GraphProblems;

public class NumberofConnectedComponentsinanUndirectedGraph
{
    private static readonly List<TestCaseDto<int>> _testCases = [
        new() {
            Integer1 = 5,
            ArrayOfArrays1 = [[0,1],[1,2],[3,4]]
        },

    ];
    private static void VisitNeighbors(List<int>[] nodeNeighbors, bool[] visitedNodes, int nodeIndex)
    {
        visitedNodes[nodeIndex] = true;

        for (int neighborNodeIndex = 0; neighborNodeIndex < nodeNeighbors[nodeIndex].Count; neighborNodeIndex++)
        {
            if (visitedNodes[nodeNeighbors[nodeIndex][neighborNodeIndex]] == false)
            {
                VisitNeighbors(nodeNeighbors, visitedNodes, nodeNeighbors[nodeIndex][neighborNodeIndex]);
            }
        }
    }

    public static int CountComponents(int numberOfNodes, int[][] edges)
    {
        int components = 0;
        bool[] visitedNodes = new bool[numberOfNodes];

        List<int>[] nodeNeighbors = new List<int>[numberOfNodes];

        // Collect nodes
        for (int nodeIndex = 0; nodeIndex < numberOfNodes; nodeIndex++)
        {
            nodeNeighbors[nodeIndex] = [];
        }

        // Collect neighbors of each node
        for (int index = 0; index < edges.Length; index++)
        {
            nodeNeighbors[edges[index][0]].Add(edges[index][1]);
            nodeNeighbors[edges[index][1]].Add(edges[index][0]);
        }

        for (int nodeIndex = 0; nodeIndex < numberOfNodes; nodeIndex++)
        {
            if (visitedNodes[nodeIndex] == false)
            {
                components++;
                VisitNeighbors(nodeNeighbors, visitedNodes, nodeIndex);
            }
        }

        return components;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(CountComponents(testCase.Integer1, testCase.ArrayOfArrays1!));
        }
    }
}
