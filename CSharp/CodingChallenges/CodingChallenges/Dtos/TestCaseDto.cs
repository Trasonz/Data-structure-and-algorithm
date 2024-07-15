
namespace CodingChallenges.Dtos;

public class TestCaseDto<T>
{
    public T[] ArrayOfElements = [];
    public T[][] ArrayOfArraysOfElements = [];
    public T[] ExpectedArrayOfElements = [];

    public List<T> ListOfElements = [];
    public List<List<T>> ListOfListsOfElements = [];
    public List<T> ExpectedListOfElements = [];

    public T? Element;

    public int Integer;
    public int ExpectedInteger;
    public string String = "";
    public string ExpectedString = "";
}
