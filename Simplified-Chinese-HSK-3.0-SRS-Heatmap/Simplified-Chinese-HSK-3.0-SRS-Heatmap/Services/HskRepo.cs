using Microsoft.EntityFrameworkCore;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Data;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.infrastructure;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Services
{
    public class HskRepo : IHsk
    {
        public readonly string _hskAllFileName = @"wwwroot\files\all_HSK.txt"; // Name of the file constaining hsk values. Each line must use \t as a delimeter. EX of a line: 的 Characters  HSK1
        public readonly string _hskDictionaryFileName = @"wwwroot\files\dictionary_HSK.txt"; // File with characters and days. Delimeter is \t. EX: 的[de5;结构助词的] 
        public AnkiDbContext _ankiContext;

        private string[] _hskAllContext;
        private string[] _hskDictionaryContext;

        /// <summary>
        /// Read in files and create context.
        /// </summary>
        public HskRepo(AnkiDbContext ankiContext)
        {
            _hskAllContext = File.ReadAllLines(_hskAllFileName);
            _hskDictionaryContext = File.ReadAllLines(_hskDictionaryFileName);
            _ankiContext = ankiContext;
        }

        /// <summary>
        /// Get a list of hsk values from file and create a list of hskModels.
        /// </summary>
        /// <returns>List of hskModels.</returns>
        public List<HskModel> GetAll()
        {
            var hskModels = new List<HskModel>();

            hskModels = _hskAllContext.Select(line => ConvertHskLineToHskModel(line)).ToList();

            return hskModels;
        }

        /// <summary>
        /// Get list of characters and days from file and map each character to day.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> GetDictionary()
        {
            string removalPattern = @"\s*\[.*?\]\s*";
            string replacement = "";

            Dictionary<string, int> hskDictionary = _ankiContext.Cards
                .Join(_ankiContext.Notes, card => card.Nid, note => note.Id, (card, note) => new { Sfld = note.Sfld, card.Ivl })
                .AsEnumerable()
                .GroupBy(x => Regex.Replace(x.Sfld, removalPattern, replacement))
                .ToDictionary(g => g.Key, g => g.First().Ivl);

            return hskDictionary;
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

        /// <summary>
        /// Get max days from dictionary string array.
        /// </summary>
        /// <returns>Integer max number of days.</returns>
        public int GetMaxDays()
        {
            return _hskDictionaryContext.Select(line => int.Parse(line.Split('\t')[1])).Max();
        }
    }
}
