using System;
using System.Collections.Generic;

namespace EntityCoreModel.Models.Fluent
{
	public class FluentAuthor
	{
		
		public int Author_Id { get; set; }
	
		public string FirstName { get; set; }
		
		public string LastName { get; set; }
		
		public DateTime BirthDate { get; set; }
	
		public string Location { get; set; }
	
		public ICollection<FluentBookAuthor> FluentBookAuthors { get; set; }


		public string FullName
		{
			get
			{
				return $"{FirstName} {LastName}";
			}
		}

	}
}
