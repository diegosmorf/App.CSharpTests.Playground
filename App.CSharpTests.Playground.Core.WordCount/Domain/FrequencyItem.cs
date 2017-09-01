using App.CSharpTests.Playground.Core.WordCount.Contracts;

namespace App.CSharpTests.Playground.Core.WordCount.Domain
{
    public class FrequencyItem : IFrequencyItem
    {
        public string Word { get; set; }
        public int Count { get; set; }
    }
}