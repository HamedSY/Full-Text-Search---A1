using FullTextSearchA1.Services;

namespace FullTextSearchA1.Views;

public class Runner : IRunner
{
    private IInvertedIndexCreator _invertedIndexCreator;
    private ISearcher _searcher;
    private IDataReader _dataReader;
    private IPrinter _printer;

    public Runner(IInvertedIndexCreator invertedIndexCreator, ISearcher searcher, IDataReader dataReader, IPrinter printer)
    {
        _invertedIndexCreator = invertedIndexCreator;
        _searcher = searcher;
        _dataReader = dataReader;
        _printer = printer;
    }

    public void Run()
    {
        var documents = _dataReader.ReadData();
        var invertedIndex = _invertedIndexCreator.CreateInvertedIndex(documents);
        var input = Console.ReadLine()?.ToUpper();
        var foundDocuments = _searcher.FindWord(input, invertedIndex);
        _printer.PrintFoundDocument(foundDocuments);
    }
}