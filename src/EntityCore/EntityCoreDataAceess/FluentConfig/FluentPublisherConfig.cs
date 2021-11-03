using EntityCoreModel.Models.Fluent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EntityCoreDataAceess.FluentConfig
{
	public class FluentPublisherConfig : IEntityTypeConfiguration<FluentPublisher>
	{
		public void Configure(EntityTypeBuilder<FluentPublisher> modelBuilder)
		{
			modelBuilder.HasKey(fp => fp.Publisher_Id);
			modelBuilder.Property(fp => fp.Name).IsRequired();
			modelBuilder.Property(fp => fp.Location).IsRequired();
		}
	}
}
