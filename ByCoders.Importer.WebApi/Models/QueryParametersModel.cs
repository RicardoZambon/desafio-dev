using ByCoders.Importer.Core.Interfaces;

namespace ByCoders.Importer.WebApi.Models
{
    public class SummaryParametersModel : ISummaryParameters
    {
        public IDictionary<string, object> Filters { get; set; }
    }

    public class QueryParametersModel : SummaryParametersModel, IQueryParameters
    {
        public int StartRow { get; set; }

        public int EndRow { get; set; }

        public IDictionary<string, string> Sort { get; set; }

        public IDictionary<string, object> Filters { get; set; }
    }
}