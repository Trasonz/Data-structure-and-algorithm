namespace CodingChallenges.Problems.ArraysProblem.Sorted
{
    internal class MergingIntoASortedArray
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

        /*
         * [Tip] Use interation pointers for two or many arrays.
         * Time complexity: O(n + m), with n is sortedArray1.Count and m is sortedArray2.Count.
         * Space complexity: O(1). (don't include the extra space for sortedArray3 - output)
         */
        public List<int> Merge2SortedArraysIntoASortedArray(
            List<int> sortedArray1,
            List<int> sortedArray2)
        {
            var sortedArray3 = new List<int>();
            var index1 = 0;
            var index2 = 0;

            while (index1 < sortedArray1.Count && index2 < sortedArray2.Count)
            {
                if (sortedArray1[index1] < sortedArray2[index2])
                {
                    sortedArray3.Add(sortedArray1[index1]);
                    index1++;
                }
                else // sortedArray1[index1] >= sortedArray2[index2]
                {
                    sortedArray3.Add(sortedArray2[index2]);
                    index2++;
                }
            }

            // Note that only one of these loops below would run
            // because the length of 2 arrays may not equal.

            while (index1 < sortedArray1.Count)
            {
                sortedArray3.Add(sortedArray1[index1]);
                index1++;
            }

            while (index2 < sortedArray2.Count)
            {
                sortedArray3.Add(sortedArray2[index2]);
                index2++;
            }

            return sortedArray3;
        }

        public void Run()
        {
            foreach (var _testCase in _testCases)
            {
                var newSortedArray = Merge2SortedArraysIntoASortedArray(_testCase.Key, _testCase.Value);
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
