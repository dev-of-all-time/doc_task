using System;
using System.Collections.Generic;

namespace doc_task.Models;

public partial class FrequencyDetail
{
    public int Id { get; set; }

    public int FrequencyId { get; set; }

    public byte? DayOfWeek { get; set; }

    public byte? DayOfMonth { get; set; }

    public virtual Frequency Frequency { get; set; } = null!;
}
