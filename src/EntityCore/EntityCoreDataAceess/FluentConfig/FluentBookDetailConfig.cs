using EntityCoreModel.Models.Fluent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
  

namespace EntityCoreDataAceess.FluentConfig
{
	public class FluentBookDetailConfig : IEntityTypeConfiguration<FluentBookDetail>
	{
		public void Configure(EntityTypeBuilder<FluentBookDetail> modelBuilder)
		{
			modelBuilder.HasKey(fb => fb.FluentBookDetail_Id);
			modelBuilder.Property(b => b.NumberOfChapters).IsRequired();
		}
	}
}
