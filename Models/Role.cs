using System;
using System.Collections.Generic;

namespace doc_task.Models;

public partial class Role
{
    public int Roleid { get; set; }

    public string Rolename { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime Createdat { get; set; }

    public virtual ICollection<Userrole> Userroles { get; set; } = new List<Userrole>();
}
