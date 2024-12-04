using System;
using System.Collections.Generic;

namespace Vegetable.Models;

public partial class Menu
{
    public int MenuId { get; set; }

    public string Title { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public int? Parent { get; set; }

    public string? Position { get; set; }

    public bool IsActive { get; set; }

    public string? Description { get; set; }
}
