using EntityCoreModel.Models.Fluent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityCoreDataAceess.FluentConfig
{
	public class FluentBookAuthorConfig : IEntityTypeConfiguration<FluentBookAuthor>
	{
		public void Configure(EntityTypeBuilder<FluentBookAuthor> modelBuilder)
		{
			modelBuilder.HasKey(fba => new { fba.FluentAuthor_Id, fba.FluentBook_Id });
			modelBuilder.HasOne(fba => fba.FluentAuthor).WithMany(fba => fba.FluentBookAuthors).HasForeignKey(fba => fba.FluentAuthor_Id);
			modelBuilder.HasOne(fba => fba.FluentBook).WithMany(fba => fba.FluentBookAuthors).HasForeignKey(fba => fba.FluentBook_Id);
		}
	}
}
