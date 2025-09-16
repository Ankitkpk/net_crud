using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolSysterm.Models;

namespace SchoolSysterm.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db, ILogger<CategoryController> logger)
        {
            _db = db;
            _logger = logger;
        }

        // GET: /Category
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Category> ObjectCategoy = _db.Categories.ToList();
            return View(ObjectCategoy);
        }

        // GET: /Category/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Category/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        // GET: /Category/Edit/5
        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: /Category/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        [HttpGet("Delete/{id}")]
public IActionResult Delete(int? id)
{
    if (id == null || id == 0)
    {
        return NotFound();
    }

    var obj = _db.Categories.Find(id);
    if (obj == null)
    {
        return NotFound();
    }

    return View(obj); // Show confirmation page
}

    // POST: /Category/Delete/5
    [HttpPost("DeleteConfirmed/{id}"), ActionName("Delete") ]
    public IActionResult DeleteConfirmed(int id)
   {
    var obj = _db.Categories.Find(id);
    if (obj == null)
    {
        return NotFound();
    }

    _db.Categories.Remove(obj);
    _db.SaveChanges();

    return RedirectToAction("Index");
}
        // GET: /Category/Error
        [HttpGet("Error")]
        public IActionResult Error()
        {
            return View("Error");
        }
    }



}