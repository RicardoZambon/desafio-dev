﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using ByCoders.Importer.Core.Repositories;
using ByCoders.Importer.WebApi.Models;

namespace ByCoders.Importer.WebApi.Services.Handlers
{
    public class CatalogServicesDefault : ICatalogService
    {
        private readonly IMapper mapper;
        private readonly ITransactionTypeRepository transactionTypeRepository;

        public CatalogServicesDefault(IMapper mapper, ITransactionTypeRepository transactionTypeRepository)
        {
            this.mapper = mapper;
            this.transactionTypeRepository = transactionTypeRepository;
        }


        public IQueryable<TransactionTypesCatalogModel> ListTransactionTypes()
        {
            return transactionTypeRepository.List().ProjectTo<TransactionTypesCatalogModel>(mapper.ConfigurationProvider);
        }
    }
}