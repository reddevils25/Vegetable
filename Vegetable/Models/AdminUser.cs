using System;
using System.Collections.Generic;

namespace Vegetable.Models;

public partial class AdminUser
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Passwords { get; set; }

    public string? Email { get; set; }
    public bool Role { get; set; }
    public bool IsActive { get; set; }
}
