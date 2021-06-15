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
                        //var exists = manufacturersDatabase.Any(md => md.Name == manufacturer.name || md.Image == manufacturer.image || md.Description == manufacturer.description || md.MetaDescription == manufacturer.meta_description || md.MetaKeyword == manufacturer.meta_keyword);
                        var exists = manufacturersDatabase.Any(md => md.Name == manufacturer.name);
                        if (exists == true)
                        {
                            manufactures.Add(new Manufacturer()
                            {
                                //ManufacturerId = manufacturersDatabase.Where(md => md.Name == manufacturer.name || md.Image == manufacturer.image || md.Description == manufacturer.description || md.MetaDescription == manufacturer.meta_description || md.MetaKeyword == manufacturer.meta_keyword).Select(x=>x.ManufacturerId).FirstOrDefault(),
                                ManufacturerId = manufacturersDatabase.Where(md => md.Name == manufacturer.name).Select(x => x.ManufacturerId).FirstOrDefault(),
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
                        var exists = categoriesDatabase.Any(cd => cd.Code == category.code);
                        if(exists == true)
                        {
                            categories.Add(new Category()
                            {
                                CategoryId = categoriesDatabase.Where(cd => cd.Code == category.code).Select(x => x.CategoryId).FirstOrDefault(),
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
