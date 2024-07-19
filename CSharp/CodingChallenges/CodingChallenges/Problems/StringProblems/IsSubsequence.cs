using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.StringProblems;

internal static class IsSubsequence
{
    // Given two strings s and t,
    // return true if s is a subsequence of t,
    // or false otherwise.
    private static readonly List<TestCaseDto<string>> _testCases =
    [
        new() { String1 = "abcde", String2 = "bd" },
        new() { String1 = "", String2 = "" },
        new() { String1 = "thinh", String2 = "th n" },
        new() { String1 = "th", String2 = "thinh" },
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
            Console.WriteLine(IsASubsequenceOf(testCase.String2, testCase.String1!));
        }
    }
}
