using System;
using System.Collections.Generic;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;

public partial class Tag
{
    public string Tag1 { get; set; } = null!;

    public long Usn { get; set; }

    public byte[] Collapsed { get; set; } = null!;

    public byte[]? Config { get; set; }
}
