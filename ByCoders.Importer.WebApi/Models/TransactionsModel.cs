using AutoMapper;
using AutoMapper.Configuration.Annotations;
using ByCoders.Importer.Core.BusinessEntities;

namespace ByCoders.Importer.WebApi.Models
{
    [AutoMap(typeof(Transactions), ReverseMap = false)]
    public class TransactionsModel
    {
        [SourceMember($"{nameof(Transactions.TransactionType)}.{nameof(TransactionTypes.Description)}")]
        public string TransactionType { get; set; }

        public DateTime Date { get; set; }

        public decimal Value { get; set; }

        public string CPF { get; set; }

        public string CardNumber { get; set; }

        [SourceMember($"{nameof(Transactions.ShopName)}")]
        public string ShopName { get; set; }

        [SourceMember($"{nameof(Transactions.ShopOwner)}")]
        public string ShopOwner { get; set; }
    }
}