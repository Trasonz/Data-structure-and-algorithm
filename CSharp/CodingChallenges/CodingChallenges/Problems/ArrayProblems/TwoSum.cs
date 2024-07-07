using CodingChallenges.Dtos;
using CodingChallenges.Utilities;

namespace CodingChallenges.Problems.ArrayProblems
{
    internal class TwoSum
    {
        // Given a sorted array of unique integers and a target integer,
        // return true if there exists a pair of sortedNumbers that sum to target, false otherwise.
        // Given a string s, return true if it is a palindrome, false otherwise.
        private readonly List<TestCaseDto<int>> _testCases =
        [
            new() 
            {
                ArrayOfElements = [2, 7, 11, 15],
                Integer = 9,
                ExpectedArrayOfIntegers = [0, 1]
            },
            new() 
            {
                ArrayOfElements = [3, 2, 4],
                Integer = 6,
                ExpectedArrayOfIntegers = [1, 2]
            },
            new() 
            {
                ArrayOfElements = [3, 3],
                Integer = 6,
                ExpectedArrayOfIntegers = [0, 1] 
            },
            new() 
            {
                ArrayOfElements = [1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1], 
                Integer = 11,
                ExpectedArrayOfIntegers = [5, 11]
            }
        ];

        /*
         * [Tip] Use interation pointers
         * Time complexity: O(n), with n is sortedNumbers.Count. 
         * Space complexity: O(1). 
         */
        public static bool HasTwoSumInSortedArray(
            int[] sortedNumbers,
            int k)
        {
            int leftIndex = 0;
            int rightIndex = sortedNumbers.Length - 1;

            while (leftIndex < rightIndex)
            {
                var sum = sortedNumbers[leftIndex] + sortedNumbers[rightIndex];

                if (sum == k)
                {
                    // sum == k
                    return true;
                }

                if (sum > k)
                {
                    rightIndex--;
                    continue;
                }

                if (sum < k)
                {
                    leftIndex++;
                    continue;
                }
            }

            return false;
        }

        /*
         * [Tip] Use interation pointers
         * Time complexity: O(n), with n is sortedNumbers.Count. 
         * Space complexity: O(1). 
         */
        public static int[] FindTwoIndicesHasSumEqualTargetNumberInASortedArray(
            int[] numbers,
            int k)
        {
            int leftIndex = 0;
            int rightIndex = numbers.Length - 1;

            while (leftIndex < rightIndex)
            {
                var sum = numbers[leftIndex] + numbers[rightIndex];

                if (sum == k)
                {
                    break;
                }

                if (sum > k)
                {
                    rightIndex--;
                    continue;
                }

                if (sum < k)
                {
                    leftIndex++;
                    continue;
                }
            }

            return [leftIndex, rightIndex];
        }

        /*
         * [Tip] Use Hash map
         * Time complexity: O(n)
         * Space complexity: O(1). 
         */
        public static int[] FindTwoIndicesHasSumEqualTargetNumberInAnUnsortedArray(
            int[] numbers,
            int targetSum)
        {
            Dictionary<int, int> indices = [];

            for (int index = 0; index < numbers.Length; index++)
            {
                var secondNumber = targetSum - numbers[index];

                if (indices.TryGetValue(secondNumber, out int value))
                {
                    return [index, value];
                }
                else
                {
                    // first number trở thành second number
                    // của một số tại 1 index khác trong mảng
                    indices.TryAdd(numbers[index], index);
                }
            }

            return [-1];
        }

        public void Run()
        {
            Console.WriteLine("Unsorted array, 2 indices:");
            foreach (var _testCase in _testCases)
            {
                PrintUtility.PrintPrimitiveArray(
                    FindTwoIndicesHasSumEqualTargetNumberInAnUnsortedArray(
                        _testCase.ArrayOfElements!,
                        _testCase.Integer
                    )
                );
            }
        }
    }
}
