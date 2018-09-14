using HelloWord.DomainModels.Models.Request;

namespace HelloWord.DataAdapters.interfaces
{
    public interface ISaveWord
    {
        bool SaveHelloWord(HelloWordRequest word);
    }
}