using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Infrastructure.Persistence.Configurations
{
	public class DesignitionConfig : IEntityTypeConfiguration<Designition>
	{
		public void Configure(EntityTypeBuilder<Designition> builder)
		{
			//builder.ToTable("Designitions");
			builder.Property(s => s.Title).HasMaxLength(20)
			.IsRequired(true);
			builder.Property(s => s.NewRecord)
				.HasDefaultValue(true);
			builder.Property(s => s.Deleted)
				.HasDefaultValue(false);

			builder.HasData(

			new Designition
			{
				Id = new Guid("94831400-F3FF-4060-B642-1E2C3879508C"),
				Title = "MD",
				Code = DesignitionCode.MD

			},
			new Designition
			{
				Id = new Guid("2303A60F-0BAC-40FA-BB2A-B27D6E43784F"),
				Title = "Regional Manager",
				Code = DesignitionCode.RM
			},
			new Designition
			{
				Id = new Guid("1D94ED99-5150-4D10-88BE-1CB38F06ABA6"),
				Title = "Zonal Manager",
				Code = DesignitionCode.ZSM
			},
			new Designition
			{
				Id = new Guid("DD99BAFB-44D0-4826-B82B-18B80B44AF02"),
				Title = "Branch Manager",
				Code = DesignitionCode.BM
			},
			new Designition
			{
				Id = new Guid("A8F9802B-5F09-4425-8D2E-A58DBF1D5283"),
				Title = "CSM",
				Code = DesignitionCode.CSM
			},
			new Designition
			{
				Id = new Guid("4E179FCE-B0D3-4823-9C04-5696DDB3367B"),
				Title = "Account Officer",
				Code = DesignitionCode.AO
			},
			new Designition
			{
				Id = new Guid("81C1A180-99A0-4B39-9F25-F826D34060FE"),
				Title = "DSA",
				Code = DesignitionCode.DSA
			}


				);
		}
	}
}
