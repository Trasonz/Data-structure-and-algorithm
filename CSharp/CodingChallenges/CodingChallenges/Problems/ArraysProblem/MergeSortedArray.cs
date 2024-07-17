using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.ArraysProblem;

internal static class MergeSortedArray
{
    //You are given two integer arrays nums1 and nums2,
    //sorted in non-decreasing order,
    //and two integers m and n,
    //representing the number of elements in nums1 and nums2 respectively.

    //Merge nums1 and nums2 into a single array sorted in non-decreasing order.
    //The final sorted array should not be returned by the function,
    //but instead be stored inside the array nums1.
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new()
        {
            ArrayOfElements1 = [1,2,3,0,0,0],
            Integer1 = 3,
            ArrayOfElements2 = [2, 5, 6],
            Integer2 = 3
        },
        new()
        {
            ArrayOfElements1 = [3,0,0,0],
            Integer1 = 1,
            ArrayOfElements2 = [1, 4, 7],
            Integer2 = 3
        },
    ];

    public static void MergeSortedArrayUsingTwoIterationIndices(
        int[] numbers1,
        int numberOfElements1, // < numbers1.Length
        int[] numbers2,
        int numberOfElements2)
    {
        var index1 = numberOfElements1 - 1;
        var index2 = numberOfElements2 - 1;

        // t: O(numberOfElements1 + numberOfElements2)
        // Note:
        //  numberOfElements1 + numberOfElements2
        //  = numbers1.Length
        for (var index
                = numberOfElements1 + numberOfElements2 - 1;
            index >= 0;
            index--)
        {
            // we don't check when index1 < 0
            if (index2 < 0)
            {
                break;
            }

            if (index1 >= 0 && numbers1[index1] > numbers2[index2])
            {
                numbers1[index] = numbers1[index1];
                index1--;
            }
            else
            {
                numbers1[index] = numbers2[index2];
                index2--;
            }
        }
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            MergeSortedArrayUsingTwoIterationIndices(
                testCase.ArrayOfElements1,
                testCase.Integer1,
                testCase.ArrayOfElements2,
                testCase.Integer2);
        }
    }
}
