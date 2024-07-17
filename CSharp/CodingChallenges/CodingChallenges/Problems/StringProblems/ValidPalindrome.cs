using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.StringProblems;

public static class ValidPalindrome
{
    // Given a string s, return true if it is a palindrome, false otherwise.
    private static readonly List<TestCaseDto<string>> _testCases =
    [
        new() { Element = "A man, a plan, a canal: Panama" },
        new() { Element = "hello" },
        new() { Element = "racecar" },
        new() { Element = "reer" },
    ];

    public static bool IsAPalindrome(string _string)
    {
        if (_string.Length == 1)
        {
            return true;
        }

        var leftIndex = 0;
        var rightIndex = _string.Length - 1;

        // t: O(n)
        while (leftIndex < rightIndex)
        {
            if (!char.IsLetterOrDigit(_string[leftIndex]))
            {
                leftIndex++;
                continue;
            }

            if (!char.IsLetterOrDigit(_string[rightIndex]))
            {
                rightIndex--;
                continue;
            }

            if (!char.ToLower(_string[leftIndex]).Equals(char.ToLower(_string[rightIndex])))
            {
                return false;
            }

            leftIndex++;
            rightIndex--;
        }

        return true;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.Write($"Is {testCase} a palindrome? - ");
            Console.WriteLine(IsAPalindrome(testCase.Element!));
        }
    }
}
