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
	public class AccountTypeConfig : IEntityTypeConfiguration<AccountType>
	{
		public void Configure(EntityTypeBuilder<AccountType> builder)
		{
			builder.ToTable("AccountTypes");
			builder.Property(a => a.AccountTypeDescription).HasMaxLength(20).IsRequired(true);
			builder.Property(s => s.NewRecord)
				.HasDefaultValue(true);
			builder.Property(s => s.Deleted)
				.HasDefaultValue(false);

			//Seed Data
			builder.HasData(
				new AccountType
				{
					Id = new Guid("C7807BD9-9621-4336-8219-8120833CE1F4"),
					Title = "Premuim Savings",
					AccountTypeDescription = Domain.Enums.AccountTypeDescription.Current,
					AccountCode = "XB214",
					InterestRateId = 10

				},
				new AccountType
				{
					Id = new Guid("1680CA16-54DC-465E-B057-6B690CA040E3"),
					Title = "Classic Savings",
					AccountTypeDescription = Domain.Enums.AccountTypeDescription.Savings,
					AccountCode = "OD204",
					InterestRateId = 5
				});
		}
	}
}
