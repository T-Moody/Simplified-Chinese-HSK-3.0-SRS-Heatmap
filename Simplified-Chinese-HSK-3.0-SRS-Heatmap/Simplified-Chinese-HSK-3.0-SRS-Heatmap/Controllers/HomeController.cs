using Microsoft.AspNetCore.Mvc;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;
using System.Diagnostics;
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
            Dictionary<string, int> hskDictionary = CreateHskDictionaryFromFile(@"wwwroot\files\mapFile.txt");

            List<HskModel> hskModels = GetHskModelsFromFile(@"wwwroot\files\all_HSK.txt");

            SetHskModelColors(hskModels, hskDictionary);

            return View(hskModels);
        }

        /// <summary>
        /// Loop through hskModels and set the color using the dictionary.
        /// </summary>
        /// <param name="hskModels">List of HskModels.</param>
        /// <param name="hskDictionary">Dictionary with characters and days.</param>
        public static void SetHskModelColors(List<HskModel> hskModels, Dictionary<string, int> hskDictionary)
        {
            foreach (HskModel hskModel in hskModels)
            {
                int days;

                if (hskDictionary.TryGetValue(hskModel.Character, out days))
                {

                    if (days >= 20)
                    {
                        hskModel.Color = "green";
                    }
                    else if(days > 0 && days < 21)
                    {
                        hskModel.Color = "yellow";
                    }
                    else if(days == 0)
                    {
                        hskModel.Color = "red";
                    }
                }
                else
                {
                    hskModel.Color = "white";
                }
            }
        }

        /// <summary>
        /// Get list of characters and days from file and map each character to day.
        /// </summary>
        /// <param name="FileName">File with characters and days. Delimeter is \t. EX: 的[de5;结构助词的]  214</param>
        /// <returns></returns>
        private static Dictionary<string, int> CreateHskDictionaryFromFile(string FileName)
        {
            string[] hskMapFile = System.IO.File.ReadAllLines(FileName);

            Dictionary<string, int> hskMap = new Dictionary<string, int>();

            string removalPattern = @"\s*\[.*?\]\s*";
            string replacement = "";

            foreach (string hskMapLine in hskMapFile)
            {
                string[] currentLine = hskMapLine.Split('\t');

                string character = Regex.Replace(currentLine[0], removalPattern, replacement);
                string days = currentLine[1];

                if (!hskMap.ContainsKey(character))
                {
                    hskMap.Add(character, int.Parse(days));
                }
            }

            return hskMap;
        }

        /// <summary>
        /// Get a list of hsk values from file and create a list of hskModels.
        /// </summary>
        /// <param name="fileName">Name of the file constaining hsk values. Each line must us \t as a delimeter. EX of a line: 的 Characters  HSK1</param>
        /// <returns>List of hskModels.</returns>
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