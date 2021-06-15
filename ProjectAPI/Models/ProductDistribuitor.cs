using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class ProductDistribuitor
    {
        [Key]
        public Guid ProductDistribuitorId { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid DistribuitorId { get; set; }
        public Distribuitor Distribuitor { get; set; }
    }
}
