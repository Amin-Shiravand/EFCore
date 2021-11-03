
using System.Collections.Generic;

namespace EntityCoreModel.Models.Fluent
{
	public class FluentPublisher
	{
		public int Publisher_Id { get; set; }
	
		public string Name { get; set; }
	
		public string Location { get; set; }

		public List<FluentBook> FluentBooks { get; set; }
	}
}
