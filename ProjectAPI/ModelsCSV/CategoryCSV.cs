using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.ModelsCSV
{
    public class CategoryCSV
    {
        public string parent { get; set; }
        public string code { get; set; }
        public string image { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string meta_description { get; set; }
        public string meta_keyword { get; set; }
        public string category_tree { get; set; }
    }
}
