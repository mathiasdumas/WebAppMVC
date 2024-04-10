using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = CategoryRepository.GetCategories();
            return View(categories);
        }

        public IActionResult Edit([FromRoute]int? id)
        {
            var category = CategoryRepository.GetCategoryById(id.HasValue?id.Value:0);
            return View(category);
        }
    }
}

