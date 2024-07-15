using CodingChallenges.Extensions;

namespace CodingChallenges.Problems.StringProblems.SubString;

internal class _8_LongestSubStringContainsOnly1ByFlippingA0s
{
    // You are given a binary string s (a string containing only "0" and "1").
    // You may choose up to one "0" and flip it to a "1".
    // What is the length of the longest substring achievable that contains only "1"?
    //
    // For example, given s = "1101100111", the answer is 5.
    // If you perform the flip at index 2, the string becomes 1111100111.
    private readonly List<string> _testCases =
    [
        "1101100111",   // -> 11[1]1100111    : 5
        "11001011",     // -> 11001[1]11      : 4
        "110111110111"  // -> 11011111[1]111  : 9
    ];

    public void Run()
    {
        foreach (var testCase in _testCases)
        {
            var result = testCase.FindLengthOfLongestSubStringContainsOnly1ByFlippingK0s(1);
            Console.WriteLine($"The length of the longest sub-string that contains only '1's with one flip of '0' is {result}");
        }
    }
}
