using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class Manufacturer
    {
        [Key]
        public Guid ManufacturerId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeyword { get; set; }
        public List<ManufacturerDistribuitor> ManufacturerDistribuitors { get; set; }
    }
}
