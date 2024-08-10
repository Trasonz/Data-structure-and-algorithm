using CodingChallenges.Dtos;
using CodingChallenges.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.QueueProblems;

internal class SlidingWindowMaximum
{
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { Array1 = [1,3,-1,-3,5,3,6,7], Integer1 = 3},
    ];

    public static int[] FindMaxInEachSlidingWindow1(int[] numbers, int k)
    {
        Queue<int> numberQueue = []; // s: O(1)
        int maxNumber = numbers[0];
        List<int> result = [];

        // t: O(0 to k - 1)
        for (var index = 0; index < k; index++)
        {
            numberQueue.Enqueue(numbers[index]);

            if (numbers[index] > maxNumber)
            {
                maxNumber = numbers[index];
            }
        }

        result.Add(maxNumber);

        // t: O(k to  n)
        for (var index = k; index < numbers.Length; index++)
        {
            numberQueue.Enqueue(numbers[index]);
            int leftNumber = numberQueue.Dequeue();

            if (numbers[index] > maxNumber)
            {
                maxNumber = numbers[index];
            }
            else if (leftNumber == maxNumber && numbers[index] < maxNumber)
            {
                maxNumber = numberQueue.Max(); // hurt performance
            }

            result.Add(maxNumber);
        }

        return [.. result];
    }

    // Remove previous indices from the index linked list 
    // having their numbers smaller than the current number
    private static void RemovePreviousIndicesFromDecreasingIndexLinkedList(
        int[] numbers, int currentNumber, LinkedList<int> linkedList)
    {
        while (linkedList.Count > 0
            && currentNumber >= numbers[linkedList.Last!.Value])
        {
            linkedList.RemoveLast();
        }
    }

    public static int[] FindMaxInEachSlidingWindow2(int[] numbers, int k)
    {
        LinkedList<int> decreasingIndexLinkedList = []; // Deque
        List<int> result = [];

        // t: O(0 to k - 1)
        for (var index = 0; index < k; index++)
        {
            RemovePreviousIndicesFromDecreasingIndexLinkedList(
                numbers, numbers[index], decreasingIndexLinkedList);
            decreasingIndexLinkedList.AddLast(index);
        }

        result.Add(numbers[decreasingIndexLinkedList.First!.Value]);

        for (var index = k; index < numbers.Length; index++)
        {
            // ensure distance = k
            if (decreasingIndexLinkedList.First?.Value == index - k)
            {
                decreasingIndexLinkedList.RemoveFirst();
            }

            RemovePreviousIndicesFromDecreasingIndexLinkedList(
                numbers, numbers[index], decreasingIndexLinkedList);

            decreasingIndexLinkedList.AddLast(index);
            result.Add(numbers[decreasingIndexLinkedList.First!.Value]);
        }

        return [.. result];
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            var result1 = FindMaxInEachSlidingWindow1(testCase.Array1, testCase.Integer1);
            var result2 = FindMaxInEachSlidingWindow2(testCase.Array1, testCase.Integer1);

            PrintUtility.PrintPrimitiveArray(result1);
            Console.WriteLine("\n\n\n\n\n");
            PrintUtility.PrintPrimitiveArray(result2);

            /*for (int index = 0; index < result1.Length && index < result2.Length; index++)
            {
                if (result1[index] != result2[index])
                {
                    Console.WriteLine($"At index: {index}, result 1: {result1[index]}, result 2 {result2[index]}");
                }
            }*/
        }
    }
}
