using CodingChallenges.Extensions;

namespace CodingChallenges.Problems.ArraysProblem.Sorted
{
    internal class _3_Merging2SortedArraysIntoASortedArray
    {
        // Given a sorted array of unique integers and a target integer,
        // return true if there exists a pair of numbers that sum to target, false otherwise.
        // Given a string s, return true if it is a palindrome, false otherwise.
        private readonly Dictionary<List<int>, List<int>> _testCases = new()
        {
            { [1, 2, 4, 6, 9, 10], [3, 5, 8] },
            { [1, 3, 4, 6, 9, 11, 15], [2, 5, 10, 12, 13] },
            { [1, 2, 4, 6, 9, 10], [1, 2, 2, 2, 2, 2, 2, 7] },
            { [], [1] }
        };

        public void Run()
        {
            foreach (var _testCase in _testCases)
            {
                var newSortedArray = _testCase.Key.MergeWithASortedArrayIntoASortedArray(_testCase.Value);
                Console.WriteLine("New sorted array after merged:");

                foreach (var element in newSortedArray)
                {
                    Console.Write($"{element} ");
                }

                Console.WriteLine();
            }
        }
    }
}
