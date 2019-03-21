using Assignment3_S19.Data;
using Assignment3_S19.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Assignment3_S19.Controllers
{
    [Authorize]
    public class PortfolioController : Controller
    {
        private ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public PortfolioController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<ActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = await _userManager.Users
                .Include(u => u.UserStocks)
                .FirstAsync(u => u.Id == userId);
            
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> AddStock(string symbol)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var stock = new UserStock
            {
                UserId = userId,
                Symbol = symbol
            };
            
            _dbContext.UserStocks.Add(stock);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SearchCompany(string searchText)
        {
            var results = from company in _dbContext.Companies
                          where (company.Name.StartsWith(searchText) || 
                                    company.Symbol.StartsWith(searchText)) && company.IsEnabled
                          select new { label = company.Name, value = company.Symbol };

            return Json(results);
        }
    }
}