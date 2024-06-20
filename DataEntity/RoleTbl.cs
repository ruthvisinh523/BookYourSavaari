using System;
using System.Collections.Generic;

namespace DataEntity;

public partial class RoleTbl
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<UserTbl> UserTbls { get; set; } = new List<UserTbl>();
}
