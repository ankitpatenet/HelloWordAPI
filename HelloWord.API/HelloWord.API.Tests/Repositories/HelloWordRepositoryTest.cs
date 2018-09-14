using System;
using HelloWord.DomainModels.Models.Response;
using HelloWord.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace HelloWord.API.Tests.Repositories
{
    [TestFixture]
    public class HelloWordRepositoryTest
    {
        [SetUp]
        public void OneTimeSetUp()
        {
            _helloWordRepository = new Mock<IHelloWordRepository>();
        }

        private Mock<IHelloWordRepository> _helloWordRepository;

        [Test]
        [ExpectedException(typeof(Exception))]
        public void GetWord_Exception()
        {
            // Arrange
            _helloWordRepository.Setup(x => x.GetHelloWord()).Throws(new Exception());
            var result = _helloWordRepository.Object.GetHelloWord();
        }

        [Test]
        public void HelloWordRepository_Success()
        {
            // Arrange
            var word = new GetHelloWordResponse {Id = 1, Word = "Hello Word"};
            _helloWordRepository.Setup(x => x.GetHelloWord()).Returns(word);

            var result = _helloWordRepository.Object.GetHelloWord();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Word, word.Word);
        }
    }
}