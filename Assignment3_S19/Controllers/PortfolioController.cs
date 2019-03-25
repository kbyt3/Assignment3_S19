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

            var symbols = user.UserStocks.Select(s => s.Symbol).ToArray();

            var companies = _dbContext.Companies
                .Where(c => symbols.Contains(c.Symbol));

            foreach (var stock in user.UserStocks)
            {
                stock.Company = companies.First(c => c.Symbol == stock.Symbol);
            }

            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> AddStock(string symbol)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var company = await _dbContext.Companies.FirstOrDefaultAsync(c => c.Symbol == symbol);

            if (company == null)
            {
                TempData["message"] = $"{symbol} was not found in our database.";
                TempData["messageType"] = "danger";

                return RedirectToAction("Index");
            }

            var stock = new UserStock
            {
                UserId = userId,
                Symbol = symbol
            };

            _dbContext.UserStocks.Add(stock);

            await _dbContext.SaveChangesAsync();

            TempData["message"] = $"{symbol} was added to your favorites.";
            TempData["messageType"] = "success";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> RemoveStock(string symbol)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var stock = _dbContext.UserStocks.Where(s => s.UserId == userId && s.Symbol == symbol).First();

            _dbContext.UserStocks.Remove(stock);

            await _dbContext.SaveChangesAsync();

            TempData["message"] = $"{symbol} was removed from your favorites.";
            TempData["messageType"] = "info";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SearchCompany(string searchText)
        {
            var results = from company in _dbContext.Companies
                          where (company.Name.StartsWith(searchText) || company.Symbol.StartsWith(searchText)) && company.IsEnabled
                          select new { label = company.Name, value = company.Symbol };

            return Json(results);
        }
    }
}