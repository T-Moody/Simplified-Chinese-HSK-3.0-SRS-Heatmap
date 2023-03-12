using System;
using System.Collections.Generic;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;

public partial class Deck
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long MtimeSecs { get; set; }

    public long Usn { get; set; }

    public byte[] Common { get; set; } = null!;

    public byte[] Kind { get; set; } = null!;
}
