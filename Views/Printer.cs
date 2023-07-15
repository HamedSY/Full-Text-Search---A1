using FullTextSearchA1.Services;

namespace FullTextSearchA1.Views;

public class Printer : IPrinter
{
    public void PrintFoundDocument(HashSet<string> foundDocuments)
    {
        if(!foundDocuments.Any()) Console.WriteLine("Couldn't find your term :(");
        else
            foreach (var number in foundDocuments)
                Console.WriteLine(number);            
    }
}