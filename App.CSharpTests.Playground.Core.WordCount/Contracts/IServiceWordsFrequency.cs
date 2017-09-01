using System.Collections.Generic;

namespace App.CSharpTests.Playground.Core.WordCount.Contracts
{
    public interface IServiceWordsFrequency
    {
        int GetNumberOfUniqueWords(string content, bool onlyMisspelledWords = false, string globalDictionary = "");

        IEnumerable<IFrequencyItem> GetTopFrequencyWords(string content, int numberOfItems = 5, bool onlyMisspelledWords = false, string globalDictionary = "");
    }
}