using System;
using System.Collections.Generic;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;

public partial class Note
{
    public long Id { get; set; }

    public string Guid { get; set; } = null!;

    public long Mid { get; set; }

    public long Mod { get; set; }

    public long Usn { get; set; }

    public string Tags { get; set; } = null!;

    public string Flds { get; set; } = null!;

    public string Sfld { get; set; }

    public long Csum { get; set; }

    public long Flags { get; set; }

    public string Data { get; set; } = null!;
}
