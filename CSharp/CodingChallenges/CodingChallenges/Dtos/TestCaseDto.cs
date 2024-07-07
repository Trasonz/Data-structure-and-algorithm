
namespace CodingChallenges.Dtos
{
    public class TestCaseDto<T>
    {
        public List<T> ListOfElements = [];
        public T[] ArrayOfElements = [];
        public int Integer;
        public int[] ExpectedArrayOfIntegers = [];
    }
}
