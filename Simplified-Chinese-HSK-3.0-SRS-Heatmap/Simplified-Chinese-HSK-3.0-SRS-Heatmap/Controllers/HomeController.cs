using Microsoft.AspNetCore.Mvc;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;
using System.Diagnostics;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            

            List<HskModel> hSKModels = GetHskModelsFromFile(@"wwwroot\files\all_HSK.txt");

            return View(hSKModels);
        }

        /// <summary>
        /// Get a list of hsk values from file and create a list of HskModels.
        /// </summary>
        /// <param name="fileName">Name of the file constaining hsk values. Each line must us \t as a delimeter. EX of a line: 的 Characters  HSK1</param>
        /// <returns>List of HskModels.</returns>
        private static List<HskModel> GetHskModelsFromFile(string fileName)
        {
            string[] hskLines = System.IO.File.ReadAllLines(fileName);

            List<HskModel> HskModels = new List<HskModel>();

            foreach (var hskLine in hskLines)
            {
                HskModel hskModel = ConvertHskLineToHskModel(hskLine);
                HskModels.Add(hskModel);
            }

            return HskModels;
        }

        /// <summary>
        /// Convert a hskLine string to HskModel.
        /// </summary>
        /// <param name="hskLine">Ex: 的 Characters  HSK1</param>
        /// <returns>HskModel</returns>
        private static HskModel ConvertHskLineToHskModel(string hskLine)
        {
            string[] currentLine = hskLine.Split("\t");

            string character = currentLine[0];
            string type = currentLine[1];
            string level = currentLine[2];

            return new HskModel(character, type, level);
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