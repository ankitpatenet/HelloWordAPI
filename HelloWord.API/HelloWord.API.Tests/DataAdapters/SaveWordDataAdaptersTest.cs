using System;
using HelloWord.DataAdapters.interfaces;
using HelloWord.DomainModels.Models.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace HelloWord.API.Tests.DataAdapters
{
    [TestFixture]
    public class SaveWordDataAdaptersTest
    {
        [SetUp]
        public void OneTimeSetUp()
        {
            _saveWord = new Mock<ISaveWord>();
        }

        private Mock<ISaveWord> _saveWord;

        [Test]
        public void GetWord_Success()
        {
            _saveWord.Setup(x => x.SaveHelloWord(It.IsAny<HelloWordRequest>())).Returns(true);

            var result = _saveWord.Object.SaveHelloWord(It.IsAny<HelloWordRequest>());

            Assert.IsNotNull(result);
            Assert.AreEqual(result, true);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void HelloWordRepository_Exception()
        {
            _saveWord.Setup(x => x.SaveHelloWord(It.IsAny<HelloWordRequest>())).Throws(new Exception());
            _saveWord.Object.SaveHelloWord(It.IsAny<HelloWordRequest>());
        }
    }
}