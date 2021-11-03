using EntityCoreDataAceess.Data;
using EntityCoreModel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCore.Controllers
{
	public class AuthorController : Controller
	{
		private readonly ApplicationDbContext dbContext;

		public AuthorController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

        public IActionResult Index()
        {
            List<Author> objList = dbContext.Authors.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? Id)
        {
            Author obj = new Author();
            if(Id == null)
			{
                return View(obj);
			}
            obj = dbContext.Authors.FirstOrDefault(a => a.Author_Id == Id);
            if(obj == null)
			{
                return NotFound();
			}
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Author Obj)
        {
			if (ModelState.IsValid)
			{
                if(Obj.Author_Id ==0)
                {
                    dbContext.Authors.Add(Obj);
				}
				else 
                {
                    dbContext.Authors.Update(Obj);
                }
                dbContext.SaveChanges();
                RedirectToAction(nameof(Index));
			}
            return View(Obj);
        }

        public IActionResult Delete(int Id)
        {
            Author obj = dbContext.Authors.FirstOrDefault(a => a.Author_Id == Id);
            if(obj != null)
			{
                dbContext.Authors.Remove(obj);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
