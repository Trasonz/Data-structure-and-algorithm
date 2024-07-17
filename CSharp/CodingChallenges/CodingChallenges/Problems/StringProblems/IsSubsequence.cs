using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.StringProblems;

internal static class IsSubsequence
{
    // Given two strings s and t,
    // return true if s is a subsequence of t,
    // or false otherwise.
    private static readonly List<TestCaseDto<string>> _testCases =
    [
        new() { Element = "abcde", String = "bd" },
        new() { Element = "", String = "" },
        new() { Element = "thinh", String = "th n" },
        new() { Element = "th", String = "thinh" },
    ];

    public static bool IsASubsequenceOf(
        string stringToCheck, // k
        string originalString) // n
    {
        if (stringToCheck.Length > originalString.Length)
        {
            return false;
        }

        var index1 = 0;
        var index2 = 0;

        // t: O(n || k)
        while (index1 < stringToCheck.Length && index2 < originalString.Length)
        {
            if (stringToCheck[index1].Equals(originalString[index2]))
            {
                index1++;

                if (index1 == stringToCheck.Length)
                {
                    return true;
                }
            }

            index2++;
        }

        return index1 == stringToCheck.Length;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(IsASubsequenceOf(testCase.String, testCase.Element!));
        }
    }
}
