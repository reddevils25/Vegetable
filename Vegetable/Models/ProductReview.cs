using System;
using System.Collections.Generic;

namespace Vegetable.Models;

public partial class ProductReview
{
    public int ReviewId { get; set; }

    public int ProductId { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? Image { get; set; }

    public bool IsActive { get; set; }

    public virtual Product Product { get; set; } = null!;
}
