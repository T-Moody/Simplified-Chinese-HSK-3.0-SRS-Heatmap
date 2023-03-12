using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.infrastructure
{
    public interface IHsk
    {
        List<HskModel> GetAll();
        Dictionary<string, int> GetDictionary();
        int GetMaxDays();
    }
}
