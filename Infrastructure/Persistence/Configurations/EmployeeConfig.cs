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
	public class EmployeeConfig : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			builder.ToTable("Employees");
			builder.Property(e => e.Id);

			builder.Property(e => e.FirstName)
				.HasMaxLength(100)
				.IsRequired();
			builder.Property(e => e.LastName)
			.HasMaxLength(100)
			.IsRequired();
			builder.Property(e => e.MiddleName)
			.HasMaxLength(100);
			builder.Property(p => p.RowVersion).IsConcurrencyToken();
		}
	}
}
