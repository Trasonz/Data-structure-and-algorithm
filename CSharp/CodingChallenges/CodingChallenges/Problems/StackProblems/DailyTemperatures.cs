using CodingChallenges.Dtos;
using CodingChallenges.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.StackProblems;
internal static class DailyTemperatures
{
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { Array1 = [73,74,75,71,69,72,76,73] },
    ];

    public static int[] CalculateDailyTemperatures(int[] temperatures)
    {
        Stack<int> decreasingIndexStack = []; // s: O(k)
        int[] result = new int[temperatures.Length];

        // t: O(n)
        for (int index = 0; index < temperatures.Length; index++)
        {
            while (decreasingIndexStack.Count > 0
                && temperatures[index] > temperatures[decreasingIndexStack.Peek()])
            {
                int previousIndex = decreasingIndexStack.Pop();
                result[previousIndex] = index - previousIndex;
            }

            decreasingIndexStack.Push(index);
        }

        return result;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            PrintUtility.PrintPrimitiveArray(CalculateDailyTemperatures(testCase.Array1));
        }
    }
}
