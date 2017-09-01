namespace App.CSharpTests.Playground.Core.WordCount.Contracts
{
    public interface IFrequencyItem
    {
        string Word { get; set; }
        int Count { get; set; }
    }
}