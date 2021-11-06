using EntityCoreModel.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityCoreDataAceess.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<BookDetail> BookDetails { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Publisher> Publishers { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<BookAuthor> BookAuthors { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<BookDetailsFromView> BookDetailsFromViews { get; set; }


		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options) : base(Options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);
			//Composite Key for BookAuthor
			modelBuilder.Entity<BookAuthor>().HasKey(bookAuthor => new { bookAuthor.Author_Id, bookAuthor.Book_Id });
			modelBuilder.Entity<BookDetailsFromView>().HasNoKey().ToView("GetOnlyBookDetails");
		}
	}
}
