using EntityCoreModel.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EntityCoreModel.ViewModels
{
	public class BookAuthorVM
	{
		public BookAuthor BookAuthor { get; set; }
		public Book Book { get; set; }
		public IEnumerable<BookAuthor> BookAuthorList { get; set; }
		public IEnumerable<SelectListItem> AuthorList{ get; set; }
	}
}
