using CodingChallenges.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.GraphProblems;
internal class NumberOfIslands
{
    private static readonly List<TestCaseDto<char>> _testCases =
    [
        new() { ArrayOfArrays1 = [
              ['1','1','0','0','1'],
              ['1','1','0','1','1'],
              ['0','0','1','0','0'],
              ['0','0','0','1','1']
            ]
        },
    ];

    public static void CheckIsland(char[][] grid, int rowIndex, int columnIndex)
    {
        if (rowIndex < 0 || columnIndex < 0 ||
            // grid.Length: number of rows
            // grid[0].Length: number of columns
            rowIndex >= grid.Length || columnIndex >= grid[0].Length || 
            grid[rowIndex][columnIndex] == '0') 
        {
            return;
        }

        grid[rowIndex][columnIndex] = '0';

        CheckIsland(grid, rowIndex - 1, columnIndex);
        CheckIsland(grid, rowIndex + 1, columnIndex);
        CheckIsland(grid, rowIndex, columnIndex - 1);
        CheckIsland(grid, rowIndex, columnIndex + 1);
    }

    public static int NumIslands(char[][]? grid)
    {
        if (grid == null || grid.Length == 0)
        {
            return 0;
        }

        int num_islands = 0;

        for (int rowIndex = 0; rowIndex < grid.Length; ++rowIndex)
        {
            for (int columnIndex = 0; columnIndex < grid[0].Length; ++columnIndex)
            {
                if (grid[rowIndex][columnIndex] == '1')
                {
                    ++num_islands;
                    CheckIsland(grid, rowIndex, columnIndex);
                }
            }
        }

        return num_islands;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(NumIslands(testCase.ArrayOfArrays1!));
        }
    }
}
