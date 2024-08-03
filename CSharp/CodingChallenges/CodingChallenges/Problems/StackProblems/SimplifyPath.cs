using CodingChallenges.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.StackProblems;
internal class SimplifyPath
{
    private static readonly List<TestCaseDto<string>> _testCases =
    [
        new() { String1 = "/home/" },
        new() { String1 = "/home//foo/" },
        new() { String1 = "/home/user/Documents/../Pictures" },
        new() { String1 = "/.../a/../b/c/../d/./" },
    ];

    public static string SimplifyPathUsingStack(string path) // n
    {
        char a = 'A';
        var b = Char.ToLower(a).Equals(a);
        string[] components = path.Split('/');
        Stack<string> directoryStack = new Stack<string>();

        foreach (string component in components)
        {
            // "." or "" -> current directory
            if (component.Equals(".") || component.Length == 0)
            {
                continue;
            }
            else if (component.Equals(".."))
            {
                // ".." -> remove previous directory
                if (directoryStack.Count > 0)
                {
                    directoryStack.Pop();
                }
            }
            else
            {
                // Finally, a legitimate component name, so we add it
                // to our stack
                directoryStack.Push(component);
            }
        }

        StringBuilder result = new StringBuilder();
        foreach (string directory in directoryStack.Reverse())
        {
            result.Append("/");
            result.Append(directory);
        }

        return result.Length > 0 ? result.ToString() : "/";
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(SimplifyPathUsingStack(testCase.String1));
        }
    }
}
