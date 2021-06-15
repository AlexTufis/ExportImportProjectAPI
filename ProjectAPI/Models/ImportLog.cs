using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class ImportLog
    {
        [Key]
        public Guid ImportLogId { get; set; }
        public string FileNameBefore { get; set; }
        public string FileNameAfter { get; set; }
        public DateTime ImportDate { get; set; }
        public string RecordImportSucced { get; set; }
        public string RecordImportFailed { get; set; }
        public string ImportType { get; set; }
        public Distribuitor Distribuitor { get; set; }
        public Guid DistribuitorId { get; set; }
    }
}
