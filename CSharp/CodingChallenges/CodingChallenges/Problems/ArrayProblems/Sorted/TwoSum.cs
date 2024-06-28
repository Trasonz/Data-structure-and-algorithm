namespace CodingChallenges.Problems.ArrayProblems.Sorted
{
    internal class TwoSum
    {
        // Given a sorted array of unique integers and a target integer,
        // return true if there exists a pair of numbers that sum to target, false otherwise.
        // Given a string s, return true if it is a palindrome, false otherwise.
        private readonly Dictionary<List<int>, int> _testCases = new()
        {
            { [1, 2, 4, 6, 7, 9, 14, 15], 13 },
            { [1, 2, -4, 6, 7, 9, 14, 15], 10 },
            { [1, 2, 4, 6, -7, 9, 14, 15], 0 },
            { [1, 2, 4, 6, -7, 9, 14, 15], -6 }
        };

        /*
         * [Tip] Use interation pointers
         * Time complexity: O(n), with n is numbers.Count. 
         * Space complexity: O(1). 
         */
        public bool HasSumOf2ElementsEqualTargetNumber(
            List<int> numbers, 
            int targetNumber)
        {
            int leftIndex = 0;
            int rightIndex = numbers.Count - 1;

            while (leftIndex < rightIndex)
            {
                var sum = numbers[leftIndex] + numbers[rightIndex];

                if (sum > targetNumber)
                {
                    rightIndex--;
                    continue;
                }

                if (sum < targetNumber)
                {
                    leftIndex++;
                    continue;
                }

                if (sum == targetNumber)
                {
                    // sum == targetNumber
                    return true;
                }
            }

            return false;
        }

        public void Run()
        {
            foreach (var _testCase in _testCases)
            {
                Console.WriteLine(HasSumOf2ElementsEqualTargetNumber(_testCase.Key, _testCase.Value));
            }
        }
    }
}
