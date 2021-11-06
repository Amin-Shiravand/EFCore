using EntityCoreDataAceess.Data;
using EntityCoreModel.Models;
using EntityCoreModel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCore.Controllers
{
	public class BookController : Controller
	{
		private ApplicationDbContext dbContext;

		public BookController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public IActionResult Index()
		{
			List<Book> objList = dbContext.Books.Include(p => p.Publisher)
				.Include(p => p.BookAuthors).
				 ThenInclude(p => p.Author).ToList();
			//List<Book> objList = _db.Books.ToList();
			//foreach (var obj in objList)
			//{
			//    //Least Effecient
			//    //obj.Publisher = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == obj.Publisher_Id);

			//    //Explicit Loading More Efficient
			//    _db.Entry(obj).Reference(u => u.Publisher).Load();
			//    _db.Entry(obj).Collection(u => u.BookAuthors).Load();
			//    foreach(var bookAuth in obj.BookAuthors)
			//    {
			//        _db.Entry(bookAuth).Reference(u => u.Author).Load();
			//    }
			//}
			return View(objList);
		}

		public IActionResult Upsert(int? Id)
		{
			BookVM obj = new BookVM();
			obj.PublisherList = dbContext.Publishers.Select(i => new SelectListItem
			{
				Text = i.Name,
				Value = i.Publisher_Id.ToString()
			});
			if (Id == null)
			{
				return View(obj);
			}
			obj.Book = dbContext.Books.FirstOrDefault(b => b.Book_Id == Id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Upsert(BookVM Obj)
		{

			if (Obj.Book.Book_Id == 0)
			{
				dbContext.Books.Add(Obj.Book);
			}
			else
			{
				dbContext.Books.Update(Obj.Book);
			}


			dbContext.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Details(int? Id)
		{
			BookVM obj = new BookVM();

			if (Id == null)
			{
				return View(obj);
			}
			//obj.Book = dbContext.Books.FirstOrDefault(b => b.Book_Id == Id);
			//obj.Book.BookDetail = dbContext.BookDetails.Where(u => u.BookDetail_Id == obj.Book.BookDetail_Id).FirstOrDefault();
			obj.Book = dbContext.Books.Include(b => b.BookDetail).FirstOrDefault(b => b.BookDetail_Id == Id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Details(BookVM Obj)
		{

			if (Obj.Book.BookDetail.BookDetail_Id == 0)
			{
				dbContext.BookDetails.Add(Obj.Book.BookDetail);
				dbContext.SaveChanges();
				Book bookFromDb = dbContext.Books.Where(u => u.Book_Id == Obj.Book.Book_Id).FirstOrDefault();
				bookFromDb.BookDetail_Id = Obj.Book.BookDetail.BookDetail_Id;
				dbContext.SaveChanges();
			}
			else
			{
				dbContext.BookDetails.Update(Obj.Book.BookDetail);
				dbContext.SaveChanges();
			}

			return RedirectToAction(nameof(Index));
		}

		public IActionResult Delete(int Id)
		{
			Book obj = dbContext.Books.FirstOrDefault(b => b.Book_Id == Id);
			dbContext.Books.Remove(obj);
			dbContext.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult ManageAuthors(int Id)
		{
			BookAuthorVM obj = new BookAuthorVM
			{
				BookAuthorList = dbContext.BookAuthors.Include(u => u.Author).Include(u => u.Author).Where(u => u.Book_Id == Id).ToList(),
				BookAuthor = new BookAuthor()
				{
					Book_Id = Id
				},
				Book = dbContext.Books.FirstOrDefault(u => u.Book_Id == Id)
			};
			List<int> tempListOfAssignOfAuthors = obj.BookAuthorList.Select(u => u.Author_Id).ToList();
			List<Author> tempList = dbContext.Authors.Where(u => !tempListOfAssignOfAuthors.Contains(u.Author_Id)).ToList();
			obj.AuthorList = tempList.Select(i => new SelectListItem
			{
				Text = i.FullName,
				Value = i.Author_Id.ToString()
			});
			return View(obj);
		}

		[HttpPost]
		public IActionResult ManageAuthors(BookAuthorVM BookAuthorVM)
		{
			if (BookAuthorVM.BookAuthor.Book_Id != 0 && BookAuthorVM.BookAuthor.Author_Id != 0)
			{
				dbContext.BookAuthors.Add(BookAuthorVM.BookAuthor);
				dbContext.SaveChanges();
			}
			return RedirectToAction(nameof(ManageAuthors), new { @Id = BookAuthorVM.BookAuthor.Book_Id });
		}

		[HttpPost]
		public IActionResult RemoveAuthors(int AuthorId, BookAuthorVM BookAuthorVM)
		{
			int bookId = BookAuthorVM.Book.Book_Id;
			BookAuthor bookAuthor = dbContext.BookAuthors.FirstOrDefault(u => u.Author_Id == AuthorId && u.Book_Id == bookId);

			dbContext.BookAuthors.Remove(bookAuthor);
			dbContext.SaveChanges();
			return RedirectToAction(nameof(ManageAuthors), new { @Id = bookId });
		}

		public IActionResult PlayGround()
		{
			Book bookTemp = dbContext.Books.FirstOrDefault();
			bookTemp.Price = 100;
			DbSet<Book> bookCollection = dbContext.Books;
			double totalPrice = 0;
			foreach (Book book in bookCollection)
			{
				totalPrice += book.Price;
			}
			List<Book> bookList = dbContext.Books.ToList();
			for (int i = 0; i < bookList.Count; ++i)
			{
				totalPrice += bookList[i].Price;
			}

			DbSet<Book> bookCollection1 = dbContext.Books;
			int BookCount = bookCollection1.Count();
			int BookCount1 = dbContext.Books.Count();

			IEnumerable<Book> bookList2 = dbContext.Books;
			List<Book> filteredBook = bookList2.Where(b => b.Price > 500).ToList();
			IQueryable<Book> BookList3 = dbContext.Books;
			List<Book> filterdBook2 = BookList3.Where(b => b.Price > 500).ToList();
			Book bookTemp1 = dbContext.Books.Include(b => b.BookDetail).FirstOrDefault(b => b.Book_Id == 1);
			bookTemp1.BookDetail.NumberOfChapters = 2222;
			dbContext.Books.Update(bookTemp1);
			dbContext.SaveChanges();
			Book bookTemp2 = dbContext.Books.Include(b => b.BookDetail).FirstOrDefault(b => b.Book_Id == 1);
			bookTemp1.BookDetail.Weight = 3333;
			dbContext.Books.Attach(bookTemp2);
			dbContext.SaveChanges();
			List<BookDetailsFromView> list1 = dbContext.BookDetailsFromViews.ToList();
			BookDetailsFromView list2 = dbContext.BookDetailsFromViews.FirstOrDefault();
			IQueryable<BookDetailsFromView> list3 = dbContext.BookDetailsFromViews.Where(u => u.Price > 500);

			//RAW SQL

			var bookRaw = dbContext.Books.FromSqlRaw("Select * from dbo.books").ToList();

			//SQL Injection attack prone
			int id = 2;
			List<Book> bookTemp3 = dbContext.Books.FromSqlInterpolated($"Select * from dbo.books where Book_Id={id}").ToList();
			List<Book> booksSproc = dbContext.Books.FromSqlInterpolated($" EXEC dbo.getAllBookDetails {id}").ToList();
			 
			List<Book> BookFilter1 = dbContext.Books.Include(e => e.BookAuthors.Where(p => p.Author_Id == 5)).ToList();
			List<Book> BookFilter2 = dbContext.Books.Include(e => e.BookAuthors.OrderByDescending(p => p.Author_Id).Take(2)).ToList();
			return RedirectToAction(nameof(Index));
		}
	}
}
