using Microsoft.EntityFrameworkCore;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Data;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.infrastructure;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Services
{
    public class AnkiRepo : IAnki
    {
        public AnkiDbContext _ankiContext;

        /// <summary>
        /// Read in files and create context.
        /// </summary>
        public AnkiRepo(AnkiDbContext ankiContext)
        {
            _ankiContext = ankiContext;
        }
 
        /// <summary>
        /// Get list of characters and days from file and map each character to day.
        /// </summary>
        /// <returns>Dictionary of characters and number of days.</returns>
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
        /// Get max days after joining chards and notes.
        /// </summary>
        /// <returns>Integer max number of days.</returns>
        public int GetMaxDays()
        {
            return _ankiContext.Cards.Join(_ankiContext.Notes, card => card.Nid, note => note.Id, (card, note) => new { Sfld = note.Sfld, card.Ivl })
                   .Max(x => x.Ivl);
        }
    }
}
