using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using App.CSharpTests.Playground.Core.WordCount.Contracts;
using App.CSharpTests.Playground.Core.WordCount.Domain;

namespace App.CSharpTests.Playground.Core.WordCount.Infrastructure
{
    public class ServiceWordsFrequency : IServiceWordsFrequency
    {
        public int GetNumberOfUniqueWords(string content, bool onlyMisspelledWords = false, string globalDictionary = "")
        {
            return GetWordsFrequency(content, onlyMisspelledWords,globalDictionary).Count;
        }

        protected IList<IGrouping<string, string>> GetWordsFrequency(string content, bool onlyMisspelledWords = false, string globalDictionary = "")
        {
            if (string.IsNullOrEmpty(content))
            {
                return new List<IGrouping<string, string>>();
            }

            var tempList = GetWordsFrequency(content).ToList();

            if(!onlyMisspelledWords || string.IsNullOrEmpty(globalDictionary))
                return tempList ;

            var tempListDictionary = GetWordsFrequency(globalDictionary).ToList();

            var filteredList = tempList.Where(s => tempListDictionary.Any(x=> x.Key == s.Key)).ToList();
            
            return filteredList;
        }

        private IList<IGrouping<string, string>> GetWordsFrequency(string content)
        {
            const string expression = @"\W+";

            return Regex.Split(content, expression, RegexOptions.IgnoreCase)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .GroupBy(s => s)
                .ToList();
        }

        public IEnumerable<IFrequencyItem> GetTopFrequencyWords(string content, int numberOfItems = 5, bool onlyMisspelledWords = false, string globalDictionary = "")
        {
            return GetWordsFrequency(content, onlyMisspelledWords, globalDictionary)
                        .OrderByDescending(g => g.Count())
                        .Take(numberOfItems)
                        .ToList()
                        .Where(s => s.Count() > 1)
                        .Select(item => new FrequencyItem { Word = item.Key, Count = item.Count() })
                        .Cast<IFrequencyItem>().ToList();
        }
    }
}