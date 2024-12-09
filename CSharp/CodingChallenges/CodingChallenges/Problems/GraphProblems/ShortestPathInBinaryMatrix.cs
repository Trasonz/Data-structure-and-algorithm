using CodingChallenges.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodingChallenges.Problems.GraphProblems;
internal class ShortestPathInBinaryMatrix
{
    private static readonly List<TestCaseDto<int>> _testCases = [
        new() {
            ArrayOfArrays1 = [
                [0,0,0],
                [1,1,0],
                [1,1,0]
            ]
        },

    ];

    private static readonly int[][] _directions = [
    //  top left        top             top right
        [ -1, -1 ],     [ -1, 0 ],      [ -1, 1 ],
    //  left                            right
        [ 0, -1 ],                      [ 0, 1 ],
    //  bottom left     bottom          bottom right
        [ 1, -1 ],      [ 1, 0 ],       [ 1, 1 ]
    ];

    // Check all the possible movements
    private static List<int[]> GetNeighborCells(int rowIndex, int columnIndex, int[][] matrix)
    {
        List<int[]> neighbours = [];

        for (int i = 0; i < _directions.Length; i++)
        {
            int newRowIndex = rowIndex + _directions[i][0];
            int newColumnIndex = columnIndex + _directions[i][1];

            bool isInvalidCell = newRowIndex < 0 || newColumnIndex < 0 ||
                newRowIndex >= matrix.Length || newColumnIndex >= matrix[0].Length ||
                matrix[newRowIndex][newColumnIndex] != 0; // can't move into cell with 1

            if (isInvalidCell)
            {
                continue;
            }

            neighbours.Add([newRowIndex, newColumnIndex]);
        }

        return neighbours;
    }

    public static int ShortestPathBinaryMatrix(int[][] matrix)
    {
        // Firstly, we need to check that the start and target cells are valid.
        // ^1: last element
        if (matrix[0][0] != 0 || matrix[^1][matrix[0].Length - 1] != 0)
        {
            return -1;
        }

        // Set up the BFS

        // cells: store the path of moving
        Queue<int[]> cells = [];
        // Record the starting position at [0, 0]
        cells.Enqueue([0, 0]);

        // Build the visited cells matrix
        bool[][] visitedCells = new bool[matrix.Length][];

        for (int index = 0; index < matrix.Length; index++)
        {
            visitedCells[index] = new bool[matrix[0].Length];
        }

        // Record the starting position
        visitedCells[0][0] = true;

        // Moved only 1 cell at the starting point
        int movedDistance = 1;

        // Carry out the BFS
        while (cells.Count > 0)
        {
            // Process all nodes at the current distance from the top-left cell.
            int numberOfMovingDirections = cells.Count;

            for (int movingCoordinatorIndex = 0; 
                movingCoordinatorIndex < numberOfMovingDirections; 
                movingCoordinatorIndex++)
            {
                int[] cell = cells.Dequeue();

                int rowIndex = cell[0]; // left / right
                int columnIndex = cell[1]; // top / bottom

                bool hasReachedDestination = rowIndex == matrix.Length - 1 && 
                    columnIndex == matrix[0].Length - 1;

                if (hasReachedDestination)
                {
                    return movedDistance;
                }

                foreach (var neighbourCell in GetNeighborCells(rowIndex, columnIndex, matrix))
                {
                    int neighbourRowIndex = neighbourCell[0];
                    int neighbourColumnIndex = neighbourCell[1];

                    if (visitedCells[neighbourRowIndex][neighbourColumnIndex])
                    {
                        continue;
                    }

                    visitedCells[neighbourRowIndex][neighbourColumnIndex] = true;

                    // Store the next cells to move into
                    cells.Enqueue([neighbourRowIndex, neighbourColumnIndex]);
                }
            }

            // We'll now be processing all nodes at current_distance + 1
            movedDistance++;
        }

        // The target was unreachable.
        return -1;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(ShortestPathBinaryMatrix(testCase.ArrayOfArrays1!));
        }
    }
}
