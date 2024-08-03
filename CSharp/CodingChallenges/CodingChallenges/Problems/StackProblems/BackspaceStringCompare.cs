using CodingChallenges.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.StackProblems;
internal class BackspaceStringCompare
{
    private static readonly List<TestCaseDto<string>> _testCases =
    [
        new() { String1 = "ab#c", String2 = "ad#c" },
        new() { String1 = "y#fo##f", String2 = "y#f#o##f" },
    ];

    public static StringBuilder Backspace(string _string)
    {
        StringBuilder stringBuilder = new();

        foreach (char character in _string)
        {
            if (character == '#')
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Remove(stringBuilder.Length - 1, 1);
                }
            }
            else
            {
                stringBuilder.Append(character);
            }
        }

        return stringBuilder;
    }

    public static bool BackspaceCompare(string _string1, string _string2)
    {
        return Backspace(_string1).Equals(Backspace(_string2));
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(BackspaceCompare(testCase.String1, testCase.String2));
        }
    }
}
