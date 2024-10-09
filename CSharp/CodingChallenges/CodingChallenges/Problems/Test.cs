using CodingChallenges.Dtos;

namespace CodingChallenges.Problems;

public class Test
{
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { 
            Array1 = [1,4,2], Array2 = [1,1,5,2,3], Array3 = [2,3,4,5,6]
        },
    ];

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine();
        }
    }
}

public class Completed
{
    public static int[] NextGreaterElement(int[] numbers1, int[] numbers2)
    {
        // A stack to store previous unchecked number
        Stack<int> uncheckedNumbers = [];

        // Map numbers and their next greater number on their rightIndex
        Dictionary<int, int> numberMap = [];

        // Loop through numbers2 to build a hash map
        foreach (int number in numbers2)
        {
            // While the stack is not empty and the latest element is
            // smaller than the current number in numbers2
            while (uncheckedNumbers.Count > 0 &&
                uncheckedNumbers.Peek() < number)
            {
                // Pop the latest element from the stack and
                // put it to the hash map
                numberMap.Add(uncheckedNumbers.Pop(), number);
            }

            // Put the number in the stack
            uncheckedNumbers.Push(number);
        }

        int[] result = new int[numbers1.Length];

        for (int index = 0; index < numbers1.Length; index++)
        {
            // If the hash map contains the number, return the
            // value. Else, return -1
            result[index] = numberMap.TryGetValue(numbers1[index], out int value)
                ? value
                : -1;
        }

        return result;
    }

    public int MinSwaps(string _string)
    {
        int openBrackets = 0;
        int minAddsRequired = 0;

        foreach (char character in _string)
        {
            if (character == '(')
            {
                openBrackets++;
            }
            else
            {
                // If an open bracket exists, match it with the closing one
                // If not, we need to add an open bracket.
                if (openBrackets > 0)
                {
                    openBrackets--;
                }
                else
                {
                    minAddsRequired++;
                }
            }
        }

        // Add the remaining open brackets as closing brackets would be required.
        return minAddsRequired + openBrackets;
    }

    private static long GetCoins(int heroPower, long[][] monsterCoinMap)
    {
        int leftIndex = 0;
        int rightIndex = monsterCoinMap.Length - 1;

        while (leftIndex <= rightIndex)
        {
            int mid = (leftIndex + rightIndex) / 2;

            if (heroPower < monsterCoinMap[mid][0])
            {
                rightIndex = mid - 1;
            }
            else
            {
                leftIndex = mid + 1;
            }
        }

        if (leftIndex == 0 && heroPower < monsterCoinMap[leftIndex][0])
        {
            // The hero can't defeat any monsters
            return 0;
        }

        // Return the prefix sum at the rightIndex index

        return monsterCoinMap[rightIndex][1];
    }

    public static long[] MaximumCoins(int[] heroPowers, int[] monsterPowers, int[] coins)
    {
        // Create an array of arrays for mapping monster power and coin
        long[][] monsterCoinMap = new long[monsterPowers.Length][];

        // Mapping monsters and coins 
        for (int index = 0; index < monsterPowers.Length; index++)
        {
            monsterCoinMap[index] =
            [
                monsterPowers[index],
                coins[index]
            ];
        }

        // Sort the mapping in ascending order of monsters' power
        // to apply binary search
        Array.Sort(
            monsterCoinMap,
            (firstElement, secondElement) =>
                firstElement[0].CompareTo(secondElement[0])
        );

        // Calculate the prefix sum of the monsters' power.
        long prefixSum = monsterCoinMap[0][1];

        for (int index = 1; index < monsterCoinMap.Length; index++)
        {
            prefixSum += monsterCoinMap[index][1];
            monsterCoinMap[index][1] = prefixSum;
        }

        // Create an array to store the heroTotalCoins
        long[] heroTotalCoins = new long[heroPowers.Length];

        // For each hero, find the strongest monster he can defeat. When a hero
        // can defeat a monster, he can also defeat all the weaker monsters and
        // get sum of all the coins from them.
        for (int index = 0; index < heroPowers.Length; index++)
        {
            heroTotalCoins[index] = GetCoins(heroPowers[index], monsterCoinMap);
        }

        return heroTotalCoins;
    }
}
