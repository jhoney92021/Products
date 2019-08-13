using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Models
{
    public class Category
    {
        //LIST OF PROPERTIES
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        public int CategoryId { get; set; }
        //Category Name
        [Required]
        [Display(Name = "Category Name:")]
        public string Name {get;set;}
        //Category Name
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        //Key For Accociation
        public List<Accociation> Accociated {get;set;}
        //Key For Accociation
        //LIST OF PROPERTIES
    }       
}