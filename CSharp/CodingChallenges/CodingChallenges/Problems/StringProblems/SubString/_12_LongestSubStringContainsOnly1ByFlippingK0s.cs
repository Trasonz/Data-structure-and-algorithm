using CodingChallenges.Extensions;

namespace CodingChallenges.Problems.StringProblems.SubString
{
    internal class _12_LongestSubStringContainsOnly1ByFlippingK0s
    {
        // Given a binary string and an integer k,
        // return the maximum number of consecutive 1's in the array
        // if you can flip at most k 0's.
        //
        // For example, given s = "11100011110" and k = 2, the answer is 6 (11100[1]1111[1]).
        private readonly Dictionary<string, int> _testCases = new()
        {
            { "11100011110", 2},   // -> 11100[1]1111[1]      : 6
            { "01001011", 2},      // -> 010[1]1[1]11         : 5
            { "110110110110", 4}   // -> 11[1]11[1]11[1]11[1] : 12
        };

        public void Run()
        {
            foreach (var _testCase in _testCases)
            {
                var result = _testCase.Key.FindLengthOfLongestSubStringContainsOnly1ByFlippingK0s(_testCase.Value);
                Console.WriteLine($"The length of the longest sub-string that contains only '1's with {_testCase.Value} flipping times of '0' is {result}");
            }
        }
    }
}
