using System;
using System.Collections.Generic;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;

public partial class Col
{
    public long Id { get; set; }

    public long Crt { get; set; }

    public long Mod { get; set; }

    public long Scm { get; set; }

    public long Ver { get; set; }

    public long Dty { get; set; }

    public long Usn { get; set; }

    public long Ls { get; set; }

    public string Conf { get; set; } = null!;

    public string Models { get; set; } = null!;

    public string Decks { get; set; } = null!;

    public string Dconf { get; set; } = null!;

    public string Tags { get; set; } = null!;
}
