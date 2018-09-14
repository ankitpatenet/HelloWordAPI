using System.Web.Http.Results;
using HelloWord.API.Controllers;
using HelloWord.DataAdapters.interfaces;
using HelloWord.DomainModels.Models.Response;
using HelloWord.Repositories.Interfaces;
using Moq;
using NUnit.Framework;

namespace HelloWord.API.Tests.API
{
    [TestFixture]
    public class HelloWordServiceTest
    {
        [SetUp]
        public void OneTimeSetUp()
        {
            _saveWord = new Mock<ISaveWord>();
            _getWord = new Mock<IGetWord>();
            _helloWordRepository = new Mock<IHelloWordRepository>();
        }

        private HelloWordController _helloWordController;
        private Mock<IHelloWordRepository> _helloWordRepository;
        private Mock<IGetWord> _getWord;
        private Mock<ISaveWord> _saveWord;

        [Test]
        public void GetHelloWord_success()
        {
            // Arrange
            var word = new GetHelloWordResponse {Id = 1, Word = "Hello Word"};

            _helloWordRepository.Setup(x => x.GetHelloWord())
                .Returns(word);

            _helloWordController = new HelloWordController(_helloWordRepository.Object);

            var actionResult = _helloWordController.GetHelloWord();
            var contentResult = actionResult as OkNegotiatedContentResult<GetHelloWordResponse>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.Word, word.Word);
        }

        [Test]
        public void GetReturnsNotFound()
        {
            // Arrange
            var _helloWordController = new HelloWordController(_helloWordRepository.Object);

            // Act
            var actionResult = _helloWordController.GetHelloWord();

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(actionResult);
        }
    }
}