using CodingChallenges.DataStructures;
using CodingChallenges.Dtos;
using CodingChallenges.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.LinkedListProblems;
internal class MiddleOfTheLinkedList
{
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { LinkedList1 = new([2,4,6,8]) },
    ];

    public static MyNode<int> MiddleNodeUsingFastSlowPointers(MyNode<int> head)
    {
        MyNode<int>? slowNode = head;
        MyNode<int>? fastNode = head;

        // t: O(n)
        while (fastNode != null && fastNode.Next != null)
        {
            slowNode = slowNode.Next;
            fastNode = fastNode.Next.Next;
        }

        return slowNode!;
    }


    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            var node = MiddleNodeUsingFastSlowPointers(testCase.LinkedList1.Head!);
            PrintUtility.PrintLinkedList(node);

        }
    }
}
