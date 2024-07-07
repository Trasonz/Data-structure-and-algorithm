using CodingChallenges.Extensions;

namespace CodingChallenges.Problems.StringProblems
{
    public class _1_Palindrome
    {
        // Given a string s, return true if it is a palindrome, false otherwise.
        private readonly List<string> _testCases =
        [
            "hello",
            "racecar",
            "reer"
        ];


        public void Run()
        {
            foreach (var _testCase in _testCases)
            {
                Console.Write($"Is {_testCase} a palindrome? - ");
                Console.WriteLine(_testCase.IsAPalindrome());
            }
        }
    }
}
