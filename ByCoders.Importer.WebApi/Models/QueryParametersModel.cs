using ByCoders.Importer.Core.Interfaces;

namespace ByCoders.Importer.WebApi.Models
{
    /// <summary>
    /// Generic parameter to filter summaries.
    /// </summary>
    public class SummaryParametersModel : ISummaryParameters
    {
        /// <summary>
        /// List of entity properties to filter with the value.
        /// </summary>
        public IDictionary<string, object> Filters { get; set; }
    }

    /// <summary>
    /// Generic parameter to filter or sort entities list.
    /// </summary>
    public class QueryParametersModel : SummaryParametersModel, IQueryParameters
    {
        /// <summary>
        /// Start row to return, default 0.
        /// </summary>
        public int StartRow { get; set; }

        /// <summary>
        /// End row to return.
        /// </summary>
        public int EndRow { get; set; }

        /// <summary>
        /// List of entity properties with the sort direction (asc or desc).
        /// </summary>
        public IDictionary<string, string> Sort { get; set; }

        /// <summary>
        /// List of entity properties to filter with the value.
        /// </summary>
        public IDictionary<string, object> Filters { get; set; }
    }
}