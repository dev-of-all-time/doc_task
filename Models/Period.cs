using System;
using System.Collections.Generic;

namespace doc_task.Models;

public partial class Period
{
    public int PeriodId { get; set; }

    public string PeriodName { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();

    public virtual ICollection<Reminder> Reminders { get; set; } = new List<Reminder>();

    public virtual ICollection<Reportsummary> Reportsummaries { get; set; } = new List<Reportsummary>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
