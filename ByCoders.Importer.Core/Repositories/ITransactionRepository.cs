using ByCoders.Importer.Core.BusinessEntities;
using ByCoders.Importer.Core.Interfaces;

namespace ByCoders.Importer.Core.Repositories
{
    public interface ITransactionRepository
    {
        Task InsertAsync(Transactions transactions);

        IQueryable<Transactions> List(ISummaryParameters parameters);

        IQueryable<Transactions> List(IQueryParameters parameters);
    }
}