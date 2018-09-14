using HelloWord.DomainModels.Models.Request;
using HelloWord.DomainModels.Models.Response;

namespace HelloWord.Repositories.Interfaces
{
    public interface IHelloWordRepository
    {
        GetHelloWordResponse GetHelloWord();
        bool SaveHelloWord(HelloWordRequest request);
    }
}