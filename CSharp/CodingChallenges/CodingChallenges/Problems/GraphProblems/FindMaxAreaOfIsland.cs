using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.GraphProblems;
internal class FindMaxAreaOfIsland
{
    private static readonly List<TestCaseDto<int>> _testCases = [
        new() {
            ArrayOfArrays1 = [
                [0,0,1,0,0,0,0,1,0,0,0,0,1],
                [0,0,0,0,0,0,0,1,1,1,0,0,0],
                [0,1,1,0,1,0,0,0,0,0,0,0,0],
                [0,1,0,0,1,1,0,0,1,0,1,0,0],
                [0,1,0,0,1,1,0,0,1,1,1,0,0],
                [0,0,0,0,0,0,0,0,0,0,1,0,0],
                [0,1,0,0,1,0,0,1,1,1,0,0,0],
                [1,1,1,1,1,1,1,1,1,0,0,0,0]
            ]
        },

    ];

    public static int CalculateArea(int[][] matrix, bool[][] visitedCells, int rowIndex, int columnIndex)
    {
        bool isInvalidIndex = rowIndex < 0 || rowIndex >= matrix.Length ||
            columnIndex < 0 || columnIndex >= matrix[0].Length;

        if (isInvalidIndex)
        {
            return 0;
        }

        bool isCellVisitedOrNotValid = visitedCells[rowIndex][columnIndex] || 
            matrix[rowIndex][columnIndex] == 0;

        if (isCellVisitedOrNotValid)
        {
            return 0;
        }

        visitedCells[rowIndex][columnIndex] = true;

        return 1 + 
            CalculateArea(matrix, visitedCells, rowIndex + 1, columnIndex) + 
            CalculateArea(matrix, visitedCells, rowIndex - 1, columnIndex) + 
            CalculateArea(matrix, visitedCells, rowIndex, columnIndex - 1) + 
            CalculateArea(matrix, visitedCells, rowIndex, columnIndex + 1);
    }

    public static int MaxAreaOfIsland(int[][] matrix)
    {
        // columns: grid[0].Length 
        // row    : grid.Length
        var visitedCells = new bool[matrix.Length][];
        int ans = 0;

        for (int index = 0; index < matrix.Length; index++)
        {
            visitedCells[index] = new bool[matrix[0].Length];
        }

        for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < matrix[0].Length; columnIndex++)
            {
                ans = Math.Max(ans, CalculateArea(matrix, visitedCells, rowIndex, columnIndex));
            }
        }

        return ans;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(MaxAreaOfIsland(testCase.ArrayOfArrays1!));
        }
    }
}
