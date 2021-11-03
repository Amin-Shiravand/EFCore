

namespace EntityCoreModel.Models.Fluent
{
	public class FluentBookAuthor
	{
		public int FluentBook_Id { get; set; }
		
		public int FluentAuthor_Id { get; set; }

		public FluentBook FluentBook { get; set; }
		public FluentAuthor FluentAuthor { get; set; }
	}
}
