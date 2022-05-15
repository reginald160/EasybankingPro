using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
	public class TransactionTypeConfig : IEntityTypeConfiguration<TransactionType>
	{
		public void Configure(EntityTypeBuilder<TransactionType> builder)
		{

			builder.ToTable("TransactionTypes");
			builder.Property(s => s.Title).HasMaxLength(20)
				.IsRequired(true);
			builder.Property(s => s.NewRecord)
				.HasDefaultValue(true);
			builder.Property(s => s.Deleted)
				.HasDefaultValue(false);
			builder.Property(s => s.Charge);
			builder.Property(p => p.RowVersion).IsConcurrencyToken();


			builder.HasData(

			new TransactionType
			{
				Id = new Guid("713243A4-65E6-4EC1-A21B-967323E59612"),
				Title = "Deposit",
				Description = Domain.Enums.TransactionTypeDescription.Deposit,
				Charge = 10

			},
			new TransactionType
			{
				Id = new Guid("18A36C90-82C0-40BE-91F2-E6DA29765B8C"),
				Title = "Withdrawal",
				Description = Domain.Enums.TransactionTypeDescription.Withdrawal,
				Charge = 50

			},
			new TransactionType
			{
				Id = new Guid("D2E757B1-AA06-4C53-B99C-A487C89608D5"),
				Title = "Transfer",
				Description = Domain.Enums.TransactionTypeDescription.Transfer,
				Charge = 100

			});
		}
	}
}
