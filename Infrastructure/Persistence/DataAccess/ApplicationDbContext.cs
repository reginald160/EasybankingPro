
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;
using Domain.Entities;
using Domain.Common;
using System.Threading;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Infrastructure.Persistence.Configurations;

namespace Infrastructure.Persistence.DataAccess
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser> 
	{
		public virtual ClaimsPrincipal User { get; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		   : base(options)
		{
		}

	  
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new TransactionTypeConfig());
			builder.ApplyConfiguration(new DesignitionConfig());
			builder.ApplyConfiguration(new AccountTypeConfig());
			#region
			//var typesToRegister = Assembly.Load("BillsPmtOrchestrator.Repository").GetTypes().
			// Where(type => !string.IsNullOrEmpty(type.Namespace)).
			// Where(type => type.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null).ToList();

			//foreach (var type in typesToRegister)
			//{
			//	dynamic configurationInstance = Activator.CreateInstance(type);
			//             builder.ApplyConfiguration(configurationInstance);

			//}
			#endregion

			base.OnModelCreating(builder);     
		}

		//public DbSet<BaseProfile> BaseProfiles { get; set; }
		public DbSet<Employee> Employees { get; set; }
		//public DbSet<Customer> Customers { get; set; }
		public DbSet<Account> Accounts { get; set; }
		public DbSet<AccountType> AccountTypes { get; set; }
		public DbSet<TransactionLog> Transactions { get; set; }
		public DbSet<TransactionType> TransactionTypes { get; set; }
		public DbSet<Designition> Designitions { get; set; }
		public DbSet<NumberSequence> NumberSequences { get; set; }
		public DbSet<UserSecurityQuestion> UserSecurityQuestions { get; set; }

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
			#region
			// ignore events if no dispatcher provided
			//if (_mediator == null) return result;

			// dispatch events only if save was successful
			//var entitiesWithEvents = ChangeTracker.Entries<AdminModel>()
			//    .Select(e => e.Entity)
			//    .Where(e => e.Events.Any())
			//    .ToArray();
			//var entitiesWithEvents = ChangeTracker.Entries<AdminModel>()
			//foreach (var entity in entitiesWithEvents)
			//{
			//    var events = entity.Events.ToArray();
			//    entity.Events.Clear();
			//    foreach (var domainEvent in events)
			//    {
			//        await _mediator.Publish(domainEvent).ConfigureAwait(false);
			//    }
			//}
			#endregion

			var entries = ChangeTracker.Entries<AdminModel>();
			foreach (var entry in entries)
			{
				switch (entry.State)
				{
					case EntityState.Added:
						entry.Entity.CreatedBy = User.Identity.Name.ToString();
						entry.Entity.DateCreated = DateTime.Now;
						break;
					case EntityState.Unchanged:
						break;
					case EntityState.Deleted:
						break;
					case EntityState.Modified:
						entry.Entity.LastModifiedBy = User.Identity.Name.ToString();
						entry.Entity.ModifiedDate = DateTime.Now;
						break;
					default:
						break;
				}
			}

			return result;
		}

		public override int SaveChanges()
		{
			return SaveChangesAsync().GetAwaiter().GetResult();
		}

		//public void EventOccured(List<object> list, string value, string evt)
		//{
		//	var indexOfValue = list.FindIndex(val => val.GetType().GetProperty("Id").Name); ;
		//	list[indexOfValue] = $"{list[indexOfValue]}, event: {evt}";
		//}

	}
}
