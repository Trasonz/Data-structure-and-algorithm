using CodingChallenges.Dtos;
using CodingChallenges.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.GraphProblems;

public static class ReorderRoutestoMakeAllPathsLeadtotheCityZero
{
    private static readonly List<TestCaseDto<int>> _testCases = [
        new() { 
            ArrayOfArrays1 = [
                [1, 0],
                [1, 20],
                [0, 30],
                [4, 30]

            ],
            Integer1 = 5,
        },

    ];

    static int count = 0;

    static void CheckConnection(int nodeValue, int parentNodeValue, Dictionary<int, List<List<int>>> graph)
    {
        if (!graph.TryGetValue(
                nodeValue,
                out List<List<int>>? nodeNeighborsAndShouldRedirect))
        {
            return;
        }

        foreach (var neighborsAndShouldRedirect in nodeNeighborsAndShouldRedirect)
        {
            // neighborNodes[0]: neighborNodeValue
            // neighborNodes[1]: should redirect (1 or 0)
            if (neighborsAndShouldRedirect[0] != parentNodeValue)
            {
                count += neighborsAndShouldRedirect[1];
                CheckConnection(neighborsAndShouldRedirect[0], nodeValue, graph);
            }
        }
    }

    public static int MinReorderDfs(int numberOfNodes, int[][] edges)
    {
        Dictionary<int, List<List<int>>> graph = [];

        foreach (var edge in edges)
        {
            if (!graph.TryGetValue(
                    edge[0],
                    out List<List<int>>? node0NeighborsAndShouldRedirect))
            {
                node0NeighborsAndShouldRedirect = ([]);
                graph.Add(edge[0], node0NeighborsAndShouldRedirect);
            }

            node0NeighborsAndShouldRedirect.Add([edge[1], 1]);


            if (!graph.TryGetValue(
                    edge[1],
                    out List<List<int>>? node1NeighborsAndShouldRedirect))
            {
                node1NeighborsAndShouldRedirect = ([]);
                graph.Add(edge[1], node1NeighborsAndShouldRedirect);
            }

            node1NeighborsAndShouldRedirect.Add([edge[0], 0]);
        }

        CheckConnection(0, -1, graph);

        return count;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(MinReorderDfs(testCase.Integer1, testCase.ArrayOfArrays1!));
        }
    }
}