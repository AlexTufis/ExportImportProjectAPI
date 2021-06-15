using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class Contact
    {
        [Key]
        public Guid ContactId { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public Guid DistribuitorId { get; set; }
        public Distribuitor Distribuitor { get; set; }
    }
}
