using System;
using System.Collections.Generic;

namespace DataEntity;

public partial class LoginTbl
{
    public int LoginId { get; set; }

    public string? UserName { get; set; }

    public string? PasswordHase { get; set; }

    public string? PsswordSult { get; set; }
}
