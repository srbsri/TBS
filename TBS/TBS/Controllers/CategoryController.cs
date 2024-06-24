﻿using Microsoft.AspNetCore.Mvc;
using TBS.DataAccess.Data;
using TBS.Models;


namespace TBSWeb.Controllers
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

        {
            if (id == null || id == null)
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
            TempData["success"] = "Category Updated Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)

        {
            if (id == null || id == null)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);

            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }

        //public IActionResult Delete(int? id)

        //{
        //    if (id == null || id == null)
        //    {
        //        return NotFound();
        //    }
        //    Category categoryFromDb = _db.Categories.Find(id);

        //    return View(categoryFromDb);
        //}
        //[HttpPost]
        //public IActionResult Delete(Category obj)
        //{
        //    Category objj = _db.Categories.Find(obj.Id);
        //    if (objj == null)
        //    {
        //        return NotFound();
        //    }
        //    _db.Categories.Remove(objj);
        //    _db.SaveChanges();
        //    TempData["success"] = "Category Deleted Successfully";
        //    return RedirectToAction("Index");
        //}

    }
}

