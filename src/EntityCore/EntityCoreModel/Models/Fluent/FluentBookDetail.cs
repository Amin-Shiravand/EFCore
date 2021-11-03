

namespace EntityCoreModel.Models.Fluent
{
	public class FluentBookDetail
	{
		public int FluentBookDetail_Id { get; set; }

		public int NumberOfChapters { get; set; }
		
		public int NumberOfPages { get; set; }
		
		public double Weight { get; set; }

		public FluentBook FluentBook { get; set; }
	}
}
