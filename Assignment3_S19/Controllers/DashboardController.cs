using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Assignment3_S19.Data;
using Assignment3_S19.Models;
using Assignment3_S19.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment3_S19.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private ApplicationDbContext _dbContext;
        private UserManager<ApplicationUser> _userManager;
        private IEXTradingService _iexService;

        public DashboardController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, IEXTradingService iexService)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _iexService = iexService;
        }

        public async Task<ActionResult> Index()
        {
            var model = new DashboardViewModel();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = await _userManager.Users
                .Include(u => u.UserStocks)
                .FirstAsync(u => u.Id == userId);

            // Symbols to be requested
            var symbols = user.UserStocks.Select(stock => stock.Symbol).ToArray();

            // Data to be requested
            var requested = new string[] { "chart", "company", "quote" };

            // Make request to IEX Trading API
            var stockData = await _iexService.GetStockData(symbols, requested, range: "1m");

            model.User = user;
            model.StockData = stockData;

            return View(model);
        }
    }


}