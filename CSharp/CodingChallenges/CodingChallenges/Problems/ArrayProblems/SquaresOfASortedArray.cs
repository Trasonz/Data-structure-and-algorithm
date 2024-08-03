using CodingChallenges.Dtos;
using CodingChallenges.Utilities;

namespace CodingChallenges.Problems.ArrayProblems;

internal static class SquaresOfASortedArray
{
    // Given a sorted integer array,
    // return an array of the squares of each number, and it is sorted.
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { Array1 = [-4, -1, 0, 3, 10] },
        new() { Array1 = [-7, -3, 2, 3, 11] },
        new() { Array1 = [-7, -3, 2, 3, 6, 11] },
    ];

    public static int[] SquareAndSortUsingTwoIterationIndices(int[] numbers)
    {
        var leftIndex = 0;
        var rightIndex = numbers.Length - 1;
        int[] result = new int[numbers.Length];

        // t: O(n)
        for (var index = numbers.Length - 1; index >= 0; index--)
        {
            // So sánh để tìm thằng nào lớn hơn
            // từ ngoài vào trong (dùng left và right)
            // thằng nào lớn hơn thì nhét vào result
            // từ cuối danh sách trở về index 0
            if (Math.Abs(numbers[leftIndex]) > Math.Abs(numbers[rightIndex]))
            {
                result[index] = numbers[leftIndex] * numbers[leftIndex];
                leftIndex++;
            }
            else
            {
                result[index] = numbers[rightIndex] * numbers[rightIndex];
                rightIndex--;
            }
        }

        return result;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.Write($"The square of array ");

            PrintUtility.PrintPrimitiveList(testCase.Array1);

            Console.Write($" is ");
            var result = SquareAndSortUsingTwoIterationIndices(testCase.Array1);

            PrintUtility.PrintPrimitiveArray(result);

            Console.WriteLine();
        }
    }
}
