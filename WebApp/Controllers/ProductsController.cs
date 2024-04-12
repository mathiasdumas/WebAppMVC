using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = ProductsRepository.GetProducts(loadCategory: true);
            return View(products);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";
            var productViewModel = new ProductViewModel
            {
                Categories = CategoryRepository.GetCategories()
            };

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.AddProduct(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }

            productViewModel.Categories = CategoryRepository.GetCategories();
            return View(productViewModel);
        }

        public IActionResult Edit(int id)
        {
            
            var productViewModel = new ProductViewModel
            {
                Product = ProductsRepository.GetProductById(id) ?? new Product(),
                Categories = CategoryRepository.GetCategories()
            };

            return View(productViewModel);
            
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.UpdateProduct(productViewModel.Product.ProductId, productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "edit";
            productViewModel.Categories = CategoryRepository.GetCategories();
            return View(productViewModel);
        }
    }
}

