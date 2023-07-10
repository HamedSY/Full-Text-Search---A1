namespace FullTextSearchA1.Services;

public interface IPrinter
{
    public void PrintFoundDocument(HashSet<string> foundDocuments);
}