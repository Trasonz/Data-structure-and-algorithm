using CodingChallenges.Dtos;
using CodingChallenges.Utilities;

namespace CodingChallenges.Problems.ArraysProblem;
internal class FindPlayersWithZeroOrOneLosses
{
    /*
    You are given an integer array matches where matches[i] = [winner_i, loser_i] indicates that 
    the player winner_i defeated player loser_i in a match.

    Return a list answer of size 2 where:
        answer[0] is a list of all players that have not lost any matches.
        answer[1] is a list of all players that have lost exactly one match.

    The values in the two lists should be returned in increasing order.

    Note:

    You should only consider the players that have played at least one match.
    The testcases will be generated such that no two matches will have the same outcome.
    */
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { ArrayOfArraysOfElements = [[3,4],[2,4],[1,3],[2,3],[5,6]] },
        new() { ArrayOfArraysOfElements = [[1,3],[2,3],[3,6],[5,6],[5,7],[4,5],[4,8],[4,9],[10,4],[10,9]] },
        new() { ArrayOfArraysOfElements = [[2,3],[1,3],[5,4],[6,4]] },
    ];

    // [Tip] Use hash map
    // Time complexity: O(n + k), k is the total number of players
    // Space complexity: O(k) 
    public static IList<IList<int>> FindPlayersWithZeroOrOneLossesUsingHashMap(int[][] matches)
    {
        // space: O(k)
        Dictionary<int, int> playerScoreMap = [];

        // time: O(n)
        foreach (var match in matches)
        {
            //winner = match[0];
            //loser = match[1];

            playerScoreMap.TryAdd(match[0], 0);
            playerScoreMap.TryAdd(match[1], 0);
            playerScoreMap[match[1]]--;
        }

        var winners = new List<int>();
        var playersWithOneLoss = new List<int>();

        // time: O(k)
        foreach (var playerScore in playerScoreMap)
        {
            if (playerScore.Value == 0)
            {
                winners.Add(playerScore.Key);
            }

            if (playerScore.Value == -1)
            {
                playersWithOneLoss.Add(playerScore.Key);
            }
        }

        winners.Sort();
        playersWithOneLoss.Sort();

        return [winners, playersWithOneLoss];
    }

    public static void Run()
    {
        Console.WriteLine("Use hash map");

        foreach (var testCase in _testCases)
        {
            var result = FindPlayersWithZeroOrOneLossesUsingHashMap(testCase.ArrayOfArraysOfElements);
            PrintUtility.PrintPrimitiveList(result[0]);
            Console.Write(", ");
            PrintUtility.PrintPrimitiveList(result[1]);
            Console.WriteLine();
        }
    }
}
