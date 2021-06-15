using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class ManufacturerDistribuitor
    {
        [Key]
        public Guid ManufacturerDistribuitorId { get; set; }
        public Guid DistribuitorId { get; set; }
        public Distribuitor Distribuitor { get; set; }
        public Guid ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
