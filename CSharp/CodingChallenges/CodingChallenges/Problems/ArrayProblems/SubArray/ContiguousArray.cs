using CodingChallenges.Dtos;
using CodingChallenges.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodingChallenges.Problems.ArrayProblems.SubArray;
internal class ContiguousArray
{
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { Array1 = [1, 1,0, 0,1,1,1,0,0,1] },
        new() { Array1 = [0, 1] },
        new() { Array1 = [1, 0] },
        new() { Array1 = [0, 1, 0] },
        new() { Array1 = [0,0,1,1,1,0,0,1,0,1,1,0] },
        new() { Array1 = [0,0,1,1,1,0,0,1,1,1] },
    ];

    public static int FindContiguousArrayUsingPrefixSumHashMap(int[] numbers)
    {
        Dictionary<int, int> prefixSumIndexMap = []; // s: O(n)
        int prefixSum = 0;
        prefixSumIndexMap.Add(0, -1);
        int maxLength = 0;

        // t: O(n)
        for (int index = 0; index < numbers.Length; index++)
        {
            prefixSum += numbers[index] == 0
            ? -1
            : 1;

            if (prefixSumIndexMap.TryGetValue(prefixSum, out int value))
            {
                var length = index - prefixSumIndexMap[prefixSum];

                if (length > maxLength)
                {
                    maxLength = length;
                }
            }
            else
            {
                prefixSumIndexMap.Add(prefixSum, index);
            }
        }

        return maxLength;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.Write($"Result: ");

            Console.WriteLine(FindContiguousArrayUsingPrefixSumHashMap(
                testCase.Array1));
        }
    }
}
