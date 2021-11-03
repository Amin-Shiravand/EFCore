
using System.Collections.Generic;

namespace EntityCoreModel.Models.Fluent
{
	public class FluentBook
	{
		public int Book_Id { get; set; }

		public string Title { get; set; }

		public string ISBN { get; set; }

		public double Price { get; set; }

		public int FluentBookDetail_Id { get; set; }

		public FluentBookDetail FluentBookDetail { get; set; }

		public int FluentPublisher_Id { get; set; }

		public FluentPublisher FluentPublisher { get; set; }

		public ICollection<FluentBookAuthor> FluentBookAuthors { get; set; }
	}
}
