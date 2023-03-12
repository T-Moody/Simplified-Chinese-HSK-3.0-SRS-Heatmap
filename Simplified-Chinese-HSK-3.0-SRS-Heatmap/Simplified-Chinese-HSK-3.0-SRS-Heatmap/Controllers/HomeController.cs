using Microsoft.AspNetCore.Mvc;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.infrastructure;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Services;
using System.Diagnostics;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Helpers;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Home page
        /// </summary>
        /// <returns>View with hskModels.</returns>
        public IActionResult Index()
        {
            IHsk hskRepo = new HskRepo();

            Dictionary<string, int> hskDictionary = hskRepo.GetDictionary();

            List<HskModel> hskModels = hskRepo.GetAll();

            int maxDays = hskRepo.GetMaxDays();

            ColorHelper.SetHskModelColors(hskModels, hskDictionary, maxDays);

            return View(hskModels);
        }  

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}