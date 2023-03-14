using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.infrastructure
{
    public interface IAnki
    {
        Dictionary<string, int> GetDictionary();
        int GetMaxDays();
    }
}
