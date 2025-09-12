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
        public CategoryController(ApplicationDbContext db,ILogger<CategoryController> logger)
        {
            _db = db;
            _logger = logger;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Category> ObjectCategoy = _db.Categories.ToList();
            return View(ObjectCategoy);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString()) {
                ModelState.AddModelError("name", "name and display cannot be same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                // Redirects to /Category/Index
                return RedirectToAction("Index", "Category");
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}