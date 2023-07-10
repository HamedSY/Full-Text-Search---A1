using FullTextSearchA1.DIManager;
using FullTextSearchA1.Models;
using FullTextSearchA1.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FullTextSearchA1;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.SearchService();
        var provider = serviceCollection.BuildServiceProvider();
        var runner = provider.GetRequiredService<IRunner>();
        runner.Run();
    }
}