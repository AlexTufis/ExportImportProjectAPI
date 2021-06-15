using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string ProductUrl { get; set; }
        public string EAN { get; set; }
        public List<ProductDistribuitor> ProductDistribuitors { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Parameter Parameter { get; set; }
        public Guid ParameterId { get; set; }
        public ProductImage ProductImage { get; set; }
        public Guid ProductImageId { get; set; }
        public Guid PricingId { get; set; }
    }
}
