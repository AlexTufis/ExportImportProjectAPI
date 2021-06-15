using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class Parameter
    {
        [Key]
        public Guid ParameterId { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
    }
}
