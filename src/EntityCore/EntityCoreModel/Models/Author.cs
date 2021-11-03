using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCoreModel.Models
{
	public class Author
	{
		[Key]
		public int Author_Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public DateTime BirthDate { get; set; }
		[Required]
		public string Location { get; set; }
		[NotMapped]
		public string FullName
		{
			get
			{
				return $"{FirstName} {LastName}";
			}
		}

		public ICollection<BookAuthor> BookAuthors { get; set; }
	}
}
