using asp_net_core_mvc.Data;
using asp_net_core_mvc.Models;
using asp_net_core_mvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace asp_net_core_mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> objList = _db.Product;
            foreach (Product obj in objList)
            {
                obj.Category = _db.Category.FirstOrDefault(u => u.Id == obj.CategoryId);
            }
            return View(objList);
        }
        public IActionResult Upsert(int? id)
        {
            /*IEnumerable<SelectListItem> CategoryDropDown = _db.Category.Select(i =>
                new SelectListItem { Text = i.Name, Value=i.Id.ToString() });
            ViewBag.CategoryDropDown = CategoryDropDown;

            Product product = new Product();*/
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategorySelectList = _db.Category.Select(i =>
                   new SelectListItem { Text = i.Name, Value = i.Id.ToString() })
            };
            if (id == null)
            {
                return View(productVM); //new -> insert
            } else
            {
                productVM.Product = _db.Product.Find(); //update
                if(productVM.Product == null) { return NotFound(); }
            }
            return View(productVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product obj)
        {
             if (ModelState.IsValid)
            {
                _db.Product.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }
            Product obj = _db.Product.Find(id);
            if (obj == null) { return NotFound(); }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
                var obj = _db.Product.Find(id);
                if (obj == null) { return NotFound(); }
                _db.Product.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            return View(obj);
        }


    }
}
