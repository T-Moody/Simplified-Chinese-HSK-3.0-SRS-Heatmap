using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;
using System.Drawing;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Helpers
{
    public static class ColorHelper
    {
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
        public static void SetHskModelColors(List<HskModel> hskModels, Dictionary<string, int> hskDictionary, int maxDays)
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
                    else if (days > 0 && days < 21)
                    {
                        hskModel.Color = "#" + GetColorBetween(Color.LightYellow, Color.Yellow, 20, hskDictionary[hskModel.Character]).Name.Substring(2);
                    }
                    else if (days == 0)
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
    }
}
