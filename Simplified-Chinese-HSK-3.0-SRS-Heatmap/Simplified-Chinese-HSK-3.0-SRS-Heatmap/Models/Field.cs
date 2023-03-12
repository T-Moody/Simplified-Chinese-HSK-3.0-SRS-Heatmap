using System;
using System.Collections.Generic;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;

public partial class Field
{
    public long Ntid { get; set; }

    public long Ord { get; set; }

    public string Name { get; set; } = null!;

    public byte[] Config { get; set; } = null!;
}
