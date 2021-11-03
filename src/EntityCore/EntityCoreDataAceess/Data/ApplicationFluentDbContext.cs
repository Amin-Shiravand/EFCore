using EntityCoreDataAceess.FluentConfig;
using EntityCoreModel.Models.Fluent;
using Microsoft.EntityFrameworkCore;


namespace EntityCoreDataAceess.Data
{
	public class ApplicationFluentDbContext : DbContext
	{
		public DbSet<FluentBookDetail> FluentBookDetails { get; set; }
		public DbSet<FluentBook> FluentBooks { get; set; }
		public DbSet<FluentAuthor> FluentAuthors { get; set; }
		public DbSet<FluentPublisher> FluentPublishers { get; set; }

		public ApplicationFluentDbContext(DbContextOptions<ApplicationFluentDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);


			modelBuilder.ApplyConfiguration(new FluentBookConfig());
			modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
			modelBuilder.ApplyConfiguration(new FluentBookAuthorConfig());
			modelBuilder.ApplyConfiguration(new FluentPublisherConfig());
			modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
		}
	}
}
