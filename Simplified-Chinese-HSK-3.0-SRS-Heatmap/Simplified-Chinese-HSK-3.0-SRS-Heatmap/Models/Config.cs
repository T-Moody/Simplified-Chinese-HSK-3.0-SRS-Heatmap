using System;
using System.Collections.Generic;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;

public partial class Config
{
    public string Key { get; set; } = null!;

    public long Usn { get; set; }

    public long MtimeSecs { get; set; }

    public byte[] Val { get; set; } = null!;
}
