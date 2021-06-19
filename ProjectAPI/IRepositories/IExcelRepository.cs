using ProjectAPI.Models;
using ProjectAPI.ModelsCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Repositories
{
    public interface IExcelRepository
    {
        public void Save();
        public void InsertManufacturer(List<Manufacturer> manufacturers);
        public void InsertManufacturerDistribuitors(List<Manufacturer> manufacturers, string distribuitorId);
        public void InsertCategory(List<Category> categories);
        public bool VerifyIfManufacturerExists(Manufacturer manufacturer);
        public bool VerifyIfCategoryExists(Category category);
        public bool VerifyIfPricingExists(Pricing pricing);
        public bool VerifyIfProductExists(Product product);
        public bool VerifyIfManufacturerDistribuitorExists(Manufacturer manufacturer);
        public bool VerifyIfProductDistribuitorExists(Product product);
        public void UpdateManufacturer(Manufacturer manufacturer);
        public void UpdateCategory(Category category);
        public void UpdatePricing(Pricing pricing);
        public void UpdateProduct(Product product);
        public List<Manufacturer> GetManufacturersDatabase();
        public List<Category> GetCategoriesDatabase();
        public List<Product> GetProductsDatabase();
        public List<Pricing> GetPricingsDatabase();
        public void InsertProduct(List<Product> products);
        public void InsertPricings(List<Pricing> pricings);
        public void InsertProductDistribuitors(List<Product> products, string distribuitorId);
    }
}
