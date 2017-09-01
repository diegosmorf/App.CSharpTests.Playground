using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using App.CStarpTests.Playground.Test.Definitions;
using NUnit.Framework;

namespace App.CStarpTests.Playground.Test.ServiceTests
{
    public class IntersectionTests : BaseIntegrationTests
    {
        private const string SmallContentText = @"No young Geek apprentice should venture without your Geek Master.";
        private const string BigContentText = @"The Star Wars API (SWAPI) provides detailed data about Star Wars characters, vehicles, films and species, all neatly wrapped in a well-documented web API. While JSON is the standard encoding format provided by SWAPI, it’s worth checking out the alternative Wookie encoding for scoring that extra point of geek cred. Become Star Wars Jedi Master.";

        [Test]
        public void WhenContentRepeatInTwoTexts_ThenReturnIntersection()
        {
            //definitions
            var expectedNumberOfResults = 1;
            var expectedWord = "Master";
            //actions
            var result = GetWordsIntersection(BigContentText, SmallContentText).ToList();
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNumberOfResults, result.Count());
            Assert.AreEqual(expectedWord, result.First());

        }

        private IEnumerable<string> GetWordsIntersection(string content1, string content2)
        {
            return GetWords(content1).Intersect(GetWords(content2));
        }

        private IEnumerable<string> GetWords(string content)
        {
            const string expression = @"\W+";

            return Regex.Split(content, expression, RegexOptions.IgnoreCase)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .GroupBy(s => s)
                .Select(s=>s.Key)
                .ToList();
        }
    }
}