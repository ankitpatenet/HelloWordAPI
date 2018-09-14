using System;
using HelloWord.DataAdapters.interfaces;
using HelloWord.DomainModels.Models.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace HelloWord.API.Tests.DataAdapters
{
    [TestFixture]
    public class GetWordAdaptersTest
    {
        [SetUp]
        public void OneTimeSetUp()
        {
            _getWord = new Mock<IGetWord>();
        }

        private Mock<IGetWord> _getWord;

        [Test]
        public void GetWord_Success()
        {
            var word = new GetHelloWordResponse {Id = 1, Word = "Hello Word"};
            _getWord.Setup(x => x.GetHelloWord()).Returns(word);

            var result = _getWord.Object.GetHelloWord();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Word, word.Word);
        }


        [Test]
        [ExpectedException(typeof(Exception))]
        public void HelloWordRepository_Exception()
        {
            _getWord.Setup(x => x.GetHelloWord()).Throws(new Exception());
            var result = _getWord.Object.GetHelloWord();
        }
    }
}