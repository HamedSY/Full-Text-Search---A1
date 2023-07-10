using FullTextSearchA1.Controllers;
using FullTextSearchA1.Services;
using FullTextSearchA1.Views;
using Microsoft.Extensions.DependencyInjection;

namespace FullTextSearchA1.DIManager;

public static class DependencyInjector
{
    public static void SearchService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IDataReader, DataReader>();
        serviceCollection.AddSingleton<IInvertedIndexCreator, InvertedIndexCreator>();
        serviceCollection.AddSingleton<IPrinter, Printer>();
        serviceCollection.AddSingleton<ISearcher, Searcher>();
        serviceCollection.AddSingleton<IRunner, Runner>();
    }
}