using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems;

public class MovingAverage
{
    Queue<int> _numberQueue;
    int _windowSize = 0;
    int _windowSum = 0;

    public MovingAverage(int windowSize)
    {
        _numberQueue = [];
        _windowSize = windowSize;
    }

    public double Next(int value)
    {
        _numberQueue.Enqueue(value);
        _windowSum += value;

        if (_numberQueue.Count > _windowSize)
        {
            _windowSum -= _numberQueue.Dequeue();
        }

        return (double) _windowSum / _numberQueue.Count;
    }
}

public class Solution
{
    public static int FindLongestSubarray(int[] numbers, int limit)
    {
        LinkedList<int> increasingNumberLinkedList = [];
        LinkedList<int> decreasingNumberLinkedList = [];
        int leftIndex = 0;
        int subArrayMaxLength = 0;

        for (int rightIndex = 0; rightIndex < numbers.Length; rightIndex++)
        {
            // maintain the monotonic deques
            while (increasingNumberLinkedList.Count > 0 && numbers[rightIndex] < increasingNumberLinkedList.Last!.Value)
            {
                increasingNumberLinkedList.RemoveLast();
            }

            increasingNumberLinkedList.AddLast(numbers[rightIndex]);

            while (decreasingNumberLinkedList.Count > 0 && numbers[rightIndex] > decreasingNumberLinkedList.Last!.Value)
            {
                decreasingNumberLinkedList.RemoveLast();
            }

            decreasingNumberLinkedList.AddLast(numbers[rightIndex]);

            // maintain window property
            while (decreasingNumberLinkedList.First!.Value - increasingNumberLinkedList.First!.Value > limit)
            {
                if (numbers[leftIndex] == decreasingNumberLinkedList.First!.Value)
                {
                    decreasingNumberLinkedList.RemoveFirst();
                }

                if (numbers[leftIndex] == increasingNumberLinkedList.First!.Value)
                {
                    increasingNumberLinkedList.RemoveFirst();
                }

                leftIndex++;
            }

            subArrayMaxLength = Math.Max(subArrayMaxLength, rightIndex - leftIndex + 1);
        }

        return subArrayMaxLength;
    }
}

internal class Test
{
}
