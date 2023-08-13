using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objList = _db.Categories.AsNoTracking().ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Category obj = new();
            if (id == null || id == 0)
            {
                //Create
                return View(obj);
            }
            //Edit
            obj = _db.Categories.FirstOrDefault(u => u.CategoryId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Category obj = new();
            obj = _db.Categories.FirstOrDefault(u => u.CategoryId == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.CategoryId == 0)
                {
                    //create
                    await _db.Categories.AddAsync(obj);
                }
                else
                {
                    //update
                    _db.Categories.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult CreateMultiple2()
        {
            List<Category> obj = new List<Category>();
            for (int i = 1; i <= 2; i++)
            {
                obj.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
            }
            _db.Categories.AddRange(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult CreateMultiple5()
        {
            List<Category> obj = new List<Category>();
            for (int i = 1; i <= 5; i++)
            {
                obj.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
            }
            _db.Categories.AddRange(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult RemoveMultiple2()
        {
            List<Category> obj = _db.Categories.OrderByDescending(x => x.CategoryId).Take(2).ToList();
            _db.Categories.RemoveRange(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult RemoveMultiple5()
        {
            List<Category> obj = _db.Categories.OrderByDescending(x => x.CategoryId).Take(5).ToList();
            _db.Categories.RemoveRange(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
