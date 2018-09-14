using System;
using HelloWord.DataAdapters.interfaces;
using HelloWord.DomainModels.Models.Request;
using HelloWord.DomainModels.Models.Response;
using HelloWord.Repositories.Interfaces;

namespace HelloWord.Repositories
{
    public class HelloWordRepository : IHelloWordRepository
    {
        private readonly IGetWord _getWord;
        private readonly ISaveWord _saveWord;

        public HelloWordRepository(IGetWord getWord, ISaveWord saveWord)
        {
            _getWord = getWord;
            _saveWord = saveWord;
        }

        public GetHelloWordResponse GetHelloWord()
        {
            try
            {
                return _getWord.GetHelloWord();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public bool SaveHelloWord(HelloWordRequest word)
        {
            return _saveWord.SaveHelloWord(word);
        }
    }
}