using Microsoft.AspNetCore.Mvc;
using TBS.Data;
using TBS.Models;

namespace TBS.Controllers
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
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {           
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {

            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Created Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
            
        {if (id== null || id == null)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id);

            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Created Successfully";
            return RedirectToAction("Index");
        }

        //public IActionResult Edit(int? id)
        //{
        //    if (id== null || id==0)
        //    {
        //        return NotFound();
        //    }
        //    Category categoryFromDb= _db.Categories.Find(id);
        //    if (categoryFromDb==null)
        //    {
        //        return NotFound();
        //    }

        //    //Category categoryFromDb= _db.Categories.FirstOrDefault(c=>c.Id==id);
        //    return View(categoryFromDb);
        //}
        //[HttpPost]
        //public IActionResult Edit(Category obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Categories.Update(obj);
        //        _db.SaveChanges();
        //        TempData["success"] = "Category Updated Successfully";
        //        return RedirectToAction("Index");
        //    }
        //}
    }
}

