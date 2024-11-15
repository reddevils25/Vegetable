using System;
using System.Collections.Generic;

namespace Vegetable.Models;

public partial class Menu
{
    public string MenuId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public string? Parent { get; set; }

    public string? Position { get; set; }

    public bool? IsActive { get; set; }
}
