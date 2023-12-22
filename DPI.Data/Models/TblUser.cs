using System;
using System.Collections.Generic;

namespace DPI.Data.Models;

public partial class TblUser
{
    public int PkUserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    public string? EmailId { get; set; }
}
