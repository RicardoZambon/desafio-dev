using ByCoders.Importer.WebApi.Models;

namespace ByCoders.Importer.WebApi.Services
{
    public interface ICatalogService
    {
        IQueryable<TransactionTypesCatalogModel> ListTransactionTypes();
    }
}