using ByCoders.Importer.Core.BusinessEntities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace ByCoders.Importer.Core.BusinessEntities
{
    public class TransactionTypes : Entity
    {
        [StringLength(100)]
        public string Description { get; set; }

        public BusinessEnums.TransactionTypeKinds Kind { get; set; }
    }

    public class TransactionTypesConfiguration : EntityConfiguration<TransactionTypes>
    {
        public override void Configure(EntityTypeBuilder<TransactionTypes> builder)
        {
            base.Configure(builder);

            builder.HasData(new[] {
                new TransactionTypes { ID = 1, Description = "Débito", Kind = BusinessEnums.TransactionTypeKinds.Deposit },
                new TransactionTypes { ID = 2, Description = "Boleto", Kind = BusinessEnums.TransactionTypeKinds.Withdraw },
                new TransactionTypes { ID = 3, Description = "Financiamento", Kind = BusinessEnums.TransactionTypeKinds.Withdraw },
                new TransactionTypes { ID = 4, Description = "Crédito", Kind = BusinessEnums.TransactionTypeKinds.Deposit },
                new TransactionTypes { ID = 5, Description = "Recebimento Empréstimo", Kind = BusinessEnums.TransactionTypeKinds.Deposit },
                new TransactionTypes { ID = 6, Description = "Vendas", Kind = BusinessEnums.TransactionTypeKinds.Deposit },
                new TransactionTypes { ID = 7, Description = "Recebimento TED", Kind = BusinessEnums.TransactionTypeKinds.Deposit },
                new TransactionTypes { ID = 8, Description = "Recebimento DOC", Kind = BusinessEnums.TransactionTypeKinds.Deposit },
                new TransactionTypes { ID = 9, Description = "Aluguel", Kind = BusinessEnums.TransactionTypeKinds.Withdraw }
            });
        }
    }
}