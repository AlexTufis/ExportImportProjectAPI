using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class Pricing
    {
        [Key]
        public Guid PricingId { get; set; }
        public string Availability { get; set; }
        public string Price { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Distribuitor Distribuitor { get; set; }
        [ForeignKey("Distribuitor")]
        public Guid DistribuitorId { get; set; }
    }
}
