using Microsoft.EntityFrameworkCore;
using ProjectAPI.Data;
using ProjectAPI.Models;
using ProjectAPI.ModelsCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Repositories
{
    public class ExcelRepository : IExcelRepository
    {
        private ApplicationDbContext context;

        public ExcelRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Category> GetCategoriesDatabase()
        {
            return context.Categories.ToList();
        }

        public List<Manufacturer> GetManufacturersDatabase()
        {
            return context.Manufacturers.ToList();
        }

        public void InsertCategory(List<Category> categories)
        {
            if (categories != null)
            {
                foreach (var category in categories)
                {
                    var exist = VerifyIfCategoryExists(category);
                    if (exist == true)
                    {
                        UpdateCategory(category);
                    }
                    else
                    { 
                        var item = new Category
                        {
                            CategoryId = category.CategoryId,
                            Parent = category.Parent,
                            Code = category.Code,
                            Image = category.Image,
                            Url = category.Url,
                            Name = category.Name,
                            Description = category.Description,
                            MetaDescription = category.MetaDescription,
                            MetaKeywords = category.MetaKeywords
                        };
                        context.Categories.Add(item);
                    }
                }
            }
            Save();
        }

        public void InsertManufacturer(List<Manufacturer> manufacturers)
        {
            if (manufacturers != null)
            {
                foreach (var manufacturer in manufacturers)
                {
                    var exist = VerifyIfManufacturerExists(manufacturer);
                    if (exist == true)
                    {
                        UpdateManufacturer(manufacturer);
                    }
                    else
                    {
                        var item = new Manufacturer
                        {
                            ManufacturerId = manufacturer.ManufacturerId,
                            Name = manufacturer.Name,
                            Image = manufacturer.Image,
                            Description = manufacturer.Description,
                            MetaDescription = manufacturer.MetaDescription,
                            MetaKeyword = manufacturer.MetaKeyword
                        };
                        context.Manufacturers.Add(item);
                    }
                }
            }
            Save();
        }

        public void InsertManufacturerDistribuitors(List<Manufacturer> manufacturers, string distribuitorId)
        {
            if (manufacturers != null)
            {
                foreach (var manufacturer in manufacturers)
                {
                    var exist = VerifyIfManufacturerDistribuitorExists(manufacturer);
                    if (exist == false)
                    {
                        var item = new ManufacturerDistribuitor
                        {
                            ManufacturerDistribuitorId = Guid.NewGuid(),
                            ManufacturerId = manufacturer.ManufacturerId,
                            DistribuitorId = new Guid(distribuitorId)
                        };
                        context.ManufacturerDistribuitors.Add(item);
                    }
                }
                Save();
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            try
            {
                //var updatedManufacturer = context.Manufacturers.First(m => m.Name == manufacturer.Name || m.Image == manufacturer.Image || m.Description == manufacturer.Description || m.MetaDescription == manufacturer.MetaDescription || m.MetaKeyword == manufacturer.MetaKeyword);
                var updatedCategory = context.Categories.First(c => c.Code == category.Code);
                updatedCategory.Parent = category.Parent;
                updatedCategory.Code = category.Code;
                updatedCategory.Image = category.Image;
                updatedCategory.Url = category.Url;
                updatedCategory.Name = category.Name;
                updatedCategory.Description = category.Description;
                updatedCategory.MetaDescription = category.MetaDescription;
                updatedCategory.MetaKeywords = category.MetaKeywords;
                //updatedCategory.Name = category.Name;
                //updatedCategory. = manufacturer.Image;
                //updatedManufacturer.Description = manufacturer.Description;
                //updatedManufacturer.MetaDescription = manufacturer.MetaDescription;
                //updatedManufacturer.MetaKeyword = manufacturer.MetaKeyword;
            }
            catch (Exception e)
            {
                // handle correct exception
                // log error
            }
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            try
            {
                //var updatedManufacturer = context.Manufacturers.First(m => m.Name == manufacturer.Name || m.Image == manufacturer.Image || m.Description == manufacturer.Description || m.MetaDescription == manufacturer.MetaDescription || m.MetaKeyword == manufacturer.MetaKeyword);
                var updatedManufacturer = context.Manufacturers.First(m => m.Name == manufacturer.Name);
                updatedManufacturer.Name = manufacturer.Name;
                updatedManufacturer.Image = manufacturer.Image;
                updatedManufacturer.Description = manufacturer.Description;
                updatedManufacturer.MetaDescription = manufacturer.MetaDescription;
                updatedManufacturer.MetaKeyword = manufacturer.MetaKeyword;
            }
            catch (Exception e)
            {
                // handle correct exception
                // log error
            }
        }

        public bool VerifyIfCategoryExists(Category category)
        {
            var result = context.Categories.Where(c => c.CategoryId == category.CategoryId).FirstOrDefault();
            if (result != null)
                return true;
            else
                return false;
        }

        public bool VerifyIfManufacturerDistribuitorExists(Manufacturer manufacturer)
        {
            var result = context.ManufacturerDistribuitors.Where(x => x.ManufacturerId == manufacturer.ManufacturerId).FirstOrDefault();
            if (result != null)
                return true;
            else
                return false;
        }

        public bool VerifyIfManufacturerExists(Manufacturer manufacturer)
        {
            var result = context.Manufacturers.Where(m => m.ManufacturerId == manufacturer.ManufacturerId).FirstOrDefault();
            if (result != null)
                return true;
            else
                return false;
        }
    }
}
