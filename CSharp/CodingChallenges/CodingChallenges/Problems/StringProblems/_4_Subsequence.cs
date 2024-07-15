using CodingChallenges.Extensions;

namespace CodingChallenges.Problems.StringProblems;

internal class _4_Subsequence
{
    // Given two strings s and t,
    // return true if s is a subsequence of t,
    // or false otherwise.
    private readonly Dictionary<string, string> _testCases = new()
    {
        { "bd", "abcde" },
        { "", "" },
        { "th n", "thinh" },
        { "thinh", "th" }
    };

    public void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine($"Is '{testCase.Key}' a subsequence of '{testCase.Value}'? - {testCase.Key.IsASubsequenceOf(testCase.Value)}");
        }
    }
}
