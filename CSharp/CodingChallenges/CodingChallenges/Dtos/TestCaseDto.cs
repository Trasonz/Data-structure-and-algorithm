
using CodingChallenges.DataStructures;

namespace CodingChallenges.Dtos;

public class TestCaseDto<T>
{
    public T[] Array1 = [];
    public T[] Array2 = [];
    public T[][] ArrayOfArrays1 = [];
    public T[] ExpectedArray = [];

    public List<T> List1 = [];
    public List<List<T>> ListOfLists1 = [];
    public List<T> ExpectedList1 = [];

    public MyLinkedList<T> LinkedList1 = null!;

    public int Integer1;
    public int Integer2;
    public int ExpectedInteger;
    public string String1 = "";
    public string String2 = "";
    public string ExpectedString = "";
}
