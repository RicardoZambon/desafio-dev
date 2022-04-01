namespace ByCoders.Importer.Core.Interfaces
{
    public interface IQueryParameters
    {
        int StartRow { get; set; }

        int EndRow { get; set; }

        IDictionary<string, string> Sort { get; set; }

        IDictionary<string, object> Filters { get; set; }
    }
}