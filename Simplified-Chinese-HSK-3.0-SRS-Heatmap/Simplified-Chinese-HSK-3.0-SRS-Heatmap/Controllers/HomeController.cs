using Microsoft.AspNetCore.Mvc;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public int maxDays = 0;

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
        /// Normalize the scale depending on max value and get the color in between with current value.
        /// </summary>
        /// <param name="color1">Low end color.</param>
        /// <param name="color2">High end color.</param>
        /// <param name="maxValue">Highest value for normalizing.</param>
        /// <param name="currentValue">Value used to get color.</param>
        /// <returns>Color</returns>
        public static Color GetColorBetween(Color color1, Color color2, int maxValue, int currentValue)
        {
            float t = (float)currentValue / maxValue; // Normalize the current value between 0 and 1
            t = Math.Min(Math.Max(t, 0), 1); // Clamp the value between 0 and 1
            int r = (int)(color1.R * (1 - t) + color2.R * t);
            int g = (int)(color1.G * (1 - t) + color2.G * t);
            int b = (int)(color1.B * (1 - t) + color2.B * t);
            return Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Loop through hskModels and set the color using the dictionary.
        /// </summary>
        /// <param name="hskModels">List of HskModels.</param>
        /// <param name="hskDictionary">Dictionary with characters and days.</param>
        public void SetHskModelColors(List<HskModel> hskModels, Dictionary<string, int> hskDictionary)
        {
            foreach (HskModel hskModel in hskModels)
            {
                int days;

                if (hskDictionary.TryGetValue(hskModel.Character, out days))
                {

                    if (days >= 20)
                    {
                        hskModel.Color = "#" + GetColorBetween(Color.LightGreen, Color.DarkGreen, maxDays, hskDictionary[hskModel.Character]).Name.Substring(2);
                    }
                    else if(days > 0 && days < 21)
                    {
                        hskModel.Color = "#" + GetColorBetween(Color.LightYellow, Color.Yellow, 20, hskDictionary[hskModel.Character]).Name.Substring(2);
                    }
                    else if(days == 0)
                    {
                        hskModel.Color = "rgba(255, 0, 0, 0.2)";
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
        private Dictionary<string, int> CreateHskDictionaryFromFile(string FileName)
        {
            string[] hskMapFile = System.IO.File.ReadAllLines(FileName);

            Dictionary<string, int> hskMap = new Dictionary<string, int>();

            string removalPattern = @"\s*\[.*?\]\s*";
            string replacement = "";

            foreach (string hskMapLine in hskMapFile)
            {
                string[] currentLine = hskMapLine.Split('\t');

                string character = Regex.Replace(currentLine[0], removalPattern, replacement);
                int days = int.Parse(currentLine[1]);

                if (days > maxDays)
                {
                    maxDays = days;
                }

                if (!hskMap.ContainsKey(character))
                {
                    hskMap.Add(character, days);
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