using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.ModelsCSV
{
    public class ProductCSV
    {
        public string model { get; set; }
        public string name { get; set; }
        public string product_image_url { get; set; }
        public string category { get; set; }
        public string product_url { get; set; }
        public string dimensions_length { get; set; }
        public string dimensions_width { get; set; }
        public string dimensions_height { get; set; }
        public string availability { get; set; }
        public string price { get; set; }
        public string manufacturer { get; set; }
        public string description { get; set; }
        public string tag { get; set; }
        public string meta_keyword { get; set; }
        public string weight { get; set; }
        public string barcode { get; set; }
        public string k8_branch { get; set; }
    }
}
