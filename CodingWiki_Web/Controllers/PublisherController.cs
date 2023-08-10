using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Publisher obj)
        {
            return View();
        }
    }
}
