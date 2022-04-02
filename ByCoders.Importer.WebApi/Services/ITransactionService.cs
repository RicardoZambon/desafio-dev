using ByCoders.Importer.WebApi.Models;

namespace ByCoders.Importer.WebApi.Services
{
    public interface ITransactionService
    {
        Task ImportTransactionsFromFile(IFormFile file);

        IQueryable<TransactionsModel> List(QueryParametersModel parameters);
    }
}