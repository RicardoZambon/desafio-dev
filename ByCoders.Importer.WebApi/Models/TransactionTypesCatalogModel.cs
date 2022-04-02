using AutoMapper;
using ByCoders.Importer.Core.BusinessEntities;
using ByCoders.Importer.WebApi.Services;

namespace ByCoders.Importer.WebApi.Models
{
    [AutoMap(typeof(TransactionTypes), ReverseMap = false)]
    public class TransactionTypesCatalogModel
    {
        public int ID { get; set; }

        public string Description { get; set; }
    }
}