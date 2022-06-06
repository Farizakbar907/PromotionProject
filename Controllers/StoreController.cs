using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectPromotion.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPromotion.Controllers
{
    public class StoreController : Controller
    {
        private readonly ILogger<StoreController> _logger;
        private readonly PromotionContext _context;

        public StoreController(ILogger<StoreController> logger, PromotionContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ListStore()
        {
            List<Models.Stores> stores = await _context.Stores.ToListAsync();

            return View(stores);
        }
    }
}
