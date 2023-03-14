using Simplified_Chinese_HSK_3._0_SRS_Heatmap.infrastructure;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Services
{
    public class HskRepo : IHsk
    {
        public readonly string _hskAllFileName = @"wwwroot\files\all_HSK.txt"; // Name of the file constaining hsk values. Each line must use \t as a delimeter. EX of a line: 的 Characters  HSK1
        private string[] _hskAllContext;

        /// <summary>
        /// Constructor reads lines from file into string array.
        /// </summary>
        public HskRepo() 
        {
            _hskAllContext = File.ReadAllLines(_hskAllFileName);
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
    }
}
