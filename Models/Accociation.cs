using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Models
{
    //ASSOCIATION HAS BEEN SPELLED INCORRECTLY
    //THIS FAR ALONG I JUST DO NOT CARE
    public class Accociation
    {
        //TABLE FOR PRODUCT CATEGORY RELATIONSHIP
        //LIST OF SPECIFIC RELATIONSHIPS
        //RELATIONSHIP KEY
        [Key]
        public int AccociationId { get; set; }
        //RELATIONSHIP KEY
        //KEYS
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        //KEYS
        //RELATED NAMES
        public Product AccociatedProducts { get; set; }
        public Category AccociatedCategories { get; set; }
        //RELATED NAMES
        //LIST OF SPECIFIC RELATIONSHIPS
        //TABLE FOR PRODUCT CATEGORY RELATIONSHIP
    }       
}