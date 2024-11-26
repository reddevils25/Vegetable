using System;
using System.Collections.Generic;

namespace Vegetable.Models;

public partial class BlogComment
{
    public int CommentId { get; set; }

    public int BlogId { get; set; }

    public string? Detail { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public bool? IsActive { get; set; }

    public string? Images { get; set; }

    public virtual Blog Blog { get; set; } = null!;
}
