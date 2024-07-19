using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.StringProblems;

internal static class CheckIfTheSentenceIsPangram
{
    // A pangram is a sentence where every letter of the English alphabet appears at least once.
    // Given a string sentence containing only lowercase English letters,
    // return true if sentence is a pangram, or false otherwise.
    private static readonly List<TestCaseDto<string>> _testCases1 =
    [
        new() { String1 = "thequickbrownfoxjumpsoverthelazydog" },
        new() { String1 = "thequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydogthequickbrownfoxjumpsoverthelazydogthequickbraasdownfoxasdjumpsasdoverthelazydog" },
        new() { String1 = "thinh" }
    ];

    /*
     * [Tip] Use hash set
     * Time complexity: O(n) 
     * Space complexity: O(k).
     */
    public static bool IsPangramSentence(string sentence)
    {
        HashSet<char> characterSet = [];
        const int numberOfEnglishLetters = 26;

        foreach (char character in sentence)
        {
            characterSet.Add(character);

            if (characterSet.Count == numberOfEnglishLetters)
            {
                return true;
            }
        }

        return false;
    }

    public static void Run()
    {
        Console.WriteLine("Hash set:");
        foreach (var testCase in _testCases1)
        {
            Console.WriteLine(IsPangramSentence(testCase.String1!));
        }
    }
}
