using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Microsoft.EntityFrameworkCore;//BRINGS IN MYSQL, AND OTHER THINGS LIKE .Include()

namespace Products.Controllers
{
    public class CategoryController : Controller
    {

        private ProductContext dbContext;
     
        // here we can "inject" our context service into the constructor
        public CategoryController(ProductContext context)
        {
            dbContext = context;
        }
        //localhost5000/Category/Index
        [HttpGet("Category")]
        public IActionResult Index()
        {
            List<Category> AllCategories = dbContext.Categories
            .Include(category => category.Accociated)
            .ThenInclude(product => product.AccociatedProducts)
            .ToList();
            return View(AllCategories);
        }
        //localhost5000/Category/Index
        //localhost5000/Category/Create
        [HttpPost("Category/Create")]
        public IActionResult Create(Category newCategory)
        {
            dbContext.Add(newCategory);
            dbContext.SaveChanges();
            return RedirectToAction("Index","Category");
        }
        //localhost5000/Category/Create
        //localhost5000/Category/View/{id}
        [HttpGet("Category/View/{id}")]
        public IActionResult ViewCategory(int id)
        {
            Console.WriteLine("-----------View Category Route---------");
            int categoryId = id;
            Category thisCategory = dbContext.Categories
                .Include(product => product.Accociated)
                .ThenInclude(category => category.AccociatedCategories)
                .FirstOrDefault(category => category.CategoryId == categoryId);

            List<Product> AllProducts = dbContext.Products
                .OrderByDescending(ch => ch.CreatedAt)
                .ToList();

            ProductsNCategories viewModel = new ProductsNCategories();
                viewModel.Products = AllProducts;
                viewModel.category = thisCategory;

            return View(viewModel);
        }
        //localhost5000/Category/View/{id}
        //localhost5000/Category/AddCategory/{id}
        [HttpPost("Category/AddProduct/{id}")]
        public IActionResult AddProduct(int id, int productId)
        {
            Console.WriteLine("-----------AddProduct Route---------");
            Console.WriteLine($"-----------{id}---------");
            Console.WriteLine($"-----------{productId}---------");
            Accociation newAccociation = new Accociation();
            newAccociation.CategoryId = id;
            newAccociation.ProductId = productId;
            dbContext.Add(newAccociation);
            dbContext.SaveChanges();
            return RedirectToAction("ViewCategory", new{id = id});
        }
        //localhost5000/Category/AddCategory/{id}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
