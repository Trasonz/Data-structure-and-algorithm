namespace CodingChallenges.Extensions;

internal static class StringExtension
{


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

    /*
     * [Tip] Use dynamic sliding window.
     * Time complexity: O(n).
     * Space complexity: O(1).
     */
    public static int FindLengthOfLongestSubStringContainsOnly1ByFlippingK0s(
        this string _string,
        int k)
    {
        var windowLeftIndex = 0;
        var numberOfZeros = 0;
        var subStringMaxLength = 0;

        // 11100011110
        for (var windowRightIndex = 0; windowRightIndex < _string.Length; windowRightIndex++)
        {
            // Care only '0', '1' already added and compared with the max length
            if (_string[windowRightIndex] == '0')
            {
                numberOfZeros++;
            }

            // When found the k + 1 '0'
            while (numberOfZeros > k)
            {
                if (_string[windowLeftIndex] == '0')
                {
                    numberOfZeros--;
                }

                windowLeftIndex++;
            }

            int newSubStringLength = windowRightIndex - windowLeftIndex + 1;
            subStringMaxLength = Math.Max(subStringMaxLength, newSubStringLength);
        }

        return subStringMaxLength;
    }
}
