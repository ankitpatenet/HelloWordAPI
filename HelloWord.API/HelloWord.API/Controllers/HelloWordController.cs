using System;
using System.Net;
using System.Web.Http;
using HelloWord.DomainModels.Models.Request;
using HelloWord.Repositories.Interfaces;

namespace HelloWord.API.Controllers
{
    public class HelloWordController : ApiController
    {
        private readonly IHelloWordRepository _helloWordRepository;

        public HelloWordController(IHelloWordRepository helloWordRepository)
        {
            _helloWordRepository = helloWordRepository;
        }

        [HttpGet]
        public IHttpActionResult GetHelloWord()
        {
            try
            {
                var response = _helloWordRepository.GetHelloWord();
                if (response == null) return NotFound();
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public IHttpActionResult SaveHelloWord(HelloWordRequest request)
        {
            try
            {
                var response = _helloWordRepository.SaveHelloWord(request);

                if (response)
                    return Ok();
                return NotFound();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}