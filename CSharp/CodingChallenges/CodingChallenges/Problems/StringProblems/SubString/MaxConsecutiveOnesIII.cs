using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.StringProblems.SubString;

internal static class MaxConsecutiveOnesIII
{
    // Given a binary string and an integer k,
    // return the maximum number of consecutive 1's in the array
    // if you can flip at most k 0's.
    //
    // For example, given s = "11100011110" and k = 2, the answer is 6 (11100[1]1111[1]).
    private static readonly List<TestCaseDto<string>> _testCases =
    [
        new() { String1 = "11100011110", Integer1 = 2 },     // -> 11100[1]1111[1]      : 6
        new() { String1 = "01001011", Integer1 = 2 },        // -> 010[1]1[1]11         : 5
        new() { String1 = "110110110110", Integer1 = 4 },    // -> 11[1]11[1]11[1]11[1] : 12
    ];

    public static int FindLengthOfLongestSubStringContainsOnly1ByFlippingK0s(
    this string _string,
    int k)
    {
        var windowLeftIndex = 0;
        var numberOfZeros = 0;
        var subStringMaxLength = 0;

        // t: O(n)
        for (var windowRightIndex = 0; windowRightIndex < _string.Length; windowRightIndex++)
        {
            // Care only '0', '1' will be automatically added and compared with the max length
            if (_string[windowRightIndex] == '0')
            {
                numberOfZeros++;
            }

            // When found the k + 1 '0'
            while (numberOfZeros > k)
            {
                if (_string[windowLeftIndex] == '0')
                {
                    numberOfZeros--;
                }

                windowLeftIndex++;
            }

            int newSubStringLength = windowRightIndex - windowLeftIndex + 1;
            subStringMaxLength = Math.Max(subStringMaxLength, newSubStringLength);
        }

        return subStringMaxLength;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            var result = FindLengthOfLongestSubStringContainsOnly1ByFlippingK0s(
                testCase.String1!,
                testCase.Integer1);
            Console.WriteLine(result);
        }
    }
}
