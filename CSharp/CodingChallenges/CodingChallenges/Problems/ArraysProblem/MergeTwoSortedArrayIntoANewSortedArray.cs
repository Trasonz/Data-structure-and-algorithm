using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.ArraysProblem;
internal class MergeTwoSortedArrayIntoANewSortedArray
{
    // Given two sorted integer arrays arr1 and arr2,
    // return a new array that combines both of them and is also sorted.
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new()
        {
            ArrayOfElements1 = [1, 2, 4, 6, 9, 10],
            ArrayOfElements2 = [3, 5, 8],
        },
        new()
        {
            ArrayOfElements1 = [1, 3, 4, 6, 9, 11, 15],
            ArrayOfElements2 = [2, 5, 10, 12, 13],
        },
        new()
        {
            ArrayOfElements1 = [1, 2, 4, 6, 9, 10],
            ArrayOfElements2 = [1, 2, 2, 2, 2, 2, 2, 7],
        },
    ];

    public static List<int> MergeTwoSortedArrayIntoANewSortedArrayUsingTwoIterationIndices(
        int[] numbers1,
        int[] numbers2)
    {
        var sortedArray3 = new List<int>();
        var index1 = 0;
        var index2 = 0;

        // t: O(n + m)
        while (index1 < numbers1.Length && index2 < numbers2.Length)
        {
            if (numbers1[index1] < numbers2[index2])
            {
                sortedArray3.Add(numbers1[index1]);
                index1++;
            }
            else // numbers1[index1] >= numbers2[index2]
            {
                sortedArray3.Add(numbers2[index2]);
                index2++;
            }
        }

        // Note that only one of these loops below would run
        // because the length of 2 arrays may not equal.
        while (index1 < numbers1.Length)
        {
            sortedArray3.Add(numbers1[index1]);
            index1++;
        }

        while (index2 < numbers2.Length)
        {
            sortedArray3.Add(numbers2[index2]);
            index2++;
        }

        return sortedArray3;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            MergeTwoSortedArrayIntoANewSortedArrayUsingTwoIterationIndices(
                testCase.ArrayOfElements1,
                testCase.ArrayOfElements2);
        }
    }
}
