using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string Parent { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
