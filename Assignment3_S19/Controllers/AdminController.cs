using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_S19.Data;
using Assignment3_S19.Models;
using Assignment3_S19.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3_S19.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _dbContext;
        private IEXTradingService _iexService;

        public AdminController(ApplicationDbContext dbContext, IEXTradingService iexService)
        {
            _dbContext = dbContext;
            _iexService = iexService;
        }

        public ActionResult Index()
        {
            var model = new AdminForm();

            model.CompanyCount = _dbContext.Companies.Count();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> LoadCompanies()
        {
            var companies = await _iexService.GetCompanies();

            // Delete all company rows
            var itemsToDelete = _dbContext.Set<Company>();
            _dbContext.Companies.RemoveRange(itemsToDelete);
            
            // Insert and save changes
            await _dbContext.Companies.AddRangeAsync(companies);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}