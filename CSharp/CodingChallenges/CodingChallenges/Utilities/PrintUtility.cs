
using CodingChallenges.DataStructures;

namespace CodingChallenges.Utilities;

internal static class PrintUtility
{
    public static void PrintPrimitiveList<T>(IList<T> array)
    {
        if (array.Count == 0)
        {
            Console.Write("[]");
            return;
        }

        Console.Write("[");

        for (var index = 0; index < array.Count; index++)
        {
            if (index != array.Count - 1)
            {
                Console.Write($"{array[index]}, ");
            }
            else
            {
                Console.Write($"{array[index]}]");
            }
        }
    }

    public static void PrintLinkedList<T>(MyNode<T> node)
    {
        while (node != null)
        {
            Console.Write(node.Value);
            node = node.Next;

            if (node != null)
            {
                Console.Write(" -> ");
            }
        }
    }

    public static void PrintNode<T>(MyNode<T> node)
    {
        Console.Write(node.Value);
    }

    public static void PrintPrimitiveArray<T>(T[] array)
    {
        Console.Write("[");
        for (var index = 0; index < array.Length; index++)
        {
            if (index != array.Length - 1)
            {
                Console.Write($"{array[index]}, ");
            }
            else
            {
                Console.Write($"{array[index]}]");
            }
        }
    }
}
