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

        public List<Pricing> GetPricingsDatabase()
        {
            return context.Pricings.ToList();
        }

        public List<Product> GetProductsDatabase()
        {
            return context.Products.ToList();
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

        public void InsertPricings(List<Pricing> pricings)
        {
            if (pricings != null)
            {
                foreach (var pricing in pricings)
                {
                    var exist = VerifyIfPricingExists(pricing);
                    if (exist == true)
                    {
                         UpdatePricing(pricing);
                    }
                    else
                    {
                        var item = new Pricing
                        {
                            PricingId = pricing.PricingId,
                            Availability = pricing.Availability,
                            Price = pricing.Price,
                            ProductId = pricing.ProductId,
                            DistribuitorId = pricing.DistribuitorId
                        };
                        context.Pricings.Add(item);
                    }
                }
            }
            Save();
        }

        public void InsertProduct(List<Product> products)
        {
            if (products != null)
            {
                foreach (var product in products)
                {
                    var exist = VerifyIfProductExists(product);
                    if (exist == true)
                    {
                       UpdateProduct(product);
                    }
                    else
                    {
                        var item = new Product
                        {
                            ProductId = product.ProductId,
                            Model = product.Model,
                            Name = product.Name,
                            ProductUrl = product.ProductUrl,
                            EAN = product.EAN,
                            CategoryId = product.CategoryId
                        };
                        context.Products.Add(item);
                    }
                }
            }
            Save();
        }

        public void InsertProductDistribuitors(List<Product> products, string distribuitorId)
        {
            if (products != null)
            {
                foreach (var product in products)
                {
                    var exist = VerifyIfProductDistribuitorExists(product);
                    if (exist == false)
                    {
                        var item = new ProductDistribuitor
                        {
                            ProductDistribuitorId = Guid.NewGuid(),
                            ProductId = product.ProductId,
                            DistribuitorId = new Guid(distribuitorId)
                        };
                        context.ProductDistribuitors.Add(item);
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
                //var updatedCategory = context.Categories.First(c => c.Parent == category.Parent || c.Code == category.Code || c.Image == category.Image || c.Url == category.Url || c.Name == category.Name || c.Description == category.Description || c.MetaDescription == category.MetaDescription || c.MetaKeywords == category.MetaKeywords);
                var updatedCategory = context.Categories.First(c => c.Parent == category.Parent && c.Code == category.Code);
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

        public void UpdatePricing(Pricing pricing)
        {
            try
            {
                var updatedPricing = context.Pricings.First(p => p.Availability == pricing.Availability && p.Price == pricing.Price);
                //var updatedManufacturer = context.Manufacturers.First(m => m.Name == manufacturer.Name);
                updatedPricing.Availability = pricing.Availability;
                updatedPricing.Price = pricing.Price;
            }
            catch (Exception e)
            {
                // handle correct exception
                // log error
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                var updatedProduct = context.Products.First(p => p.EAN == product.EAN);
                //var updatedManufacturer = context.Manufacturers.First(m => m.Name == manufacturer.Name);
                updatedProduct.Model = product.Model;
                updatedProduct.Name = product.Name;
                updatedProduct.ProductUrl = product.ProductUrl;
                updatedProduct.EAN = product.EAN;
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

        public bool VerifyIfPricingExists(Pricing pricing)
        {
            var result = context.Pricings.Where(p => p.PricingId == pricing.PricingId).FirstOrDefault();
            if (result != null)
                return true;
            else
                return false;
        }

        public bool VerifyIfProductDistribuitorExists(Product product)
        {
            var result = context.ProductDistribuitors.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
            if (result != null)
                return true;
            else
                return false;
        }

        public bool VerifyIfProductExists(Product product)
        {
            var result = context.Products.Where(p => p.ProductId == product.ProductId).FirstOrDefault();
            if (result != null)
                return true;
            else
                return false;
        }
    }
}
