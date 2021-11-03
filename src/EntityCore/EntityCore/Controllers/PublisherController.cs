using EntityCoreDataAceess.Data;
using EntityCoreModel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCore.Controllers
{
	public class PublisherController : Controller
	{
		private readonly ApplicationDbContext dbContext;

		public PublisherController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}


		public IActionResult Index()
		{
			List<Publisher> objList = dbContext.Publishers.ToList();
			return View(objList);
		}

		public IActionResult Upsert(int? Id)
		{
			Publisher obj = new Publisher();
			if (Id == null)
			{
				return View(obj);
			}
			obj = dbContext.Publishers.FirstOrDefault(p => p.Publisher_Id == Id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Upsert(Publisher Obj)
		{
			if (ModelState.IsValid)
			{
				if (Obj.Publisher_Id == 0)
				{
					dbContext.Publishers.Add(Obj);
				}
				else
				{
					dbContext.Publishers.Update(Obj);
				}
				dbContext.SaveChanges();
				return RedirectToAction(nameof(Index));
			}

			return View(Obj);
		}

		public IActionResult Delete(int Id)
		{
			Publisher obj = dbContext.Publishers.FirstOrDefault(p => p.Publisher_Id == Id);
			if (obj != null)
			{
				dbContext.Publishers.Remove(obj);
				dbContext.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return NotFound();
		}

	}
}
