using System.Linq;
using App.CSharpTests.Playground.Core.WordCount.Contracts;
using App.CStarpTests.Playground.Test.Definitions;
using Autofac;
using NUnit.Framework;

namespace App.CStarpTests.Playground.Test.ServiceTests
{
    public class WordFrequencyTests : BaseIntegrationTests
    {
        private const string SmallContentText = @"No young Geek apprentice should venture without your Geek Master.";
        private const string BigContentText = @"The Star Wars API (SWAPI) provides detailed data about Star Wars characters, 
                                                vehicles, films and species, all neatly wrapped in a well-documented web API. 
                                                While JSON is the standard encoding format provided by SWAPI, it’s worth checking
                                                out the alternative Wookie encoding for scoring that extra point of geek cred.";

        [Test]
        public void WhenContentEmpty_ThenFrequencyEmpty()
        {
            //definitions
            var service = container.Resolve<IServiceWordsFrequency>();
            var content = @"";
            var expectedNumberOfResults = 0;
            //actions
            var result = service.GetTopFrequencyWords(content);
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNumberOfResults, result.Count());
        }

        [Test]
        public void WhenContentMoreThan5RepeatedWords_ThenFrequencyTop5()
        {
            //definitions
            var service = container.Resolve<IServiceWordsFrequency>();
            var content = BigContentText;
            var expectedNumberOfResults = 5;
            //actions
            var result = service.GetTopFrequencyWords(content);
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNumberOfResults, result.Count());
        }

        [Test]
        public void WhenContentMoreThan5RepeatedWords_ThenFrequencyTop5Count()
        {
            //definitions
            var service = container.Resolve<IServiceWordsFrequency>();
            var content = BigContentText;
            var expectedCount = 2;
            //actions
            var result = service.GetTopFrequencyWords(content);
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCount, result.First().Count);
        }

        [Test]
        public void WhenContentMoreThan5RepeatedWords_ThenFrequencyTop5Word()
        {
            //definitions
            var service = container.Resolve<IServiceWordsFrequency>();
            var content = BigContentText;
            var expectedWord = "Star";
            //actions
            var result = service.GetTopFrequencyWords(content);
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedWord, result.First().Word);
        }

        [Test]
        public void WhenContentMoreThan5WordsBut1Repeated_ThenFrequencyTop1()
        {
            //definitions
            var service = container.Resolve<IServiceWordsFrequency>();
            var content = SmallContentText;
            var expectedNumberOfResults = 1;
            //actions
            var result = service.GetTopFrequencyWords(content);
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNumberOfResults, result.Count());
        }

        [Test]
        public void WhenContentWith3EqualsWords_ThenFrequencyTop1()
        {
            //definitions
            var service = container.Resolve<IServiceWordsFrequency>();
            var content = @"Tests Tests Tests";
            var expectedNumberOfResults = 1;
            //actions
            var result = service.GetTopFrequencyWords(content);
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNumberOfResults, result.Count());
        }

        [Test]
        public void WhenContentEmpty_ThenWordCountZero()
        {
            //definitions
            var service = container.Resolve<IServiceWordsFrequency>();
            var content = @"";
            var expectedNumberOfResults = 0;
            //actions
            var result = service.GetNumberOfUniqueWords(content);
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNumberOfResults, result);
        }

        [Test]
        public void WhenContentContainRepeatedWords_ThenGetNumberOfUniqueWords()
        {
            //definitions
            var service = container.Resolve<IServiceWordsFrequency>();
            var content = BigContentText;
            var expectedNumberOfResults = 46;
            //actions
            var result = service.GetNumberOfUniqueWords(content);
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNumberOfResults, result);
        }

        [Test]
        public void WhenContentContainRepeatedWords_ThenGetNumberOfUniqueWords_AndOnlyMisspelledWords()
        {
            //definitions
            var service = container.Resolve<IServiceWordsFrequency>();
            var content = BigContentText;
            var expectedNumberOfResults = 46;
            const bool onlyMisspelledWords = true;
            //actions
            var result = service.GetNumberOfUniqueWords(content, onlyMisspelledWords);
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNumberOfResults, result);
        }

        [Test]
        public void WhenContentContainRepeatedWords_ThenOnlyMisspelledWords()
        {
            //definitions
            var service = container.Resolve<IServiceWordsFrequency>();
            var content = SmallContentText;
            var expectedNumberOfResults = 1;
            const bool onlyMisspelledWords = true;
            var expectedWord = "Geek";
            var globalDictionary = "Geek";
            //actions
            var result = service.GetTopFrequencyWords(content, expectedNumberOfResults, onlyMisspelledWords , globalDictionary);
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNumberOfResults, result.Count());
            Assert.AreEqual(expectedWord, result.First().Word);
        }

        public void WhenContentContainRepeatedWords_ThenNoWords()
        {
            //definitions
            var service = container.Resolve<IServiceWordsFrequency>();
            var content = SmallContentText;
            var expectedNumberOfResults = 0;
            const bool onlyMisspelledWords = true;
            var expectedWord = "Geek";
            var globalDictionary = "Master";
            //actions
            var result = service.GetTopFrequencyWords(content, expectedNumberOfResults, onlyMisspelledWords, globalDictionary);
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNumberOfResults, result.Count());
            Assert.AreEqual(expectedWord, result.First().Word);
        }
    }
}