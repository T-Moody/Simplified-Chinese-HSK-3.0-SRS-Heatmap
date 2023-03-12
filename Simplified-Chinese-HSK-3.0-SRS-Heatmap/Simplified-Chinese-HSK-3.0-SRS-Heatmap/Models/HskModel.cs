using System.ComponentModel.DataAnnotations;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models
{
    public class HskModel
    {
        [Key]
        public int id;
        public string? Character { get; set; }

        public string? Type { get; set; }
        public string? Level { get; set; }
        public string? Color { get; set; }

        /// <summary>
        /// No Arg constructor.
        /// </summary>
        public HskModel() { }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="character">The chinese character.</param>
        /// <param name="type">The type. EX: character or vocabulary.</param>
        /// <param name="level">The HSK level.</param>
        public HskModel(string? character, string? type, string? level)
        {
            Character = character;
            Type = type;
            Level = level;
        }
    }
}