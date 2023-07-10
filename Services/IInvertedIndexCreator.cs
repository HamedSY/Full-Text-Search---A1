using FullTextSearchA1.Models;

namespace FullTextSearchA1.Services;

public interface IInvertedIndexCreator
{
    public Dictionary<string, HashSet<string>> CreateInvertedIndex(List<Document> documents);
}