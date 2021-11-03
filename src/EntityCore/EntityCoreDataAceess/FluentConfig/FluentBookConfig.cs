using EntityCoreModel.Models.Fluent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EntityCoreDataAceess.FluentConfig
{
	public class FluentBookConfig : IEntityTypeConfiguration<FluentBook>
	{
		public void Configure(EntityTypeBuilder<FluentBook> modelBuilder)
		{
			modelBuilder.HasKey(fb => fb.Book_Id);
			modelBuilder.Property(fb => fb.ISBN).IsRequired().HasMaxLength(15);
			modelBuilder.Property(fb => fb.Price).IsRequired();
			modelBuilder.Property(fb => fb.Title).IsRequired();
			//OnetoOne realation between Book and BookDetail
			modelBuilder.HasOne(fb => fb.FluentBookDetail).WithOne(fb => fb.FluentBook).HasForeignKey<FluentBook>("FluentBookDetail_Id");
			//OnetoOne  many realation between Book and publisher
			modelBuilder.HasOne(fb => fb.FluentPublisher).WithMany(fb => fb.FluentBooks).HasForeignKey("FluentPublisher_Id");
		}
	}
}
