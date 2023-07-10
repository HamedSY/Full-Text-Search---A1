using FullTextSearchA1.Models;

namespace FullTextSearchA1.Services;

public interface IDataReader
{
    public List<Document> ReadData();
}