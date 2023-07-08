using System;
using System.Collections;

namespace FullTextSearch
{
    
    public class Program
    {
        private static readonly char[] delimeterChars = new char[] {' ', ',', '=', '-', '|', '>', '<', '(', ')', '?', '!', '.', '@', '/', '_', '\\', ':', '\"', '*'};
        
        public static HashSet<string> CreateSetOfWords()
        {
            
            var documents = new List<string>();
            foreach (string file in Directory.EnumerateFiles("EnglishData"))
            {
                string upperedfile = File.ReadAllText(file);
                var splitedDocument = upperedfile.Split(delimeterChars);
                documents.AddRange(splitedDocument);
            }
            return documents.ToHashSet();
        }
        public static void Main(string[] args)
        {
            var allWords = CreateSetOfWords();
            foreach (var word in allWords)
                Console.WriteLine(word);
            

        }
    }
}