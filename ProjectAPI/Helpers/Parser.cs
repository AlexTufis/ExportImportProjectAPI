using CsvHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProjectAPI.Data;
using ProjectAPI.Models;
using ProjectAPI.ModelsCSV;
using ProjectAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Helpers
{
    public class Parser
    {
        public List<Manufacturer> GetManufacturerList(string fName, List<Manufacturer> manufacturersDatabase)
        {
            List<Manufacturer> manufactures = new List<Manufacturer>();
            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                while (csv.Read())
                {
                    csv.ReadHeader();
                    var manufacturerCSV = csv.GetRecords<ManufacturerCSV>().ToList();
                    foreach (var manufacturer in manufacturerCSV)
                    {
                        var exists = manufacturersDatabase.Any(md => md.Name == manufacturer.name || md.Image == manufacturer.image || md.Description == manufacturer.description || md.MetaDescription == manufacturer.meta_description || md.MetaKeyword == manufacturer.meta_keyword);
                        //var exists = manufacturersDatabase.Any(md => md.Name == manufacturer.name);
                        if (exists == true)
                        {
                            manufactures.Add(new Manufacturer()
                            {
                                ManufacturerId = manufacturersDatabase.Where(md => md.Name == manufacturer.name || md.Image == manufacturer.image || md.Description == manufacturer.description || md.MetaDescription == manufacturer.meta_description || md.MetaKeyword == manufacturer.meta_keyword).Select(x=>x.ManufacturerId).FirstOrDefault(),
                                //ManufacturerId = manufacturersDatabase.Where(md => md.Name == manufacturer.name).Select(x => x.ManufacturerId).FirstOrDefault(),
                                Name = manufacturer.name,
                                Image = manufacturer.image,
                                Description = manufacturer.description,
                                MetaDescription = manufacturer.meta_description,
                                MetaKeyword = manufacturer.meta_keyword
                            });
                        }
                        else
                        {
                            manufactures.Add(new Manufacturer()
                            {
                                ManufacturerId = Guid.NewGuid(),
                                Name = manufacturer.name,
                                Image = manufacturer.image,
                                Description = manufacturer.description,
                                MetaDescription = manufacturer.meta_description,
                                MetaKeyword = manufacturer.meta_keyword
                            });
                        }
                    }
                }
            }
            return manufactures;
        }

        public List<Category> GetCategoryList(string fName, List<Category> categoriesDatabase)
        {
            List<Category> categories = new List<Category>();
            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                while (csv.Read())
                {
                    csv.ReadHeader();
                    var categoryCSV = csv.GetRecords<CategoryCSV>().ToList();
                    foreach (var category in categoryCSV)
                    {
                        //var exists = categoriesDatabase.Any(cd => cd.Code == category.code);
                        var exists = categoriesDatabase.Any(cd => cd.Parent == category.parent || cd.Code == category.code || cd.Image == category.image || cd.Url == category.url || cd.Name == category.name || cd.Description == category.description || cd.MetaDescription == category.meta_description || cd.MetaKeywords == category.meta_keyword);
                        if(exists == true)
                        {
                            categories.Add(new Category()
                            {
                                //CategoryId = categoriesDatabase.Where(cd => cd.Code == category.code).Select(x => x.CategoryId).FirstOrDefault(),
                                CategoryId = categoriesDatabase.Where(cd => cd.Parent == category.parent || cd.Code == category.code || cd.Image == category.image || cd.Url == category.url || cd.Name == category.name || cd.Description == category.description || cd.MetaDescription == category.meta_description || cd.MetaKeywords == category.meta_keyword).Select(x => x.CategoryId).FirstOrDefault(),
                                Parent = category.parent,
                                Code = category.code,
                                Image = category.image,
                                Url = category.url,
                                Name = category.name,
                                Description = category.description,
                                MetaDescription = category.meta_description,
                                MetaKeywords = category.meta_keyword
                            });
                        }
                        else
                        { 
                            categories.Add(new Category()
                            {
                                CategoryId = Guid.NewGuid(),
                                Parent = category.parent,
                                Code = category.code,
                                Image = category.image,
                                Url = category.url,
                                Name = category.name,
                                Description = category.description,
                                MetaDescription = category.meta_description,
                                MetaKeywords = category.meta_keyword
                            });
                        }
                    }
                }
            }
            return categories;
        }

        public List<Product> GetProductList(string fName, List<Category> categories, List<Product> productsDatabase)
        {
            List<Product> products = new List<Product>();
            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                while (csv.Read())
                {
                    csv.ReadHeader();
                    var productCSV = csv.GetRecords<ProductCSV>().ToList();
                    foreach (var product in productCSV)
                    {
                        var exists = productsDatabase.Any(pd => pd.EAN == product.barcode);
                        //var exists = categoriesDatabase.Any(cd => cd.Parent == category.parent || cd.Code == category.code || cd.Image == category.image || cd.Url == category.url || cd.Name == category.name || cd.Description == category.description || cd.MetaDescription == category.meta_description || cd.MetaKeywords == category.meta_keyword);
                        if (exists == true)
                        {
                            //    categories.Add(new Category()
                            //    {
                            //        //CategoryId = categoriesDatabase.Where(cd => cd.Code == category.code).Select(x => x.CategoryId).FirstOrDefault(),
                            //        CategoryId = categoriesDatabase.Where(cd => cd.Parent == category.parent || cd.Code == category.code || cd.Image == category.image || cd.Url == category.url || cd.Name == category.name || cd.Description == category.description || cd.MetaDescription == category.meta_description || cd.MetaKeywords == category.meta_keyword).Select(x => x.CategoryId).FirstOrDefault(),
                            //        Parent = category.parent,
                            //        Code = category.code,
                            //        Image = category.image,
                            //        Url = category.url,
                            //        Name = category.name,
                            //        Description = category.description,
                            //        MetaDescription = category.meta_description,
                            //        MetaKeywords = category.meta_keyword
                            //    });
                            //}
                            //else
                            //{
                            //    categories.Add(new Category()
                            //    {
                            //        CategoryId = Guid.NewGuid(),
                            //        Parent = category.parent,
                            //        Code = category.code,
                            //        Image = category.image,
                            //        Url = category.url,
                            //        Name = category.name,
                            //        Description = category.description,
                            //        MetaDescription = category.meta_description,
                            //        MetaKeywords = category.meta_keyword
                            //    });
                            //}
                            products.Add(new Product()
                            {
                                ProductId = productsDatabase.Where(pd => pd.Model == product.model || pd.Name == product.name || pd.ProductUrl == product.product_url || pd.EAN == product.barcode).Select(x => x.ProductId).FirstOrDefault(),
                                Model = product.model,
                                Name = product.name,
                                ProductUrl = product.product_url,
                                EAN = product.barcode,
                                CategoryId = categories.Where(c => c.Code == product.category).Select(c => c.CategoryId).FirstOrDefault()
                            });
                        }
                        else
                        { 
                            products.Add(new Product()
                            {
                                ProductId = Guid.NewGuid(),
                                Model = product.model,
                                Name = product.name,
                                ProductUrl = product.product_url,
                                EAN = product.barcode,
                                CategoryId = categories.Where(c => c.Code == product.category).Select(c=>c.CategoryId).FirstOrDefault()
                            });
                        }
                    }
                }
            }
            return products;
        }
        public List<Pricing> GetPricingsList(string fName, List<Product> products, string distribuitorId, List<Pricing> pricingsDatabase)
        {
            List<Pricing> pricings = new List<Pricing>();
            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                while (csv.Read())
                {
                    csv.ReadHeader();
                    var pricingCSV = csv.GetRecords<PricingCSV>().ToList();
                    foreach (var pricing in pricingCSV)
                    {
                        var exists = pricingsDatabase.Any(pd => pd.Availability == pricing.availability || pd.Price == pricing.price);
                        if (exists == true)
                        {
                            //pricings.Add(new Pricing()
                            //{
                            //    PricingId = Guid.NewGuid(),
                            //    Availability = pricing.availability,
                            //    Price = pricing.price,
                            //    ProductId = products.Where(p => p.Model == pricing.model).Select(p => p.ProductId).FirstOrDefault(),
                            //    DistribuitorId = new Guid(distribuitorId)
                            //});
                            pricings.Add(new Pricing()
                            {
                                PricingId = pricingsDatabase.Where(pd => pd.Availability == pricing.availability || pd.Price == pricing.price).Select(x => x.PricingId).FirstOrDefault(),
                                Availability = pricing.availability,
                                Price = pricing.price,
                                ProductId = products.Where(p => p.EAN == pricing.barcode).Select(p => p.ProductId).FirstOrDefault(),
                                DistribuitorId = new Guid(distribuitorId)
                            });
                        }
                        else
                        {
                            pricings.Add(new Pricing()
                            {
                                PricingId = Guid.NewGuid(),
                                Availability = pricing.availability,
                                Price = pricing.price,
                                ProductId = products.Where(p => p.EAN == pricing.barcode).Select(p => p.ProductId).FirstOrDefault(),
                                DistribuitorId = new Guid(distribuitorId)
                            });
                        }
                    }
                }
            }
            return pricings;
        }

        public string GetFileName(IFormFile file, IHostingEnvironment hostingEnvironment)
        {
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return file.FileName;
        }
    }
}
