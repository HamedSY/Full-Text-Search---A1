namespace FullTextSearchA1.Services;

public interface ISearcher
{
    public HashSet<string> FindWord(string word, Dictionary<string, HashSet<string>> invertedIndex);
}