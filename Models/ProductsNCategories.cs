using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Models
{    public class ProductsNCategories
    {
        public IEnumerable<Product> Products {get;set;}
        public Product product {get;set;}
        public IEnumerable<Category> Categories {get;set;}
        public Category category {get;set;}
    }
}