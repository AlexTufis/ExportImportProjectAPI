using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class History
    {
        [Key]
        public Guid HistoryId { get; set; }
        public string FieldName { get; set; }
        public string ValueBefore { get; set; }
        public string ValueAfter { get; set; }
        public DateTime Date { get; set; }
        public Table Table { get; set; }
        public Guid TableId { get; set; }
        public string UserId { get; set; }
    }
}
