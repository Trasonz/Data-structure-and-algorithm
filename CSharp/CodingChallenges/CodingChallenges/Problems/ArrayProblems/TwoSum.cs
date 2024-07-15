using CodingChallenges.Dtos;
using CodingChallenges.Utilities;

namespace CodingChallenges.Problems.ArrayProblems;

internal static class TwoSum
{
    // Given a SORTED array of unique integers and a target integer,
    // return true if there exists a pair of sortedNumbers that sum to target, false otherwise.
    // Given a string s, return true if it is a palindrome, false otherwise.
    private static readonly List<TestCaseDto<int>> _testCases1 =
    [
        new()
        {
            ArrayOfElements = [2, 7, 11, 15],
            Element = 9
        },
        new()
        {
            ArrayOfElements = [1, 2, 3, 4, 6, 8],
            Element = 10
        }
    ];

    // Given a UNSORTED array of unique integers and a target integer,
    // return true if there exists a pair of sortedNumbers that sum to target, false otherwise.
    // Given a string s, return true if it is a palindrome, false otherwise.
    private static readonly List<TestCaseDto<int>> _testCases2 =
    [
        new()
        {
            ArrayOfElements = [2, 7, 11, 15],
            Element = 9
        },
        new()
        {
            ArrayOfElements = [3, 6, 4, 8, 1, 2],
            Element = 10
        },
        new()
        {
            ArrayOfElements = [3, 2, 4],
            Element = 6
        },
        new()
        {
            ArrayOfElements = [3, 3],
            Element = 6
        },
        new()
        {
            ArrayOfElements = [1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1],
            Element = 11
        }
    ];

    public static bool HasTwoNumbersHaveSumEqualTargetNumber(
        int[] sortedNumbers,
        int k)
    {
        int leftIndex = 0;
        int rightIndex = sortedNumbers.Length - 1;

        while (leftIndex < rightIndex)
        {
            var sum = sortedNumbers[leftIndex] + sortedNumbers[rightIndex];

            if (sum == k)
            {
                // sum == k
                return true;
            }

            if (sum > k)
            {
                rightIndex--;
                continue;
            }

            if (sum < k)
            {
                leftIndex++;
                continue;
            }
        }

        return false;
    }

    public static int[] FindTwoIndicesHasSumEqualTargetNumberUsingTwoIterationIndices(
        int[] numbers,
        int k)
    {
        int leftIndex = 0;
        int rightIndex = numbers.Length - 1;

        while (leftIndex < rightIndex)
        {
            var sum = numbers[leftIndex] + numbers[rightIndex];

            if (sum == k)
            {
                break;
            }

            if (sum > k)
            {
                rightIndex--;
                continue;
            }

            if (sum < k)
            {
                leftIndex++;
                continue;
            }
        }

        return [leftIndex, rightIndex];
    }

    public static int[] FindTwoIndicesHasSumEqualTargetNumberUsingHashMap(
        int[] numbers,
        int targetSum)
    {
        Dictionary<int, int> firstNumberAndIndiceMap = [];

        for (int index = 0; index < numbers.Length; index++)
        {
            var firstNumber = targetSum - numbers[index];

            if (firstNumberAndIndiceMap.TryGetValue(firstNumber, out int value))
            {
                return [value, index];
            }
            else
            {
                // Current number trở thành first number của một số khác khi index tăng.
                firstNumberAndIndiceMap.TryAdd(numbers[index], index);
            }
        }

        return [-1];
    }

    public static void Run()
    {
        Console.WriteLine("Sorted array, 2 firstNumberAndIndiceMap:");
        foreach (var testCase in _testCases1)
        {
            PrintUtility.PrintPrimitiveArray(
                FindTwoIndicesHasSumEqualTargetNumberUsingTwoIterationIndices(
                    testCase.ArrayOfElements!,
                    testCase.Element
                )
            );
        }

        Console.WriteLine();
        Console.WriteLine("Unsorted array, 2 firstNumberAndIndiceMap:");
        foreach (var testCase in _testCases2)
        {
            PrintUtility.PrintPrimitiveArray(
                FindTwoIndicesHasSumEqualTargetNumberUsingHashMap(
                    testCase.ArrayOfElements!,
                    testCase.Element
                )
            );
        }
    }
}
