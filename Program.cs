using System;
using System.Collections;

namespace FullTextSearch
{
    public class Document
    {
        public int Number { get; set; }
        public string Content { get; set; }

        public Document(int number, string content) {
            Number = number;
            Content = content;
        }
    }
    
    public class Program
    {
        private static readonly char[] delimeterChars = new char[] {' ', ',', '=', '-', '|', '>', '<', '(', ')', '?', '!', '.', '@', '/', '_', '\\', ':', '\"', '*'};

        public static Dictionary<string, List<int>> CreateInvertedIndex(List<string> terms, List<Document> documents)
        {
            var invertedIndex = new Dictionary<string, List<int>>();
            foreach (var term in terms)
            {
                var appropriateDocs = new List<int>();
                foreach (var doc in documents)
                    if (doc.Content.Split(delimeterChars).Contains(term))
                        appropriateDocs.Add(doc.Number);

                invertedIndex[term] = appropriateDocs;
            }
            return invertedIndex;
        }

        public static void FindWord(string word, Dictionary<string, List<int>> invertedIndex)
        {
            if (invertedIndex.TryGetValue(word, out _))
                foreach (int docNumber in invertedIndex[word])
                    Console.WriteLine(docNumber);
            else Console.WriteLine("Couldn't find your term :(");
        }
        
        public static void Main(string[] args)
        {
            var documents = new List<Document>();
            var allWords = new List<string>();
            foreach (string file in Directory.EnumerateFiles("EnglishData"))
            {
                var upperedfile = File.ReadAllText(file).ToUpper();
                documents.Add(new Document(int.Parse(Path.GetFileName(file)), upperedfile));
                var splitedDocument = upperedfile.Split(delimeterChars);
                allWords.AddRange(splitedDocument);
            }
            var terms = allWords.ToHashSet().ToList();

            var invertedIndex = CreateInvertedIndex(terms, documents);
            
            var input = Console.ReadLine().ToUpper();

            FindWord(input, invertedIndex);
        }
    }
}