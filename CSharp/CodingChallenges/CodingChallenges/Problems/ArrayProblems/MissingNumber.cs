using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.ArrayProblems;

internal static class MissingNumber
{
    // Given an array nums containing n distinct numbers in the range [0, n],
    // return the only number in the range that is missing from the array.
    // Example: Input: nums = [3,0,1]
    // Output: 2
    // Explanation: 2 is the missing number in the range[0, 3].
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { Array1 = [3, 0, 1] },
        new() { Array1 = [0, 1] },
        new() { Array1 = [9, 6, 4, 2, 3, 5, 7, 0, 1] },
    ];

    /*
     * [Tip] Use math
     * Time complexity: O(n) 
     * Space complexity: O(1). 
     */
    public static int FindMissingNumberUsingGaussFormula(int[] numbers)
    {
        int totalSum = numbers.Length * (numbers.Length + 1) / 2;
        int subSum = numbers.Sum();

        return totalSum - subSum;
    }

    /*
     * [Tip] Use hash set
     * Time complexity: O(n) 
     * Space complexity: O(1). 
     */
    public static int FindMissingNumberUsingHashSet(int[] numbers)
    {
        HashSet<int> numberSet = [.. numbers]; // O(n)

        for (int index = 0; index <= numbers.Length; index++)
        {
            if (!numberSet.Contains(index))
            {
                return index;
            }
        }

        return -1;
    }

    public static void Run()
    {
        Console.WriteLine("Hash set:");
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(FindMissingNumberUsingHashSet(testCase.Array1!));
        }

        Console.WriteLine("Gauss' formula:");
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(FindMissingNumberUsingGaussFormula(testCase.Array1!));
        }
    }
}
