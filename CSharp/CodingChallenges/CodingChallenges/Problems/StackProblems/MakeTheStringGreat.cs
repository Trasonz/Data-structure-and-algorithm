using CodingChallenges.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.StackProblems;
internal class MakeTheStringGreat
{
    private static readonly List<TestCaseDto<string>> _testCases =
    [
        new() { String1 = "Pp" },
        new() { String1 = "leEeetcode" },
        new() { String1 = "abcCBA" },
    ];

    public static string MakeGood(string _string) // n
    {
        StringBuilder stringBuilder = new();
        var characterLowerUpperDistance = 32;

        for (int index = 0; index < _string.Length; index++)
        {
            if (stringBuilder.Length > 0
                && index > 0
                && Math.Abs(stringBuilder[stringBuilder.Length - 1] - _string[index]) == characterLowerUpperDistance)
            {
                // Remove the last char
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }
            else
            {
                stringBuilder.Append(_string[index]);
            }
        }

        return stringBuilder.ToString();
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(MakeGood(testCase.String1));
        }
    }
}
