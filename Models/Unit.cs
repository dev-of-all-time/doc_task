using System;
using System.Collections.Generic;

namespace doc_task.Models;

public partial class Unit
{
    public int UnitId { get; set; }

    public int OrgId { get; set; }

    public string UnitName { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int? UnitParent { get; set; }

    public virtual ICollection<Unit> InverseUnitParentNavigation { get; set; } = new List<Unit>();

    public virtual Org Org { get; set; } = null!;

    public virtual ICollection<Reminderunit> Reminderunits { get; set; } = new List<Reminderunit>();

    public virtual ICollection<Taskunitassignment> Taskunitassignments { get; set; } = new List<Taskunitassignment>();

    public virtual Unit? UnitParentNavigation { get; set; }

    public virtual ICollection<Unituser> Unitusers { get; set; } = new List<Unituser>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
