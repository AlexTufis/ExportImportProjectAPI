using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Helpers;
using ProjectAPI.Models;
using ProjectAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    public class ManufacturerController : Controller
    {
        private IExcelRepository excelRepository;
        private IHomeRepository homeRepository;

        public ManufacturerController(IExcelRepository excelRepository, IHomeRepository homeRepository)
        {
            this.excelRepository = excelRepository;
            this.homeRepository = homeRepository;
        }
        public IActionResult Index(string distribuitorId)
        {
            List<Distribuitor> distribuitors = new List<Distribuitor>();
            distribuitors = homeRepository.GetDistribuitors();
            return View(distribuitors);
        }

        [HttpPost]
        public async Task<ActionResult> ImportFile(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment, string distribuitorId)
        {
            List<Distribuitor> distribuitors = new List<Distribuitor>();
            distribuitors = homeRepository.GetDistribuitors();
            var parser = new Parser();
            var manufacturesDatabase = excelRepository.GetManufacturersDatabase();
            var manufactures = parser.GetManufacturerList(parser.GetFileName(file, hostingEnvironment), manufacturesDatabase);
            excelRepository.InsertManufacturer(manufactures);
            excelRepository.InsertManufacturerDistribuitors(manufactures, distribuitorId);
            ViewBag.Message = "Manufacturers uploaded successfully";
            return View("Index", distribuitors);
        }

        public IActionResult Categories(string distribuitorId)
        {
            List<Distribuitor> distribuitors = new List<Distribuitor>();
            distribuitors = homeRepository.GetDistribuitors();
            return View(distribuitors);
        }

        [HttpPost]
        public async Task<ActionResult> ImportFileCategories(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment, string distribuitorId)
        {
            List<Distribuitor> distribuitors = new List<Distribuitor>();
            distribuitors = homeRepository.GetDistribuitors();
            var parser = new Parser();
            parser.GetFileName(file, hostingEnvironment);
            var categoriesDatabase = excelRepository.GetCategoriesDatabase();
            var categories = parser.GetCategoryList(parser.GetFileName(file, hostingEnvironment), categoriesDatabase);
            excelRepository.InsertCategory(categories);
            ViewBag.Message = "Categories uploaded successfully";
            return View("Categories", distribuitors);
        }

        public IActionResult Products(string distribuitorId)
        {
            List<Distribuitor> distribuitors = new List<Distribuitor>();
            distribuitors = homeRepository.GetDistribuitors();
            return View(distribuitors);
        }
    }
}
