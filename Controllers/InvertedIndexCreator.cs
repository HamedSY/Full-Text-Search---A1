using FullTextSearchA1.Models;
using FullTextSearchA1.Services;

namespace FullTextSearchA1.Controllers;

public class InvertedIndexCreator : IInvertedIndexCreator
{
    private readonly char[] _delimiterChars = new char[]
        { ' ', ',', '=', '-', '|', '>', '<', '(', ')', '?', '!', '.', '@', '/', '_', '\\', ':', '\"', '*' };

    private List<string> SplitDocumentContent(Document document)
    {
        return File.ReadAllText("EnglishData/"+document.Name).ToUpper().Split(_delimiterChars).ToList();
    }

    public Dictionary<string, HashSet<string>> CreateInvertedIndex(List<Document> documents)
    {
        Dictionary<string, HashSet<string>> invertedIndex = new Dictionary<string, HashSet<string>>();
        // Iterate on our data
        foreach (var doc in documents)
        {
            var documentWords = SplitDocumentContent(doc);
            foreach (var word in documentWords)
            {
                if (!invertedIndex.ContainsKey(word))
                    invertedIndex[word] = new HashSet<string>();
                else
                    // Add the file name to the word's index in the dictionary (inverted index)
                    invertedIndex[word].Add(Path.GetFileName(doc.Name));
            }
        }

        return invertedIndex;
    }
}