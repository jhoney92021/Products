using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Models
{
    public class Product
    {
        //LIST OF PROPERTIES
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        public int ProductId { get; set; }
        //Product Name
        [Required]
        [Display(Name = "Product Name:")]
        public string Name {get;set;}
        //Product Name
        //Product Description
        [Required]
        [Display(Name = "Product Description:")]
        public string Description {get;set;}
        //Product Description
        //Product Price
        [Required]
        [Display(Name = "Product Price:")]
        public double Price {get;set;}
        //Product Price
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        //Key For Accociation
        public List<Accociation> Accociated {get;set;}
        //Key For Accociation
        //LIST OF PROPERTIES
    }       
}