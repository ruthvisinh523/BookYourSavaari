using System;
using System.Collections.Generic;

namespace DataEntity;

public partial class UserTbl
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public string? PasswordSult { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Gender { get; set; }

    public int? RoleId { get; set; }

    public int? Craeateby { get; set; }

    public int? Updateby { get; set; }

    public DateOnly? Createon { get; set; }

    public DateOnly? Updateon { get; set; }

    public bool? IssActive { get; set; }

    public virtual RoleTbl? Role { get; set; }
}
