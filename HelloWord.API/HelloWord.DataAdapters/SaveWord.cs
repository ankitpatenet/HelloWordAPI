using HelloWord.DataAdapters.interfaces;
using HelloWord.DomainModels.Models.Request;

namespace HelloWord.DataAdapters
{
    public class SaveWord : ISaveWord
    {
        public bool SaveHelloWord(HelloWordRequest word)
        {
            var isSaveSuccess = false;
            {
                /*for future database logic
                we do not have database logic right now 
                so if we pass string value it return true.  
                */
                isSaveSuccess = string.IsNullOrEmpty(word.Word);
            }
            return isSaveSuccess;
        }
    }
}