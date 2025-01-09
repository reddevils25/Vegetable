using System;
using System.Collections.Generic;

namespace Vegetable.Models;

public partial class Blog
{
    public int BlogId { get; set; }

    public int? CategoryId { get; set; }

    public string? Title { get; set; }

    public string? Comment { get; set; }

    public string? AuthorId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public string? Image { get; set; }

    public string? Alias { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<BlogComment> BlogComments { get; set; } = new List<BlogComment>();

    public virtual Category? Category { get; set; }
}
