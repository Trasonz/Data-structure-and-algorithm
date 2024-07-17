
namespace CodingChallenges.Dtos;

public class TestCaseDto<T>
{
    public T[] ArrayOfElements1 = [];
    public T[] ArrayOfElements2 = [];
    public T[][] ArrayOfArraysOfElements = [];
    public T[] ExpectedArrayOfElements = [];

    public List<T> ListOfElements = [];
    public List<List<T>> ListOfListsOfElements = [];
    public List<T> ExpectedListOfElements = [];

    public T? Element;

    public int Integer1;
    public int Integer2;
    public int ExpectedInteger;
    public string String = "";
    public string ExpectedString = "";
}
