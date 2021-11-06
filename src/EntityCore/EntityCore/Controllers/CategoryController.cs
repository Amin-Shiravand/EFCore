using EntityCoreDataAceess.Data;
using EntityCoreModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EntityCore.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext dbContext;

		public CategoryController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public IActionResult Index()
		{
			List<Category> objList = dbContext.Categories.AsNoTracking().ToList();
			return View(objList);
		}

		public IActionResult Upsert(int? Id)
		{
			Category obj = new Category();
			if (Id == null)
			{
				return View(obj);
			}
			obj = dbContext.Categories.FirstOrDefault(c => c.Category_Id == Id);

			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Upsert(Category Category)
		{
			if (ModelState.IsValid)
			{
				if (Category.Category_Id == 0)
				{
					dbContext.Categories.Add(Category);
				}
				else
				{
					dbContext.Categories.Update(Category);
				}
				dbContext.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(Category);
		}

		public IActionResult Delete(int Id)
		{
			Category objectFromDb = dbContext.Categories.FirstOrDefault(c => c.Category_Id == Id);

			if (objectFromDb != null)
			{
				dbContext.Categories.Remove(objectFromDb);
				dbContext.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			else
			{
				return NotFound();
			}
		}

		public IActionResult CreateMultiple2()
		{
			List<Category> categoryList = new List<Category>();

			for (int i = 1; i <= 2; ++i)
			{
				categoryList.Add(new Category { Name = Guid.NewGuid().ToString() });
			}
			dbContext.Categories.AddRange(categoryList);
			dbContext.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult CreateMultiple5()
		{
			List<Category> categoryList = new List<Category>();
			for (int i = 1; i <= 5; ++i)
			{
				categoryList.Add(new Category { Name = Guid.NewGuid().ToString() });
			}
			dbContext.Categories.AddRange(categoryList);
			dbContext.SaveChanges();
			return RedirectToAction(nameof(Index));
		}


		public IActionResult RemoveMultiple2()
		{
			List<Category> categoryList = dbContext.Categories.OrderByDescending(c => c.Category_Id).Take(2).ToList();

		
			dbContext.Categories.RemoveRange(categoryList);
			dbContext.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult RemoveMultiple5()
		{
			List<Category> categoryList = dbContext.Categories.OrderByDescending(u => u.Category_Id).Take(5).ToList();
			dbContext.Categories.RemoveRange(categoryList);
			dbContext.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
	}
}
