namespace CodingChallenges.Extensions
{
    internal static class StringExtension
    {
        /*
         * [Tip] Use interation pointers
         * Time complexity: O(n). 
         * Space complexity: O(1). 
         */
        public static bool IsAPalindrome(this string _string)
        {
            var leftIndex = 0;
            var rightIndex = _string.Length - 1;

            while (leftIndex < rightIndex)
            {
                var leftCharacter = _string[leftIndex];
                var rightCharacter = _string[rightIndex];

                if (!leftCharacter.Equals(rightCharacter))
                {
                    return false;
                }

                leftIndex++;
                rightIndex--;
            }

            return true;
        }

        /*
         * [Tip] Use interation pointers.
         * [Info] Practical application
         * Time complexity: O(n + m), with n is _string.Length and m is stringToCheck.Length.
         * Space complexity: O(1).
         */
        public static bool IsASubsequenceOf(
            this string _string,
            string stringToCheck)
        {
            var sortedArray3 = new List<int>();
            var index1 = 0;
            var index2 = 0;

            while (index1 < _string.Length && index2 < stringToCheck.Length)
            {
                if (_string[index1].Equals(stringToCheck[index2]))
                {
                    index1++;
                }

                index2++;
            }

            return index1 == _string.Length;
        }
    }
}
