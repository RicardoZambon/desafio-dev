namespace ByCoders.Importer.Core.Interfaces
{
    public interface IQueryParameters : ISummaryParameters
    {
        int StartRow { get; set; }

        int EndRow { get; set; }

        IDictionary<string, string> Sort { get; set; }
    }
}