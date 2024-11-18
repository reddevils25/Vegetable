using System;
using System.Collections.Generic;

namespace Vegetable.Models;

public partial class Blog
{
    public string BlogId { get; set; } = null!;

    public string? CategoryId { get; set; }

    public string Title { get; set; } = null!;

    public string Comment { get; set; } = null!;
    public string? image { get; set; }

    public string AuthorId { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual Category? Category { get; set; }
}
