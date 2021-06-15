using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class Distribuitor
    {
        [Key]
        public Guid DistribuitorId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public List<ManufacturerDistribuitor> ManufactureDistribuitors { get; set; }
        public List<ProductDistribuitor> ProductDistribuitors { get; set; }
        public ICollection<ImportLog> ImportLogs { get; set; }
    }
}
