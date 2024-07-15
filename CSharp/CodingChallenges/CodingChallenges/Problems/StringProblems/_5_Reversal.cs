using CodingChallenges.Extensions;

namespace CodingChallenges.Problems.StringProblems;

internal class _5_Reversal
{
    // Given two strings s and t,
    // return true if s is a subsequence of t,
    // or false otherwise.
    private readonly List<char[]> _testCases =
    [
        ['h', 'e', 'l', 'l', 'o'],
        [],
        ['t', 'e', 'r', 'r', 'y'],
    ];

    public void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.Write($"The reversal of ");

            foreach (var character in testCase)
            {
                Console.Write(character);
            }

            Console.Write($" is ");
            testCase.ReverseV2();

            foreach (var character in testCase)
            {
                Console.Write(character);
            }

            Console.WriteLine();
        }
    }
}
