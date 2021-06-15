using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class ProductImage
    {
        [Key]
        public Guid ProductImageId { get; set; }
        public string ProductImageUrl { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
    }
}
