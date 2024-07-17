using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.StringProblems;

internal static class ReverseString
{
    // Write a function that reverses a string.
    // The input string is given as an array of characters s.
    private static readonly List<TestCaseDto<char>> _testCases =
    [
        new() { ArrayOfElements1 = ['h', 'e', 'l', 'l', 'o'] },
        new() { ArrayOfElements1 = [] },
        new() { ArrayOfElements1 = ['t', 'e', 'r', 'r', 'y'] },
    ];

    public static void Reverse(char[] characters)
    {
        var leftIndex = 0;
        var rightIndex = characters.Length - 1;

        // t: O(n)
        while (leftIndex < rightIndex)
        {
            (characters[rightIndex], characters[leftIndex])
                = (characters[leftIndex], characters[rightIndex]);
            leftIndex++;
            rightIndex--;
        }
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Reverse(testCase.ArrayOfElements1);

            foreach (var character in testCase.ArrayOfElements1)
            {
                Console.Write(character);
            }

            Console.WriteLine();
        }
    }
}
