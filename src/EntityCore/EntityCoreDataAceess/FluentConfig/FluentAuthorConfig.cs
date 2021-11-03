using EntityCoreModel.Models.Fluent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EntityCoreDataAceess.FluentConfig
{
	public class FluentAuthorConfig : IEntityTypeConfiguration<FluentAuthor>
	{
		public void Configure(EntityTypeBuilder<FluentAuthor> modelBuilder)
		{
			modelBuilder.HasKey(fa => fa.Author_Id);
			modelBuilder.Property(fa => fa.FirstName).IsRequired();
			modelBuilder.Property(fa => fa.LastName).IsRequired();
			modelBuilder.Ignore(fa => fa.FullName);
		}
	}
}
