using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Assignment3_S19.Services;
using Assignment3_S19.Models;


namespace Assignment3_S19.Controllers
{
    public class QuotesController : Controller
    {
        private IEXTradingService _iexService;

        public QuotesController(IEXTradingService iexService)
        {
            _iexService = iexService;
        }

        public async Task<ActionResult> Index(string symbol, string range = "1m")
        {
            var response = await _iexService.GetStockData(
                symbols: new string[] { symbol },
                data: new string[] { "quote", "company", "chart", "news", "logo" },
                range: range);

            IEXApiResponse model = response.GetValueOrDefault(symbol);

            ViewData["range"] = range;

            return View(model);
        }
    }
}