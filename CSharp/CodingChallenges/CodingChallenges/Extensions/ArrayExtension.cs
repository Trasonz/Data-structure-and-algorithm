namespace CodingChallenges.Extensions
{
    internal static class ArrayExtension
    {

        /*
         * [Tip] Use interation pointers for two or many arrays.
         * Time complexity: O(n + m), with n is sortedArray1.Count and m is sortedArray2.Count.
         * Space complexity: O(1). (don't include the extra space for sortedArray3 - output)
         */
        public static List<int> MergeWithASortedArrayIntoASortedArray(
            this List<int> sortedArray1,
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

        /*
         * [Tip] Use interation pointers.
         * [Info] Practical application
         * Time complexity: O(n)
         * Space complexity: O(1).
         */
        public static void ReverseV2(this char[] characters)
        {
            var leftIndex = 0;
            var rightIndex = characters.Length - 1;

            while (leftIndex < rightIndex)
            {
                (characters[rightIndex], characters[leftIndex]) = (characters[leftIndex], characters[rightIndex]);
                leftIndex++;
                rightIndex--;
            }
        }

        /*
         * [Tip] Use interation pointers.
         * Time complexity: O(n)
         * Space complexity: O(1). (don't include the extra space for output)
         */
        public static int[] SquareAndSort(this List<int> numbers)
        {
            var leftIndex = 0;
            var rightIndex = numbers.Count - 1;
            int[] result = new int[numbers.Count];

            for (var index = numbers.Count - 1; index >= 0; index--)
            {
                // So sánh để tìm thằng nào lớn hơn từ ngoài vào trong (dùng left và right)
                // thằng nào lớn hơn thì nhét vào result từ cuối danh sách trở về index 0
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

        /*
         * [Tip] Use dynamic sliding window.
         * Time complexity: O(n)
         * Space complexity: O(1).
         */
        public static int FindLengthOfLongestSubArrayHasSumLessThanOrEqualK(this List<int> numbers, int k)
        {
            var windowLeftIndex = 0;
            var sum = 0;
            var subArrayMaxLength = 0;

            for (var windowRightIndex = 0; windowRightIndex < numbers.Count; windowRightIndex++)
            {
                sum += numbers[windowRightIndex];

                // if sum > k
                while (sum > k)
                {
                    sum -= numbers[windowLeftIndex];
                    windowLeftIndex++;
                }

                int newSubArrayLength = windowRightIndex - windowLeftIndex + 1;
                subArrayMaxLength = Math.Max(subArrayMaxLength, newSubArrayLength);
            }

            return subArrayMaxLength;
        }

        /*
         * [Tip] Use dynamic sliding window.
         * Time complexity: O(n)
         * Space complexity: O(1).
         */
        public static int FindNumberOfSubArraysHasProductLessThanK(this List<int> numbers, int k)
        {
            if (k <= 1)
            {
                return 0;
            }

            var windowLeftIndex = 0;
            var product = 1;
            var numberOfSubArrays = 0;

            // 10, 5, 2, 6
            // thuật toán sliding window: [10], [10, 5], [5, 2], [5, 2, 6]
            // [10]: gồm [10]
            // [10, 5]: size = 2 => gồm [10, 5] và [5]
            // [5, 2]: size = 2 => gồm [5, 2] và [2]
            // [5, 2, 6]: size = 3 => gồm [5, 2, 6], [2, 6], [6]
            // => 8 sub-arrays
            for (var windowRightIndex = 0; windowRightIndex < numbers.Count; windowRightIndex++)
            {
                product *= numbers[windowRightIndex];

                while (product >= k)
                {
                    product /= numbers[windowLeftIndex];
                    windowLeftIndex++;
                }

                numberOfSubArrays += windowRightIndex - windowLeftIndex + 1;
            }

            return numberOfSubArrays;
        }

        /*
         * [Tip] Use fixed sliding window.
         * Time complexity: O(n)
         * Space complexity: O(1).
         */
        public static int FindSubArrayWithLengthKHavingMaxSum(this List<int> numbers, int k)
        {
            if (k > numbers.Count)
            {
                throw new ArgumentException("k is larger than the number of elements in the array");
            }

            var sum = 0;

            // Init the fixed window
            for (var index = 0; index < k; index++)
            {
                sum += numbers[index];
            }

            var maxSum = sum;

            for (var index = k; index < numbers.Count; index++)
            {
                // + new right value, - left value
                sum += numbers[index] - numbers[index - k];
                maxSum = Math.Max(maxSum, sum);
            }

            return maxSum;
        }

        /*
         * [Tip] Use fixed sliding window.
         * Time complexity: O(n)
         * Space complexity: O(1).
         */
        public static double FindSubArrayWithLengthKHavingMaxAverage(
            this List<int> numbers,
            int k)
        {
            if (k > numbers.Count)
            {
                throw new ArgumentException("k is larger than the number of elements in the array");
            }

            double sum = 0;

            // Init the fixed window
            for (var index = 0; index < k; index++)
            {
                sum += numbers[index];
            }

            double maxAverage = sum / k;

            for (var index = k; index < numbers.Count; index++)
            {
                // + new right value, - left value
                sum += numbers[index] - numbers[index - k];
                double average = sum / k;
                maxAverage = Math.Max(maxAverage, average);
            }

            return Math.Round(maxAverage, 5);
        }

        /*
         * [Tip] Use dynamic sliding window.
         * Time complexity: O(n).
         * Space complexity: O(1).
         */
        public static int FindLengthOfLongestSubArrayContainsOnly1ByFlippingK0s(
            this List<int> numbers,
            int k)
        {
            var windowLeftIndex = 0;
            int windowRightIndex = 0;

            // [1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0], k = 2
            for (windowRightIndex = 0; windowRightIndex < numbers.Count; windowRightIndex++)
            {
                // Giảm k khi gặp 0
                if (numbers[windowRightIndex] == 0)
                {
                    k--;
                }

                // Khi k < 0 <=> dùng hết số lượng số 0 có thể được có trong sub-array
                if (k < 0)
                {
                    // Nếu vị trí bên trái là 0 thì cộng 1 vào k để tăng độ dài window
                    if (numbers[windowLeftIndex] == 0)
                    {
                        k++;
                    }

                    // tăng left index <=> giữ nguyên được độ dài của window
                    windowLeftIndex++;
                }
            }

            return windowRightIndex - windowLeftIndex;
        }
    }
}
