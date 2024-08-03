using CodingChallenges.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.StackProblems;
internal class ValidParentheses
{
    private static readonly List<TestCaseDto<string>> _testCases =
    [
        new() { String1 = "()[]{}" },
        new() { String1 = "{({[]})}" },
    ];

    public static bool IsValidParentheses(string _string) // n
    {
        Dictionary<char, char> bracketMap = [];
        bracketMap.Add('(', ')');
        bracketMap.Add('[', ']');
        bracketMap.Add('{', '}');

        Stack<char> characterStack = [];

        foreach (char character in _string)
        {
            if (bracketMap.ContainsKey(character))
            {
                // Keep collecting the opening brackets
                characterStack.Push(character);
            }
            else
            {                
                if (characterStack.Count == 0)
                {
                    // No opening bracket, but has a closing bracket
                    return false;
                }

                char lastOpenBracket = characterStack.Pop();

                // Opening and closing brackets does not match
                if (bracketMap[lastOpenBracket] != character)
                {
                    return false;
                }
            }
        }

        // All brackets are matched, stack is empty
        return characterStack.Count == 0;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(IsValidParentheses(testCase.String1));
        }
    }
}
