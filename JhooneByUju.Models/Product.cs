using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JhooneByUju.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Product Name")]
        public string Title { get; set; }
        public string Description { get; set; }
        public int StoreCode { get; set; }
        public string Designer { get; set; }
        [Required ]
        [DisplayName("List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }
        [Required]
        [DisplayName("Price for 1-14")]
        [Range(1, 1000)]
        public double Price { get; set; }
        [Required]
        [DisplayName("Price for 15+")]
        [Range(1, 1000)]
        public double Price15 { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
