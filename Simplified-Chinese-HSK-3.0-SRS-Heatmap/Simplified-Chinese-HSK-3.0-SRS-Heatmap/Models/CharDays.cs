namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models
{
    public class CharDays
    {
        public string Character { get; set; }
        public int Days { get; set; }
        public CharDays() { }

        public CharDays(string character, int days)
        {
            Character = character;
            Days = days;
        }
    }
}
