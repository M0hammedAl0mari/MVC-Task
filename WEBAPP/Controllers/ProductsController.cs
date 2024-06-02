using Microsoft.AspNetCore.Mvc;
using WEBAPP.DB;
using WEBAPP.Models;

namespace WEBAPP.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DB_context _context;
        public ProductsController(DB_context context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        { 
            ViewBag.Action = "add";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product) {
            if (ModelState.IsValid) 
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid) 
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public IActionResult Delete([FromRoute] int? id)
        {
            var product = _context.Products.Find(id.HasValue ? id.Value : 0);

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }




    }
}
