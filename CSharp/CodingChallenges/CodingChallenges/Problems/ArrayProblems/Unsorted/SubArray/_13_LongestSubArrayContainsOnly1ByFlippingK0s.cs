using CodingChallenges.Extensions;

namespace CodingChallenges.Problems.ArrayProblems.Unsorted.SubArray;

internal class _13_LongestSubArrayContainsOnly1ByFlippingK0s
{
    // Given a binary array and an integer k,
    // return the maximum number of consecutive 1's in the array
    // if you can flip at most k 0's.
    //
    // For example, given s = "11100011110" and k = 2, the answer is 6 (11100[1]1111[1]).
    private readonly Dictionary<List<int>, int> _testCases = new()
    {
        { [1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0], 2},     // -> 11100[1]1111[1]      : 6
        { [1, 1, 1, 0, 0, 0], 1},                    // -> 11100[1]1111[1]      : 4
        { [1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0], 4}   // -> 11[1]11[1]11[1]11[1] : 12
    };

    public void Run()
    {
        foreach (var testCase in _testCases)
        {
            var result = testCase.Key
                .FindLengthOfLongestSubArrayContainsOnly1ByFlippingK0s(testCase.Value);
            Console.WriteLine($"The length of the longest sub-array that contains only '1's with {testCase.Value} flipping times of '0' is {result}");
        }
    }
}
