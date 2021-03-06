﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using TubeStore.ViewModels.Admin;
using TubeStore.DataLayer;
using TubeStore.Models;

namespace TubeStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class TubeController : Controller
    {
        private readonly IGenericRepository<Tube> tubes;
        private readonly IGenericRepository<Category> categories;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly ILogger<TubeController> logger;

        public TubeController(IGenericRepository<Tube> tubes,
                              IGenericRepository<Category> categories,
                              IWebHostEnvironment hostEnvironment,
                              ILogger<TubeController> logger)
        {
            this.tubes = tubes;
            this.categories = categories;
            this.hostEnvironment = hostEnvironment;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page)
        {
            IQueryable<Tube> allTubes = tubes.GetAllIncluding(x => x.Category);

            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(await PaginatedList<Tube>.CreateAsync(allTubes,
                                                              pageNumber,
                                                              pageSize));
        }

        [HttpGet]
        public async Task<ActionResult<TubeViewModel>> Edit(int tubeId)
        {
            TubeViewModel model = new TubeViewModel();
            model.Tube = await tubes.GetAsync(tubeId);
            model.CategoriesList = await GetCategoriesList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Tube>> Edit(Tube tube, string price, string discount)
        {
            decimal priceNum;
            decimal discoNum;

            bool priceParse = decimal.TryParse(price, out priceNum);
            bool discoParse = decimal.TryParse(discount, out discoNum);

            if (!priceParse || !discoParse) return RedirectToAction("Edit", tube.TubeId);

            Tube tempTube = await tubes.FindAsync(x => x.TubeId == tube.TubeId);

            tempTube.Type = tube.Type;
            tempTube.Brand = tube.Brand;
            tempTube.Date = tube.Date;
            tempTube.ShortDescription = tube.ShortDescription;
            tempTube.FullDescription = tube.FullDescription;
            tempTube.MatchedPair = tube.MatchedPair;
            tempTube.Quantity = tube.Quantity;
            if (tube.ImageUrl !=null) tempTube.ImageUrl = tube.ImageUrl;
            if (tube.ImageThumbnailUrl != null) tempTube.ImageThumbnailUrl = tube.ImageThumbnailUrl;
            tempTube.IsTubeOfTheWeek = tube.IsTubeOfTheWeek;
            tempTube.IsNewArrival = tube.IsNewArrival;
            tempTube.CategoryId = tube.CategoryId;
            tempTube.Price = priceNum;
            tempTube.Discount = discoNum;

            try
            {
                await tubes.UpdateAsync(tempTube);
            }
            catch(Exception ex)
            {
                logger.LogInformation(ex.Message);
            }

            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public async Task<ActionResult<TubeViewModel>> Add()
        {
            TubeViewModel model = new TubeViewModel();
            model.Tube = new Tube();
            model.CategoriesList = await GetCategoriesList();
            return View(model);
        }

        [HttpGet]
        private async Task<List<SelectListItem>> GetCategoriesList ()
        {
            List<SelectListItem> categoriesList = new List<SelectListItem>();
            ICollection<Category> categoryList = await categories.GetAllAsync();
            foreach(var cat in categoryList)
            {
                categoriesList.Add(new SelectListItem()
                {
                    Text = cat.CategoryName,
                    Value = cat.CategoryId.ToString()
                });
            }
            return categoriesList;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Tube>> Add(Tube tube, 
                                                  IFormFile image, IFormFile thumb,
                                                  string price, string discount)
        {
            //if (!ModelState.IsValid) is server validation
            //return View(tube); -- back to form

            //test data annotations in class
            //asp-validation on front
            
            decimal priceNum;
            decimal discoNum;

            bool priceParse = decimal.TryParse(price, out priceNum);
            bool discoParse = decimal.TryParse(discount, out discoNum);

            if (!priceParse || !discoParse) return RedirectToAction("Add");
            //return Content("Fail price or discount");

            tube.Price = priceNum;
            tube.Discount = discoNum;

            try 
            {
                tube.ImageUrl = await UploadAndGetPath(tube, image);
                tube.ImageThumbnailUrl = await UploadAndGetPath(tube, thumb);
                await tubes.AddAsync(tube);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
            }
            
            return RedirectToAction("Index");
        }

        private async Task<string> UploadAndGetPath(Tube tube, IFormFile image)
        {
            Category category = await categories.GetAsync(tube.CategoryId);

            var categoryPath = Path.Combine(hostEnvironment.WebRootPath, "Images", category.CategoryName);
             
            if (!Directory.Exists(categoryPath))
                Directory.CreateDirectory(categoryPath);
            
            var typePath = Path.Combine(categoryPath, tube.Type);

            if (!Directory.Exists(typePath))
                Directory.CreateDirectory(typePath);

            var imagePath = Path.Combine(typePath, image.FileName);
            var fileStream = new FileStream(imagePath, FileMode.Create);
            await image.CopyToAsync(fileStream);

            return Path.Combine("\\Images", category.CategoryName, tube.Type, image.FileName);
        }

    }
}