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
        public bool VerifyIfManufacturerDistribuitorExists(Manufacturer manufacturer);
        public void UpdateManufacturer(Manufacturer manufacturer);
        public void UpdateCategory(Category category);
        public List<Manufacturer> GetManufacturersDatabase();
        public List<Category> GetCategoriesDatabase();
    }
}
