using FullTextSearchA1.Services;

namespace FullTextSearchA1.Controllers;

public class Searcher : ISearcher
{
    public HashSet<string> FindWord(string word, Dictionary<string, HashSet<string>> invertedIndex)
    {
        if (invertedIndex.TryGetValue(word, out _))
            return invertedIndex[word];
        return new HashSet<string>();
    }
}