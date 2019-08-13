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
    public class ProductController : Controller
    {

        private ProductContext dbContext;
     
        // here we can "inject" our context service into the constructor
        public ProductController(ProductContext context)
        {
            dbContext = context;
        }
        //localhost5000/
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Product> AllProducts = dbContext.Products
            .Include(product => product.Accociated)
            .ThenInclude(category => category.AccociatedCategories)
            .ToList();
            return View(AllProducts);
        }
        //localhost5000/
        //localhost5000/Product/Create
        [HttpPost("Product/Create")]
        public IActionResult Create(Product newProduct)
        {
            dbContext.Add(newProduct);
            dbContext.SaveChanges();
            return RedirectToAction("Index","Product");
        }
        //localhost5000/Product/Create
        //localhost5000/Product/View/{id}
        [HttpGet("Product/View/{id}")]
        public IActionResult ViewProduct(int id)
        {
            int productId = id;
            Console.WriteLine("-----------View Product Route---------");
            Console.WriteLine($"-----------{productId}---------");
            Product thisProduct = dbContext.Products
                .Include(product => product.Accociated)
                .ThenInclude(category => category.AccociatedCategories)
                .FirstOrDefault(product => product.ProductId == productId);
            Console.WriteLine($"-----------{thisProduct.Name}---------");
            
            List<Category> AllCategories = dbContext.Categories
                .OrderByDescending(ch => ch.CreatedAt)
                .ToList();

            ProductsNCategories viewModel = new ProductsNCategories();
                viewModel.Categories = AllCategories;
                viewModel.product = thisProduct;

            return View(viewModel);
        }
        //localhost5000/Product/View/{id}
        //localhost5000/Product/AddCategory/{id}
        [HttpPost("Product/AddCategory/{id}")]
        public IActionResult AddCategory(int id, int categoryId)
        {
            Console.WriteLine("-----------AddCategory Route---------");
            Console.WriteLine($"-----------{id}---------");
            Console.WriteLine($"-----------{categoryId}---------");
            Accociation newAccociation = new Accociation();
            newAccociation.CategoryId = categoryId;
            newAccociation.ProductId = id;
            dbContext.Add(newAccociation);
            dbContext.SaveChanges();
            return RedirectToAction("ViewProduct", new{id = id});
        }
        //localhost5000/Product/AddCategory/{id}

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
