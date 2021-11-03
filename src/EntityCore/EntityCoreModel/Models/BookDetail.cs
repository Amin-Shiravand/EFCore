using System.ComponentModel.DataAnnotations;


namespace EntityCoreModel.Models
{
	public class BookDetail
	{
		[Key]
		public int BookDetail_Id { get; set; }
		[Required]
		public int NumberOfChapters { get; set; }
		[Required]
		public int NumberOfPages { get; set; }
		[Required]
		public double Weight { get; set; }
		
		public Book Book { get; set; }
	}
}
