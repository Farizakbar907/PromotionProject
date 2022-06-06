using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectPromotion.Data;
using ProjectPromotion.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProjectPromotion.Controllers
{
    public class PromotionController : Controller
    {
        private readonly PromotionContext _context;
        private readonly IWebHostEnvironment _environment;

        public PromotionController(PromotionContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _environment = webHost;
        }

        /// <summary>
        /// List Promotions
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            List<Models.Promotion> promotions = await _context.Promotions.ToListAsync();

            return View(promotions);
        }

        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> Create(PromotionViewModel model)
        {
            //lib
            string reqNumber = DateTime.Today.ToString("yyyyMMdd");
            string months = DateTime.Today.ToString("MM");
            Promotion lastNumber = _context.Promotions.OrderByDescending(x => x.Id).FirstOrDefault();

            Promotion models = new Promotion();
            PromotionViewModel promotionViewModel = new PromotionViewModel();

            if (lastNumber == null && reqNumber != null)
            {
                //model.Promotion.IdPromotion = "P" + "" + reqNumber + "" + "0001";
                models.IdPromotion = "P" + "" + reqNumber + "" + "0001";
            }
            else if (lastNumber.IdPromotion.Substring(5, 2) != months)
            {
                //model.Promotion.IdPromotion = "P" + "" + reqNumber + "" + "0001";
                models.IdPromotion = "P" + "" + reqNumber + "" + "0001";
            }
            else
            {
                models.IdPromotion = "P" + "" + reqNumber + (Convert.ToInt32(lastNumber.IdPromotion.Substring(9, lastNumber
                    .IdPromotion.Length - 9)) + 1).ToString("D4");
            }          

            promotionViewModel.StoresViewModel = GetStores();
            promotionViewModel.Promotion = model.Promotion;
            
            if (model.Promotion != null)
            {
                Promotion TempPromotion = new Promotion();
                TempPromotion = promotionViewModel.Promotion;
                TempPromotion.IdPromotion = models.IdPromotion;

                model.Promotion = TempPromotion;
            }

            if (ModelState.IsValid && promotionViewModel.Promotion != null)
            {
                //string folder = "item/file";
                //folder += model.Item.FileName + Guid.NewGuid().ToString() + "_" + model.Item.FileName;
                //string serverFolder = Path.Combine(_environment.WebRootPath);

                //await model.Item.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                string filename = ContentDispositionHeaderValue.Parse(model.Promotion.Item.ContentDisposition).FileName.Trim('"');
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "items", model.Promotion.Item.FileName);
                using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                {
                    await model.Promotion.Item.CopyToAsync(stream);
                }

                _context.Promotions.Add(model.Promotion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(promotionViewModel);
        }

        private List<Stores> GetStores()
        {
            List<Models.Stores> stores = _context.Stores.ToList();

            return stores;
        }
    }
}
