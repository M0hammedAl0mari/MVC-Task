using Microsoft.AspNetCore.Mvc;
using WEBAPP.DB;
using WEBAPP.Models;

namespace WEBAPP.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DB_context _context;

        public CategoriesController(DB_context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpGet] 
        public IActionResult Add()
        {
            ViewBag.Action = "add";
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Delete([FromRoute]int? id)
        {
            var category = _context.Categories.Find(id.HasValue ? id.Value : 0);
            
                _context.Categories.Remove(category);
                _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
