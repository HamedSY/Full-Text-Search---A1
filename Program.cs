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
            var terms = allWords.ToHashSet().ToArray();
            var invertedIndex = new Dictionary<string, List<int>>();

            foreach (var term in terms)
            {
                var appropriateDocs = new List<int>();
                foreach (var doc in documents)
                    if (doc.Content.Split(delimeterChars).Contains(term))
                        appropriateDocs.Add(doc.Number);

                invertedIndex[term] = appropriateDocs;
            }

        }
    }
}