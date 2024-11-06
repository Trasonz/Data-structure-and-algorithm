using CodingChallenges.DataStructures;
using CodingChallenges.Dtos;
using CodingChallenges.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodingChallenges.Problems.GraphProblems;
public class NumberOfProvinces
{
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { ArrayOfArrays1 = [
                [1, 1, 0, 0, 0, 0], 
                [1, 1, 1, 0, 0, 0], 
                [0, 1, 1, 0, 0, 0],
                [0, 0, 0, 1, 1, 0],
                [0, 0, 0, 1, 1, 0],
                [0, 0, 0, 0, 0, 1]
            ]
        },
    ];

    public static void CheckNeighborCities(int cityIndex, int[][] matrix, bool[] visitedCities)
    {
        visitedCities[cityIndex] = true;

        for (int neighborCityIndex = 0; neighborCityIndex < matrix.Length; neighborCityIndex++)
        {
            if (matrix[cityIndex][neighborCityIndex] == 1 && !visitedCities[neighborCityIndex])
            {
                CheckNeighborCities(neighborCityIndex, matrix, visitedCities);
            }
        }
    }

    public static int FindCircleNum(int[][] matrix)
    {
        bool[] visitedCities = new bool[matrix.Length];
        int numberOfProvinces = 0;

        for (int cityIndex = 0; cityIndex < matrix.Length; cityIndex++)
        {
            if (!visitedCities[cityIndex])
            {
                numberOfProvinces++;
                CheckNeighborCities(cityIndex, matrix, visitedCities);
            }
        }

        return numberOfProvinces;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(FindCircleNum(testCase.ArrayOfArrays1!));
        }
    }
}
