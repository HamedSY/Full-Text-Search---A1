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

        public static void CreateInvertedIndex(Dictionary<string, HashSet<int>> invertedIndex, string file)
        {
            var upperedFileText = File.ReadAllText(file).ToUpper();
            Document document = new Document(int.Parse(Path.GetFileName(file)), upperedFileText);
                var splitedDocument = upperedFileText.Split(delimeterChars);
                foreach (var word in splitedDocument)
                {
                    if (!invertedIndex.ContainsKey(word))
                        invertedIndex[word] = new HashSet<int>();
                    else
                        invertedIndex[word].Add(document.Number);
                }
        }

        public static void FindWord(string word, Dictionary<string, HashSet<int>> invertedIndex)
        {
            if (invertedIndex.TryGetValue(word, out _))
                foreach (int docNumber in invertedIndex[word])
                    Console.WriteLine(docNumber);
            else Console.WriteLine("Couldn't find your term :(");
        }
        
        public static void Main(string[] args)
        {
            var invertedIndex = new Dictionary<string, HashSet<int>>();
            foreach (string file in Directory.EnumerateFiles(@"C:\Users\h.sabour\Documents\VScode\C#\Full-Text Search-A1\EnglishData"))
                CreateInvertedIndex(invertedIndex, file);   
            
            var input = Console.ReadLine().ToUpper();

            FindWord(input, invertedIndex);
        }
    }
}