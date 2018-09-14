using HelloWord.DataAdapters.interfaces;
using HelloWord.DomainModels.Models.Response;

namespace HelloWord.DataAdapters
{
    public class GetWord : IGetWord
    {
        private const string HelloWord = "Hello Word";

        public GetHelloWordResponse GetHelloWord()
        {
            return new GetHelloWordResponse
            {
                Id = 1,
                Word = HelloWord
            };
        }
    }
}