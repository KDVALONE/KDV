using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace N5SportsStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage ="Please enter a product name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage ="Please specify a category")]
        public decimal Price { get; set; }
        public string Category { get; set; }
        
    }
}