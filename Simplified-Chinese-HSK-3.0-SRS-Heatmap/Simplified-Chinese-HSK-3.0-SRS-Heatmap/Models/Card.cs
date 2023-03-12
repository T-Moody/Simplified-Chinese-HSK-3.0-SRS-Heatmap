using System;
using System.Collections.Generic;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;

public partial class Card
{
    public long Id { get; set; }

    public long Nid { get; set; }

    public long Did { get; set; }

    public long Ord { get; set; }

    public long Mod { get; set; }

    public long Usn { get; set; }

    public long Type { get; set; }

    public long Queue { get; set; }

    public long Due { get; set; }

    public int Ivl { get; set; }

    public long Factor { get; set; }

    public long Reps { get; set; }

    public long Lapses { get; set; }

    public long Left { get; set; }

    public long Odue { get; set; }

    public long Odid { get; set; }

    public long Flags { get; set; }

    public string Data { get; set; } = null!;
}
